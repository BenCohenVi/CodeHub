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
    public partial class MainForm : Form
    {
        public ClientSocket cSock;
        private string lastSelected;
        private Bunifu.Framework.UI.Drag dr = new Bunifu.Framework.UI.Drag();
        public MainForm(ClientSocket clientSock, string username)
        {
            InitializeComponent();
            this.cSock = clientSock;
            projectTab1.SetSocket(this.cSock);
            nameLabel.Text = username;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void projectsTab_Click(object sender, EventArgs e)
        {
            if (placeLabel.Text == "My Profile")
            {
                seperatorLine.Width = projectsTabB.Width;
                seperatorLine.Left = projectsTabB.Left;
                projectTab1.Visible = false;
                projectTab1.BringToFront();
                bunifuTransition1.ShowSync(projectTab1);
            }
            else
            {
                seperatorLine.Width = projectsTabB.Width;
                seperatorLine.Left = projectsTabB.Left;
                userTab1.Visible = false;
                userTab1.BringToFront();
                bunifuTransition1.ShowSync(userTab1);
            }
        }

        public string GetHeader()
        {
            return placeLabel.Text;
        }

        private void commentsTab_Click(object sender, EventArgs e)
        {
            string username;
            if (placeLabel.Text == "My Profile")
            {
                this.lastSelected = projectTab1.Get_Latest();
                username = "";

            }
            else
            {
                this.lastSelected = userTab1.Get_Latest();
                username = placeLabel.Text.Replace("'s Profile", string.Empty);
            }

            seperatorLine.Width = commentsTabB.Width;
            seperatorLine.Left = commentsTabB.Left;
            commentsTab1.SetTab(this.cSock, this.lastSelected, username);
            commentsTab1.Visible = false;
            commentsTab1.BringToFront();
            bunifuTransition1.ShowSync(commentsTab1);
        }

        private void shareTab_Click(object sender, EventArgs e)
        {
            seperatorLine.Width = shareTabB.Width;
            seperatorLine.Left = shareTabB.Left;
            this.lastSelected = projectTab1.Get_Latest();
            sharedTab1.SetTab(this.cSock, this.lastSelected);
            sharedTab1.Visible = false;
            sharedTab1.BringToFront();
            bunifuTransition1.ShowSync(sharedTab1);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            this.dr.Grab(this);
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            this.dr.MoveObject();
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            this.dr.Release(); 
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            placeLabel.Text = "My Profile";
            projectsTabB.Visible = true;
            commentsTabB.Visible = true;
            shareTabB.Visible = true;
            projectsTabB.Enabled = true;
            commentsTabB.Enabled = true;
            shareTabB.Enabled = true;
            seperatorLine.Visible = true;
            seperatorLine.Width = projectsTabB.Width;
            seperatorLine.Left = projectsTabB.Left;
            projectTab1.Visible = false;
            projectTab1.BringToFront();
            bunifuTransition1.ShowSync(projectTab1);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            placeLabel.Text = "Search User";
            projectsTabB.Visible = false;
            commentsTabB.Visible = false;
            shareTabB.Visible = false;
            projectsTabB.Enabled = false;
            commentsTabB.Enabled = false;
            shareTabB.Enabled = false;
            seperatorLine.Visible = false;
            searchTab1.Set_Tab(this.cSock);
            searchTab1.Visible = false;
            searchTab1.BringToFront();
            bunifuTransition1.ShowSync(searchTab1);
        }

        public void SearchedUserSet(string newHeader, string projects)
        {
            projectsTabB.Visible = true;
            commentsTabB.Visible = true;
            projectsTabB.Enabled = true;
            commentsTabB.Enabled = true;
            projectsTabB.Visible = true;
            commentsTabB.Visible = true;
            seperatorLine.Visible = true;
            seperatorLine.Width = projectsTabB.Width;
            seperatorLine.Left = projectsTabB.Left;
            placeLabel.Text = newHeader;
            userTab1.Set_Tab(this.cSock, projects, newHeader.Replace("'s Profile", string.Empty));
            userTab1.Visible = false;
            userTab1.BringToFront();
            bunifuTransition1.ShowSync(userTab1);
        }
    }
}
