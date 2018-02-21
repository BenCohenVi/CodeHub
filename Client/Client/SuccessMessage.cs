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
    public partial class SuccessMessage : UserControl
    {
        private string Message = "None";
        public SuccessMessage()
        {
            InitializeComponent();
        }

        private void SuccessMessage_Load(object sender, EventArgs e)
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
