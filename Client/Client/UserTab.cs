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
    }
}
