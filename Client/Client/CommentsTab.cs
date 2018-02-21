using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class CommentsTab : UserControl
    {
        private string selectedProject;
        private int Versions;
        private string Branches;
        private string[] Comments;
        private ClientSocket cSock;
        public CommentsTab()
        {
            InitializeComponent();
            foreach (Control Item in this.Controls)
            {
                bunifuTransition1.ShowSync(Item);
                Application.DoEvents();
            }
        }

        public void SetTab(ClientSocket cliSock, string proName)
        {
            try
            {
                this.cSock = cliSock;
                this.selectedProject = proName;
                proLabel.Text = "SELECTED PROJECT: " + this.selectedProject;
                commentBox.Text = "Add A Comment...";
                versionBox.Clear();
                this.Versions = Convert.ToInt32(this.cSock.Get_Versions(this.selectedProject));
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
                            versionBox.AddItem((i + 1).ToString());
                            for (int x = 0; x < Convert.ToInt32(this.Branches.Split(',')[branchIndex].Split('_')[1]); x++)
                            {
                                versionBox.AddItem("   " + ((i + 1) + "." + (+x + 1).ToString()));
                            }
                            branchIndex++;
                        }
                        else
                        {
                            versionBox.AddItem((i + 1).ToString());
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Versions; i++)
                    {
                        versionBox.AddItem((i + 1).ToString());
                    }
                }
                this.Comments = this.cSock.Get_Comments(this.selectedProject).Split('\n');
                this.Comments = this.Comments;
                SetComments();
            }
            catch { }
        }

        public void SetComments()
        {
            try
            {
                commentsList.Items.Clear();
                for (int i = 0; i < this.Comments.Length; i++)
                {
                    commentsList.Items.Add(this.Comments[i]);
                }
            }
            catch { }
        }

        private void versionBox_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                previewBox.Clear();
                if (versionBox.selectedIndex > -1)
                {
                    previewBox.Text = this.cSock.Get_Preview(this.selectedProject, versionBox.selectedValue);
                }
                else
                {
                    previewBox.Text = "No Version Selected";
                }
            }
            catch { }
        }

        private void commentBox_Click(object sender, EventArgs e)
        {
            commentBox.Text = "";
        }

        private void commentBtn_Click(object sender, EventArgs e)
        {
            if (proLabel.Text != "SELECTED PROJECT: None" && commentBox.Text != "")
            {
                this.cSock.Comment(this.selectedProject, commentBox.Text);
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
    }
}
