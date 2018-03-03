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
    public partial class SearchedUser : UserControl
    {
        ClientSocket cSock;
        private string projects;
        public SearchedUser()
        {
            InitializeComponent();
            foreach (Control Item in this.Controls)            {                bunifuTransition1.ShowSync(Item);                Application.DoEvents();            }
        }

        public void Set_Tab(ClientSocket cliSock, string projects)
        {
            this.cSock = cliSock;
            this.projects = projects;
        }

    }
}
