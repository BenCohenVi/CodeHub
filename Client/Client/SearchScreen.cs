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
    public partial class SearchScreen : UserControl
    {
        ClientSocket cSock;
        public SearchScreen()
        {
            InitializeComponent();
            searchTab1.Set_Tab(this.cSock);
            searchTab1.BringToFront();
            bunifuTransition1.ShowSync(searchTab1);
        }

        public void Set_Tab(ClientSocket cliSock)
        {
            this.cSock = cliSock;
        }
    }
}
