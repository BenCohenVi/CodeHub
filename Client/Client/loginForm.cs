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
    public partial class loginForm : Form
    {
        public string ip;
        public int port;
        private bool Connected;
        private ClientSocket cSock;
        private Bunifu.Framework.UI.Drag dr = new Bunifu.Framework.UI.Drag();
        public loginForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.ip = "169.254.157.148";
            this.port = 10584;
            this.cSock = new ClientSocket(this.ip, this.port);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void logBtn_Click(object sender, EventArgs e)
        /* Loging/Registering to the server.
         * 
         * The logBtn is chaning, if the user wants to sign up its text is "REGISTER" else its "LOGIN",
         * this function accours when the button is clicked and acts accordingly to the button text.
         */
        {
            if (logBtn.ButtonText != "REGISTER")
            {
                this.Connected = this.cSock.Try_Login(userBox.Text, passBox.Text);
                if (this.Connected)
                {
                    MainForm CodeForm = new MainForm(this.cSock, userBox.Text);
                    CodeForm.Show();
                    this.Hide();
                }
                else
                {
                    statusLabel.ForeColor = Color.FromArgb(190, 23, 58);
                    statusLabel.Text = "Incorrect Information";
                    statusLabel.Visible = true;
                    statusTimer.Start();
                }
            }
            else
            {
                try
                {
                    if (userBox.Text != "" && passBox.Text != "")
                    {
                        this.cSock.Register(userBox.Text, passBox.Text);
                        signBtn.ButtonText = "Sign Up Here";
                        logBtn.ButtonText = "LOGIN";
                        userBox.ResetText();
                        passBox.ResetText();
                        statusLabel.ForeColor = Color.FromArgb(0, 190, 154);
                        statusLabel.Text = "User Created!";
                        statusLabel.Visible = true;
                        statusTimer.Start();
                    }
                    else
                    {
                        statusLabel.ForeColor = Color.FromArgb(190, 23, 58);
                        statusLabel.Text = "You Need To Fill All Spaces";
                        statusLabel.Visible = true;
                        statusTimer.Start();
                    }
                }
                catch
                {
                    statusLabel.ForeColor = Color.FromArgb(190, 23, 58);
                    statusLabel.Text = "Username Unavailable";
                    statusLabel.Visible = true;
                    statusTimer.Start();
                }
            }
        }

        private void signBtn_Click(object sender, EventArgs e)
        {
            if (signBtn.ButtonText != "Cancel")
            {
                signBtn.ButtonText = "Cancel";
                logBtn.ButtonText = "REGISTER";
                userBox.ResetText();
                passBox.ResetText();
            }
            else
            {
                signBtn.ButtonText = "Sign Up Here";
                logBtn.ButtonText = "LOGIN";
                userBox.ResetText();
                passBox.ResetText();
            }
        }

        private void exitBtn_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void minBtn_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            statusLabel.Visible = false;
            statusTimer.Stop();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            this.dr.Grab(this);
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            this.dr.MoveObject();
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            this.dr.Release();
        }

        private void passBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.logBtn_Click(null, null);
            }
            else { }
        }

        private void userBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.logBtn_Click(null, null);
            }
            else { }
        }
    }
}
