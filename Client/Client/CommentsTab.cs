using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Client
{
    public partial class CommentsTab : UserControl
    {
        private static float value = 1;
        private static Bitmap bitmap;
        private string selectedProject;
        private int Versions;
        private string Branches;
        private string[] Comments;
        private string username;
        private ClientSocket cSock;
        MainForm ParentF;
        public CommentsTab()
        {
            InitializeComponent();
            foreach (Control Item in this.Controls)
            {
                bunifuTransition1.ShowSync(Item);
                Application.DoEvents();
            }
            pictureView.MouseWheel += PictureView_MouseWheel;
        }

        public void SetTab(ClientSocket cliSock, string proName, string username)
        {
            try
            {
                this.username = username;
                this.ParentF = (MainForm)this.ParentForm;
                this.cSock = cliSock;
                this.selectedProject = proName;
                proLabel.Text = "SELECTED PROJECT: " + this.selectedProject;
                commentBox.Text = "Add A Comment...";
                previewBox.Clear();
                verBox.Items.Clear();
                verBox.Text = "";
                pictureView.Image = null;
                if (this.ParentF.GetHeader() == "My Profile")
                {
                    this.Versions = Convert.ToInt32(this.cSock.Get_Versions(this.selectedProject));
                }
                else
                {
                    this.Versions = Convert.ToInt32(this.cSock.Get_UVersions(this.selectedProject, username));
                }
                this.Branches = this.cSock.Get_Branches(this.selectedProject);
                if (this.Branches.Contains('_'))
                {
                    int branchIndex = 0;
                    string temp;
                    for (int i = 0; i < this.Versions; i++)
                    {
                        temp = this.Branches.Split(',')[branchIndex];
                        if ((i + 1) == Convert.ToInt32(temp.Split('_')[0]))
                        {
                            verBox.Items.Add((i + 1).ToString());
                            for (int x = 0; x < Convert.ToInt32(this.Branches.Split(',')[branchIndex].Split('_')[1]); x++)
                            {
                                verBox.Items.Add("   " + ((i + 1) + "." + (+x + 1).ToString()));
                            }
                            branchIndex++;
                        }
                        else
                        {
                            verBox.Items.Add((i + 1).ToString());
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Versions; i++)
                    {
                        verBox.Items.Add((i + 1).ToString());
                    }
                }
                SetComments();
                verBox.SelectedIndex = 0;
            }
            catch { }
        }

        public void SetComments()
        {
            this.Comments = this.cSock.Get_Comments(this.selectedProject).Split('\n');
            Array.Reverse(this.Comments);
            commentsList.Items.Clear();
            for (int i = 0; i < this.Comments.Length; i++)
            {
                if (this.Comments[i].Contains("^"))
                {
                    commentsList.Items.Add("(" + this.Comments[i].Split('^')[0] + ") "  + this.Comments[i].Split('^')[1]);
                    commentsList.Items.Add(this.Comments[i].Split('^')[2]);
                }
            }
        }


        private void commentBtn_Click(object sender, EventArgs e)
        {
            if (proLabel.Text != "SELECTED PROJECT: None" && commentBox.Text != "" && verBox.SelectedIndex > -1)
            {
                this.cSock.Comment(this.selectedProject, commentBox.Text, verBox.SelectedItem.ToString().Replace(" ", string.Empty));
                SetComments();
            }
            else
            {
                statusLabel.Text = "Select A Version To Comment On It";
                statusLabel.Visible = true;
                statusTimer.Start();
            }
            commentBox.Text = "";
        }

        private void commentBox_Click_1(object sender, EventArgs e)
        {
            commentBox.Text = "";
        }
          
        private void commentBox_Enter(object sender, EventArgs e)
        {
            commentBox.Text = "";
        }

        private void commentsList_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font f = e.Font;
            if (e.Index % 2 == 0)
            {
                f = new Font(e.Font, FontStyle.Bold);
            }
            e.DrawBackground();
            e.Graphics.DrawString(((ListBox)(sender)).Items[e.Index].ToString(), f, new SolidBrush(e.ForeColor), e.Bounds);
            e.DrawFocusRectangle();
        }

        private void verBox_SelectedIndexChanged(object sender, EventArgs e)
        /* Setting the preview.
         * 
         * When the user changes the previewed version from the combo box,
         * the program will request the selected version preview and showing it in the preview place.
         */
        {
        try
        {
            previewBox.Clear();
                if (verBox.SelectedIndex > -1)
                {
                    LoadingForm.ShowLoadingScreen();
                    if (this.cSock.GetType(this.selectedProject, verBox.SelectedItem.ToString()) != "png")
                    {
                        previewBox.Text = this.cSock.Get_Preview(this.selectedProject, verBox.SelectedItem.ToString());
                        previewBox.BringToFront();
                    }
                    else
                    {
                        int index = 0;
                        bool pathFound = false;
                        string tempPath = Path.GetTempPath() + "pic" + index.ToString() + ".png";
                        while (!pathFound)
                        {
                            if (!File.Exists(tempPath))
                            {
                                tempPath = Path.GetTempPath() + "pic" + index.ToString() + ".png";
                                pathFound = true;
                            }
                            else
                            {
                                index++;
                                tempPath = Path.GetTempPath() + "pic" + index.ToString() + ".png";
                            }
                        }
                        System.IO.File.WriteAllBytes(tempPath, Convert.FromBase64String(this.cSock.Get_Preview(this.selectedProject, verBox.SelectedItem.ToString())));
                        pictureView.Image = System.Drawing.Image.FromFile(tempPath);
                        bitmap = new Bitmap(tempPath);
                        pictureView.BringToFront();
                    }
                    LoadingForm.CloseForm();
                }
                else
                {
                    previewBox.Text = "No Version Selected";
                }
            }
            catch
            {
                //previewBox.Text = "Unable To Get Preview";
            }
        }

        private void pictureView_MouseHover(object sender, EventArgs e)
        {
            pictureView.Focus();
        }

        private void PictureView_MouseWheel(object sender, MouseEventArgs e)
        /* Zoom in/out a picture preview.
         * 
         * Incase the previewed version is a picture, if the user using the scrollwheel on the picture,
         * the picture will zoom in or out accordingly.
         */
        {
            try
            {
                if (e.Delta > 0)
                {
                    value += 0.1f;
                    pictureView.Image = new Bitmap(bitmap, new Size((int)(bitmap.Width * value), (int)(bitmap.Height * value)));
                }
                else
                {
                    value -= 0.1f;
                    if (value > 0)
                    {
                        pictureView.Image = new Bitmap(bitmap, new Size((int)(bitmap.Width * value), (int)(bitmap.Height * value)));
                    }
                    else
                    {
                        value = 0;
                    }
                }
            }
            catch { }
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            SetComments();
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            statusLabel.Visible = false;
            statusTimer.Stop();
        }

        private void commentBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.commentBtn_Click(null, null);
            }
            else { }
        }
    }
}
