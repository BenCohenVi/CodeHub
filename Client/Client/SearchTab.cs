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
        MainForm ParentF;
        private string userSearch;
        public SearchTab()
        {
            InitializeComponent();
            foreach (Control Item in this.Controls)
            {
                bunifuTransition1.ShowSync(Item);
                Application.DoEvents();
            }
            errorMessage1.Visible = false;
            successMessage1.Visible = false;
        }

        public void Set_Tab(ClientSocket cliSock)
        {
            this.cSock = cliSock;
            userBox.text = "";
            this.ParentF = (MainForm)this.ParentForm;
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            userSearch = this.cSock.Search_User(userBox.text);
            if (userSearch == "NO1")
            {
                successMessage1.Visible = false;
                errorMessage1.Set_Message("Cant Search Yourself");
                errorMessage1.Visible = true;
                successMessage1.BringToFront();
                userBox.text = "";
            }
            else if (userSearch == "NO")
            {
                successMessage1.Visible = false;
                errorMessage1.Set_Message("No Such User");
                errorMessage1.Visible = true;
                successMessage1.BringToFront();
                userBox.text = "";
            }
            else
            {
                this.ParentF.SearchedUserSet(userBox.text+"'s Profile", userSearch);
            }
        }
    }
}
