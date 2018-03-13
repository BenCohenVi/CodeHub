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
    public partial class RequestTab : UserControl
    {
        ClientSocket cSock;
        private string requests;
        public RequestTab()
        {
            InitializeComponent();
            foreach (Control Item in this.Controls)            {                bunifuTransition1.ShowSync(Item);                Application.DoEvents();            }
        }

        public void Set_Tab(ClientSocket cliSock)
        {
            this.cSock = cliSock;
            this.requests = this.cSock.Get_Requests();
            this.Set_Table();
        }

        public void Set_Table()
        {
            try
            {
                RequestList.Items.Clear();
                foreach (string request in this.requests.Split('\n'))
                {
                    if (request != "No Requests Yet")
                    {
                        RequestList.Items.Add(request.Split('^')[0] + " Wants You To Share " + request.Split('^')[1] + " Project With Him");
                        RequestList.Items.Add("");
                    }
                    else
                    {
                        RequestList.Items.Add("Bob");
                    }
                }
            }
            catch { }
        }
    }
}
