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
    public partial class SharedTab : UserControl
    {
        private string sharedProject;
        private ClientSocket cSock;
        public SharedTab()
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

        public void SetTab(ClientSocket cliSock, string proName)
        {
            this.cSock = cliSock;
            this.sharedProject = proName;
            nameLabel.Text = "Project Name: " + this.sharedProject;
        }

        private void shareBtn_Click(object sender, EventArgs e)
        {
            if (nameLabel.Text != "Project Name: None")
            {
                try
                {
                    this.cSock.Share_Project(this.sharedProject, this.cSock.Get_Versions(this.sharedProject), userBox.text);
                    userBox.text = "";
                    errorMessage1.Visible = false;
                    successMessage1.Set_Message("Project Shared");
                    successMessage1.Visible = true;
                    successMessage1.BringToFront();
                }
                catch (DivideByZeroException)
                {
                    successMessage1.Visible = false;
                    errorMessage1.Set_Message("No Such User");
                    errorMessage1.Visible = true;
                    successMessage1.BringToFront();
                }
                catch (DataMisalignedException)
                {
                    successMessage1.Visible = false;
                    errorMessage1.Set_Message("Not Main User");
                    errorMessage1.Visible = true;
                    successMessage1.BringToFront();
                }
                catch (DllNotFoundException)
                {
                    successMessage1.Visible = false;
                    errorMessage1.Set_Message("User Already Has Project");
                    errorMessage1.Visible = true;
                    successMessage1.BringToFront();
                }
                catch (IndexOutOfRangeException)
                {
                    successMessage1.Visible = false;
                    errorMessage1.Set_Message("Can't Share To Yourself");
                    errorMessage1.Visible = true;
                    successMessage1.BringToFront();
                }
            }
            else
            {
                successMessage1.Visible = false;
                errorMessage1.Set_Message("No Project Slected");
                errorMessage1.Visible = true;
                successMessage1.BringToFront();
            }
        }
    }
}
