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
    public partial class SearchTab : UserControl
    {
        ClientSocket cSock;
        private string userSearch;
        public SearchTab()
        {
            InitializeComponent();
            foreach (Control Item in this.Controls)
            {
                bunifuTransition1.ShowSync(Item);
                Application.DoEvents();
            }
        }

        public void Set_Tab(ClientSocket cliSock)
        {
            this.cSock = cliSock;
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            userSearch = this.cSock.Search_User(userBox.text);
        }
    }
}
