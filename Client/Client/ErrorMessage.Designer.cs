namespace Client
{
    partial class ErrorMessage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MessageLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.MessageLabel.Location = new System.Drawing.Point(0, 0);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(150, 24);
            this.MessageLabel.TabIndex = 3;
            this.MessageLabel.Text = "Error Message";
            // 
            // TimeoutTimer
            // 
            this.TimeoutTimer.Enabled = true;
            this.TimeoutTimer.Interval = 5000;
            this.TimeoutTimer.Tick += new System.EventHandler(this.TimeoutTimer_Tick);
            // 
            // ErrorMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(23)))), ((int)(((byte)(58)))));
            this.Controls.Add(this.MessageLabel);
            this.Name = "ErrorMessage";
            this.Size = new System.Drawing.Size(336, 52);
            this.Load += new System.EventHandler(this.ErrorMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel MessageLabel;
        private System.Windows.Forms.Timer TimeoutTimer;
    }
}
