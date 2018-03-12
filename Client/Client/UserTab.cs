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
    public partial class UserTab : UserControl
    {
        ClientSocket cSock;
        private string projects;
        private string username;
        public UserTab()
        {
            InitializeComponent();
            foreach (Control Item in this.Controls)            {                bunifuTransition1.ShowSync(Item);                Application.DoEvents();            }
        }

        public string Get_Latest()        {            if (projectList.SelectedIndex > -1)            {                return projectList.SelectedItem.ToString();            }            else            {                return "None";            }        }

        public void Set_Tab(ClientSocket cliSock, string projects, string username)
        {
            projectList.Items.Clear();
            versionList.Items.Clear();
            this.username = username;
            this.cSock = cliSock;
            this.projects = projects;
            this.projects = this.Fix_Format(this.projects);            this.Set_Table();
        }

        public string Fix_Format(string project)        {            project = project.Replace("[", "").Replace("]", "").Replace("(", "").Replace(")", "").Replace("',", "").Replace("u'", "").Replace(" ", "").Replace("'", "");            return project;        }

        public void Set_Table()        {            foreach (string proName in this.projects.Split(','))            {                projectList.Items.Add(proName);            }        }

        private void projectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try            {                versionList.Items.Clear();                int Versions = Convert.ToInt32(this.cSock.Get_UVersions(projectList.SelectedItem.ToString(), this.username));                string branches = this.cSock.Get_Branches(projectList.SelectedItem.ToString());                if (branches.Contains('_'))                {                    int branchIndex = 0;                    string temp;                    for (int i = 0; i < Versions; i++)                    {                        temp = branches.Split(',')[branchIndex];                        if ((i + 1) == Convert.ToInt32(temp.Split('_')[0]))                        {                            versionList.Items.Add((i + 1).ToString());                            for (int x = 0; x < Convert.ToInt32(branches.Split(',')[branchIndex].Split('_')[1]); x++)                            {                                versionList.Items.Add("   " + ((i + 1) + "." + (+x + 1).ToString()));                            }                            branchIndex++;                        }                        else                        {                            versionList.Items.Add((i + 1).ToString());                        }                    }                }                else                {                    for (int i = 0; i < Versions; i++)                    {                        versionList.Items.Add((i + 1).ToString());                    }                }            }            catch { }
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogU.ShowDialog();
            if (result == DialogResult.OK && versionList.SelectedIndex > -1)
            {
                string path = folderBrowserDialogU.SelectedPath;
                string data = this.cSock.Download_Project(projectList.SelectedItem.ToString(), versionList.SelectedItem.ToString());
                string content = data.Split(new[] { "`~`" }, StringSplitOptions.None)[0];
                string extension = data.Split(new[] { "`~`" }, StringSplitOptions.None)[1];
                extension = extension.Replace("\0", string.Empty);
                if (extension != "png")
                {                    string filePath = path.Replace("\0", string.Empty) + "\\" + projectList.SelectedItem.ToString().Replace("\0", string.Empty) + "_" + versionList.SelectedItem.ToString().Replace("\0", string.Empty).Replace(".", "_").Replace(" ", "") + "." + extension.Replace("\0", string.Empty);
                    StreamWriter NewFile = new StreamWriter(filePath);
                    NewFile.Write(content);
                    NewFile.Close();
                }
                else
                {
                    string filePath = path.Replace("\0", string.Empty) + "\\" + projectList.SelectedItem.ToString().Replace("\0", string.Empty) + "_" + versionList.SelectedItem.ToString().Replace(".", "_").Replace(" ", "").Replace("\0", string.Empty) + "." + extension.Replace("\0", string.Empty);
                    System.IO.File.WriteAllBytes(filePath, Convert.FromBase64String(content));
                }
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            string proName = projectList.SelectedItem.ToString();
            this.cSock.Rquest_Share(this.username, proName);
        }
    }
}

