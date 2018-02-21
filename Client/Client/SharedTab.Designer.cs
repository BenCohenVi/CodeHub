namespace Client
{
    partial class SharedTab
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
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharedTab));
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.userBox = new Bunifu.Framework.UI.BunifuTextbox();
            this.shareBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.nameLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorMessage1 = new Client.ErrorMessage();
            this.successMessage1 = new Client.SuccessMessage();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 25);
            this.label1.TabIndex = 51;
            this.label1.Text = "SHARING PROJECT:";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(142, 191);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(116, 25);
            this.bunifuCustomLabel1.TabIndex = 52;
            this.bunifuCustomLabel1.Text = "Search User:";
            // 
            // userBox
            // 
            this.userBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.userBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userBox.BackgroundImage")));
            this.userBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuTransition1.SetDecoration(this.userBox, BunifuAnimatorNS.DecorationType.None);
            this.userBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.userBox.Icon = ((System.Drawing.Image)(resources.GetObject("userBox.Icon")));
            this.userBox.Location = new System.Drawing.Point(147, 257);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(354, 42);
            this.userBox.TabIndex = 54;
            this.userBox.text = "";
            // 
            // shareBtn
            // 
            this.shareBtn.ActiveBorderThickness = 1;
            this.shareBtn.ActiveCornerRadius = 5;
            this.shareBtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(252)))));
            this.shareBtn.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.shareBtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(252)))));
            this.shareBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.shareBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("shareBtn.BackgroundImage")));
            this.shareBtn.ButtonText = "Share Project";
            this.shareBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.shareBtn, BunifuAnimatorNS.DecorationType.None);
            this.shareBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shareBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.shareBtn.IdleBorderThickness = 1;
            this.shareBtn.IdleCornerRadius = 5;
            this.shareBtn.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(252)))));
            this.shareBtn.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.shareBtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.shareBtn.Location = new System.Drawing.Point(582, 254);
            this.shareBtn.Margin = new System.Windows.Forms.Padding(5);
            this.shareBtn.Name = "shareBtn";
            this.shareBtn.Size = new System.Drawing.Size(194, 45);
            this.shareBtn.TabIndex = 55;
            this.shareBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shareBtn.Click += new System.EventHandler(this.shareBtn_Click);
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.bunifuTransition1.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.bunifuTransition1.DefaultAnimation = animation2;
            this.bunifuTransition1.Interval = 5;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.nameLabel, BunifuAnimatorNS.DecorationType.None);
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(142, 100);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(130, 25);
            this.nameLabel.TabIndex = 56;
            this.nameLabel.Text = "Project Name:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.errorMessage1);
            this.panel1.Controls.Add(this.successMessage1);
            this.bunifuTransition1.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Location = new System.Drawing.Point(602, 442);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 52);
            this.panel1.TabIndex = 68;
            // 
            // errorMessage1
            // 
            this.errorMessage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(23)))), ((int)(((byte)(58)))));
            this.bunifuTransition1.SetDecoration(this.errorMessage1, BunifuAnimatorNS.DecorationType.None);
            this.errorMessage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorMessage1.Location = new System.Drawing.Point(0, 0);
            this.errorMessage1.Name = "errorMessage1";
            this.errorMessage1.Size = new System.Drawing.Size(336, 52);
            this.errorMessage1.TabIndex = 1;
            // 
            // successMessage1
            // 
            this.successMessage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(154)))));
            this.bunifuTransition1.SetDecoration(this.successMessage1, BunifuAnimatorNS.DecorationType.None);
            this.successMessage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.successMessage1.Location = new System.Drawing.Point(0, 0);
            this.successMessage1.Name = "successMessage1";
            this.successMessage1.Size = new System.Drawing.Size(336, 52);
            this.successMessage1.TabIndex = 0;
            this.successMessage1.Visible = false;
            // 
            // SharedTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.shareBtn);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.label1);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Name = "SharedTab";
            this.Size = new System.Drawing.Size(938, 494);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuTextbox userBox;
        private Bunifu.Framework.UI.BunifuThinButton2 shareBtn;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private Bunifu.Framework.UI.BunifuCustomLabel nameLabel;
        private System.Windows.Forms.Panel panel1;
        private ErrorMessage errorMessage1;
        private SuccessMessage successMessage1;
    }
}
