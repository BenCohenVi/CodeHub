namespace Client
{
    partial class RequestTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestTab));
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            this.RequestList = new System.Windows.Forms.ListBox();
            this.acceptBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.declineBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.SuspendLayout();
            // 
            // RequestList
            // 
            this.RequestList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.RequestList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuTransition1.SetDecoration(this.RequestList, BunifuAnimatorNS.DecorationType.None);
            this.RequestList.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.RequestList.FormattingEnabled = true;
            this.RequestList.ItemHeight = 25;
            this.RequestList.Location = new System.Drawing.Point(37, 33);
            this.RequestList.Name = "RequestList";
            this.RequestList.Size = new System.Drawing.Size(427, 425);
            this.RequestList.TabIndex = 0;
            // 
            // acceptBtn
            // 
            this.acceptBtn.ActiveBorderThickness = 1;
            this.acceptBtn.ActiveCornerRadius = 5;
            this.acceptBtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(154)))));
            this.acceptBtn.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.acceptBtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(154)))));
            this.acceptBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.acceptBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("acceptBtn.BackgroundImage")));
            this.acceptBtn.ButtonText = "Accept";
            this.acceptBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.acceptBtn, BunifuAnimatorNS.DecorationType.None);
            this.acceptBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.acceptBtn.IdleBorderThickness = 1;
            this.acceptBtn.IdleCornerRadius = 5;
            this.acceptBtn.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(154)))));
            this.acceptBtn.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.acceptBtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.acceptBtn.Location = new System.Drawing.Point(595, 33);
            this.acceptBtn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(199, 61);
            this.acceptBtn.TabIndex = 1;
            this.acceptBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // declineBtn
            // 
            this.declineBtn.ActiveBorderThickness = 1;
            this.declineBtn.ActiveCornerRadius = 5;
            this.declineBtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(23)))), ((int)(((byte)(58)))));
            this.declineBtn.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.declineBtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(23)))), ((int)(((byte)(58)))));
            this.declineBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.declineBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("declineBtn.BackgroundImage")));
            this.declineBtn.ButtonText = "Decline";
            this.declineBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.declineBtn, BunifuAnimatorNS.DecorationType.None);
            this.declineBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.declineBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.declineBtn.IdleBorderThickness = 1;
            this.declineBtn.IdleCornerRadius = 5;
            this.declineBtn.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(23)))), ((int)(((byte)(58)))));
            this.declineBtn.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.declineBtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.declineBtn.Location = new System.Drawing.Point(595, 151);
            this.declineBtn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.declineBtn.Name = "declineBtn";
            this.declineBtn.Size = new System.Drawing.Size(199, 61);
            this.declineBtn.TabIndex = 2;
            this.declineBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.bunifuTransition1.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.bunifuTransition1.DefaultAnimation = animation3;
            this.bunifuTransition1.Interval = 3;
            // 
            // RequestTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.declineBtn);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.RequestList);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Name = "RequestTab";
            this.Size = new System.Drawing.Size(938, 494);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox RequestList;
        private Bunifu.Framework.UI.BunifuThinButton2 acceptBtn;
        private Bunifu.Framework.UI.BunifuThinButton2 declineBtn;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
    }
}
