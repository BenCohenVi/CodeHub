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
            seperatorLine.Width = projectsTab.Width;
            seperatorLine.Left = projectsTab.Left;
            projectTab1.Visible = false;
            projectTab1.BringToFront();
            bunifuTransition1.ShowSync(projectTab1);
        }

        private void commentsTab_Click(object sender, EventArgs e)
        {
            seperatorLine.Width = commentsTab.Width;
            seperatorLine.Left = commentsTab.Left;
            this.lastSelected = projectTab1.Get_Latest();
            commentsTab1.SetTab(this.cSock, this.lastSelected);
            commentsTab1.Visible = false;
            commentsTab1.BringToFront();
            bunifuTransition1.ShowSync(commentsTab1);
        }

        private void shareTab_Click(object sender, EventArgs e)
        {
            seperatorLine.Width = shareTab.Width;
            seperatorLine.Left = shareTab.Left;
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
    }
}
