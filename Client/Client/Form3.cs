using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class NewProjectForm : Form
    {
        public string name;
        private string File;
        private ClientSocket cSock;
        private string[] text_extensions = {"html","xml","css","svg","json",
        "c","cpp","h","cs","js","py","java","rb","pl","php","sh",
        "txt","tex","markdown","asciidoc","rtf","ps","ini","cfg","rc","reg","csv","tsv", "png"};
        private Bunifu.Framework.UI.Drag dr = new Bunifu.Framework.UI.Drag();

        public NewProjectForm(ClientSocket cSock)
        {
            InitializeComponent();
            this.cSock = cSock;
        }

        public string Get_Name()
        {
            return this.name;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.File = openFileDialog.FileName;
                    pathBox.Text = this.File;
                }
            }
            catch
            { 
                statusLabel.Text = "File Type Unavailable";
                statusLabel.Visible = true;
                statusTimer.Start();
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.name = pnameBox.Text;
                if (this.name.Contains(' ') || this.name.Contains('^') || this.name.Contains('\\') || this.name.Contains('/'))
                {
                    throw new System.DivideByZeroException();
                }
                string fileInfo = this.name + "." + pathBox.Text.Split('.')[pathBox.Text.Split('.').Length - 1];
                bool valiable = false;
                foreach (string ext in this.text_extensions)
                {
                    if (fileInfo.Split('.')[1] == ext)
                    {
                        valiable = true;
                        break;
                    }
                }
                if (!valiable)
                {
                    statusLabel.Text = "File Type Not Supported";
                    statusLabel.Visible = true;
                    statusTimer.Start();
                    return;
                }
                string data = this.cSock.New_Project(this.File, fileInfo);
                this.Close();
            }
            catch (DivideByZeroException)
            {
                statusLabel.Text = "Project Name Unavailable";
                statusLabel.Visible = true;
                statusTimer.Start();
            }
            catch (FieldAccessException)
            {
                statusLabel.Text = "File Is Too Big";
                statusLabel.Visible = true;
                statusTimer.Start();
            }
        }

        private void pnameBox_Click(object sender, EventArgs e)
        {
            if (pnameBox.Text == "project name")
            {
                pnameBox.Clear();
            }
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            statusLabel.Visible = false;
            statusTimer.Stop();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            this.dr.Grab(this);
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            this.dr.MoveObject();
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            this.dr.Release();
        }
    }
}
