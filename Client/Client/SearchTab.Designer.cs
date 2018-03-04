namespace Client
{
    partial class SearchTab
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
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchTab));
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.userBox = new Bunifu.Framework.UI.BunifuTextbox();
            this.searchBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorMessage1 = new Client.ErrorMessage();
            this.successMessage1 = new Client.SuccessMessage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.bunifuTransition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.bunifuTransition1.DefaultAnimation = animation1;
            this.bunifuTransition1.Interval = 3;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(119, 67);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(116, 25);
            this.bunifuCustomLabel1.TabIndex = 53;
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
            this.userBox.Location = new System.Drawing.Point(168, 209);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(461, 42);
            this.userBox.TabIndex = 56;
            this.userBox.text = "";
            // 
            // searchBtn
            // 
            this.searchBtn.ActiveBorderThickness = 1;
            this.searchBtn.ActiveCornerRadius = 5;
            this.searchBtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(252)))));
            this.searchBtn.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.searchBtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(252)))));
            this.searchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.searchBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchBtn.BackgroundImage")));
            this.searchBtn.ButtonText = "Search User";
            this.searchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.searchBtn, BunifuAnimatorNS.DecorationType.None);
            this.searchBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.searchBtn.IdleBorderThickness = 1;
            this.searchBtn.IdleCornerRadius = 5;
            this.searchBtn.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(252)))));
            this.searchBtn.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.searchBtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.searchBtn.Location = new System.Drawing.Point(637, 206);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(5);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(194, 45);
            this.searchBtn.TabIndex = 57;
            this.searchBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.errorMessage1);
            this.panel1.Controls.Add(this.successMessage1);
            this.bunifuTransition1.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Location = new System.Drawing.Point(582, 446);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 52);
            this.panel1.TabIndex = 69;
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
            // panel2
            // 
            this.bunifuTransition1.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 498);
            this.panel2.TabIndex = 70;
            // 
            // SearchTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.panel2);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Name = "SearchTab";
            this.Size = new System.Drawing.Size(918, 498);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuTextbox userBox;
        private Bunifu.Framework.UI.BunifuThinButton2 searchBtn;
        private System.Windows.Forms.Panel panel1;
        private ErrorMessage errorMessage1;
        private SuccessMessage successMessage1;
        private System.Windows.Forms.Panel panel2;
    }
}
