namespace Client
{
    partial class CommentsTab
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
            BunifuAnimatorNS.Animation animation6 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentsTab));
            this.proLabel = new System.Windows.Forms.Label();
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.previewBox = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.commentBox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.commentBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.commentsList = new System.Windows.Forms.ListBox();
            this.verBox = new System.Windows.Forms.ComboBox();
            this.pictureView = new System.Windows.Forms.PictureBox();
            this.reloadBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.statusLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reloadBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // proLabel
            // 
            this.proLabel.AutoSize = true;
            this.proLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.proLabel, BunifuAnimatorNS.DecorationType.None);
            this.proLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.proLabel.Location = new System.Drawing.Point(17, 30);
            this.proLabel.Name = "proLabel";
            this.proLabel.Size = new System.Drawing.Size(189, 25);
            this.proLabel.TabIndex = 51;
            this.proLabel.Text = "SELECTED PROJECT:";
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
            this.bunifuTransition1.Cursor = null;
            animation6.AnimateOnlyDifferences = true;
            animation6.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.BlindCoeff")));
            animation6.LeafCoeff = 0F;
            animation6.MaxTime = 1F;
            animation6.MinTime = 0F;
            animation6.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.MosaicCoeff")));
            animation6.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation6.MosaicShift")));
            animation6.MosaicSize = 0;
            animation6.Padding = new System.Windows.Forms.Padding(0);
            animation6.RotateCoeff = 0F;
            animation6.RotateLimit = 0F;
            animation6.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.ScaleCoeff")));
            animation6.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.SlideCoeff")));
            animation6.TimeCoeff = 0F;
            animation6.TransparencyCoeff = 0F;
            this.bunifuTransition1.DefaultAnimation = animation6;
            this.bunifuTransition1.Interval = 3;
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.previewBox.BorderColor = System.Drawing.Color.SeaGreen;
            this.bunifuTransition1.SetDecoration(this.previewBox, BunifuAnimatorNS.DecorationType.None);
            this.previewBox.Font = new System.Drawing.Font("Fira Code", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.previewBox.Location = new System.Drawing.Point(521, 71);
            this.previewBox.Multiline = true;
            this.previewBox.Name = "previewBox";
            this.previewBox.ReadOnly = true;
            this.previewBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.previewBox.Size = new System.Drawing.Size(368, 413);
            this.previewBox.TabIndex = 52;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(517, 38);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(110, 21);
            this.bunifuCustomLabel1.TabIndex = 53;
            this.bunifuCustomLabel1.Text = "Select Version:";
            // 
            // commentBox
            // 
            this.commentBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.commentBox, BunifuAnimatorNS.DecorationType.None);
            this.commentBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.commentBox.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.commentBox.HintText = "";
            this.commentBox.isPassword = false;
            this.commentBox.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(87)))), ((int)(((byte)(167)))));
            this.commentBox.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.commentBox.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(87)))), ((int)(((byte)(167)))));
            this.commentBox.LineThickness = 2;
            this.commentBox.Location = new System.Drawing.Point(22, 71);
            this.commentBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.commentBox.Name = "commentBox";
            this.commentBox.Size = new System.Drawing.Size(441, 39);
            this.commentBox.TabIndex = 55;
            this.commentBox.Text = "Add A Comment...";
            this.commentBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.commentBox.Enter += new System.EventHandler(this.commentBox_Enter);
            this.commentBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commentBox_KeyDown);
            // 
            // commentBtn
            // 
            this.commentBtn.ActiveBorderThickness = 1;
            this.commentBtn.ActiveCornerRadius = 1;
            this.commentBtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(230)))));
            this.commentBtn.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.commentBtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(230)))));
            this.commentBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.commentBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("commentBtn.BackgroundImage")));
            this.commentBtn.ButtonText = "COMMENT";
            this.commentBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.commentBtn, BunifuAnimatorNS.DecorationType.None);
            this.commentBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.commentBtn.IdleBorderThickness = 1;
            this.commentBtn.IdleCornerRadius = 1;
            this.commentBtn.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(230)))));
            this.commentBtn.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.commentBtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.commentBtn.Location = new System.Drawing.Point(342, 121);
            this.commentBtn.Margin = new System.Windows.Forms.Padding(6);
            this.commentBtn.Name = "commentBtn";
            this.commentBtn.Size = new System.Drawing.Size(121, 44);
            this.commentBtn.TabIndex = 56;
            this.commentBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.commentBtn.Click += new System.EventHandler(this.commentBtn_Click);
            // 
            // commentsList
            // 
            this.commentsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.commentsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuTransition1.SetDecoration(this.commentsList, BunifuAnimatorNS.DecorationType.None);
            this.commentsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.commentsList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.commentsList.FormattingEnabled = true;
            this.commentsList.ItemHeight = 21;
            this.commentsList.Location = new System.Drawing.Point(22, 172);
            this.commentsList.Name = "commentsList";
            this.commentsList.Size = new System.Drawing.Size(441, 294);
            this.commentsList.TabIndex = 57;
            this.commentsList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.commentsList_DrawItem);
            // 
            // verBox
            // 
            this.verBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.verBox, BunifuAnimatorNS.DecorationType.None);
            this.verBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.verBox.FormattingEnabled = true;
            this.verBox.Location = new System.Drawing.Point(644, 35);
            this.verBox.Name = "verBox";
            this.verBox.Size = new System.Drawing.Size(134, 29);
            this.verBox.TabIndex = 58;
            this.verBox.SelectedIndexChanged += new System.EventHandler(this.verBox_SelectedIndexChanged);
            // 
            // pictureView
            // 
            this.bunifuTransition1.SetDecoration(this.pictureView, BunifuAnimatorNS.DecorationType.None);
            this.pictureView.Location = new System.Drawing.Point(521, 71);
            this.pictureView.Name = "pictureView";
            this.pictureView.Size = new System.Drawing.Size(368, 413);
            this.pictureView.TabIndex = 59;
            this.pictureView.TabStop = false;
            this.pictureView.MouseHover += new System.EventHandler(this.pictureView_MouseHover);
            // 
            // reloadBtn
            // 
            this.reloadBtn.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.reloadBtn, BunifuAnimatorNS.DecorationType.None);
            this.reloadBtn.Image = global::Client.Properties.Resources.Refresh;
            this.reloadBtn.ImageActive = null;
            this.reloadBtn.Location = new System.Drawing.Point(890, 3);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(25, 25);
            this.reloadBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.reloadBtn.TabIndex = 69;
            this.reloadBtn.TabStop = false;
            this.reloadBtn.Zoom = 10;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.statusLabel, BunifuAnimatorNS.DecorationType.None);
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(23)))), ((int)(((byte)(58)))));
            this.statusLabel.Location = new System.Drawing.Point(19, 55);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(43, 17);
            this.statusLabel.TabIndex = 70;
            this.statusLabel.Text = "Status";
            this.statusLabel.Visible = false;
            // 
            // statusTimer
            // 
            this.statusTimer.Enabled = true;
            this.statusTimer.Interval = 3000;
            this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
            // 
            // CommentsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.reloadBtn);
            this.Controls.Add(this.pictureView);
            this.Controls.Add(this.verBox);
            this.Controls.Add(this.commentsList);
            this.Controls.Add(this.commentBtn);
            this.Controls.Add(this.commentBox);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.proLabel);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Name = "CommentsTab";
            this.Size = new System.Drawing.Size(918, 498);
            ((System.ComponentModel.ISupportInitialize)(this.pictureView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reloadBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label proLabel;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox previewBox;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox commentBox;
        private Bunifu.Framework.UI.BunifuThinButton2 commentBtn;
        private System.Windows.Forms.ListBox commentsList;
        private System.Windows.Forms.ComboBox verBox;
        private System.Windows.Forms.PictureBox pictureView;
        private Bunifu.Framework.UI.BunifuImageButton reloadBtn;
        private Bunifu.Framework.UI.BunifuCustomLabel statusLabel;
        private System.Windows.Forms.Timer statusTimer;
    }
}
