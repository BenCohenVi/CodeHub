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
    public partial class ErrorMessage : UserControl
    {
        private string Message = "None";
        public ErrorMessage()
        {
            InitializeComponent();
        }

        private void ErrorMessage_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = this.Message;
        }

        public void Set_Message(string Message)
        {
            this.Message = Message;
            MessageLabel.Text = this.Message;
        }

        private void TimeoutTimer_Tick(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
