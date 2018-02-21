namespace Client
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.mainLabel = new System.Windows.Forms.Label();
            this.minBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.cancelBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.projectTab1 = new Client.ProjectTab();
            this.commentsTab1 = new Client.CommentsTab();
            this.sharedTab1 = new Client.SharedTab();
            this.projectsTab = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.commentsTab = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.shareTab = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.seperatorLine = new Bunifu.Framework.UI.BunifuSeparator();
            this.nameLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton3 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelBtn)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(139)))), ((int)(((byte)(229)))));
            this.panel4.Controls.Add(this.mainLabel);
            this.panel4.Controls.Add(this.minBtn);
            this.panel4.Controls.Add(this.cancelBtn);
            this.bunifuTransition1.SetDecoration(this.panel4, BunifuAnimatorNS.DecorationType.None);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1197, 32);
            this.panel4.TabIndex = 19;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseDown);
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseMove);
            this.panel4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseUp);
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.mainLabel, BunifuAnimatorNS.DecorationType.None);
            this.mainLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.mainLabel.Location = new System.Drawing.Point(12, 7);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(75, 21);
            this.mainLabel.TabIndex = 19;
            this.mainLabel.Text = "CodeHub";
            // 
            // minBtn
            // 
            this.minBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(139)))), ((int)(((byte)(229)))));
            this.bunifuTransition1.SetDecoration(this.minBtn, BunifuAnimatorNS.DecorationType.None);
            this.minBtn.Image = global::Client.Properties.Resources.Minimize;
            this.minBtn.ImageActive = null;
            this.minBtn.Location = new System.Drawing.Point(1127, 3);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(25, 25);
            this.minBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minBtn.TabIndex = 17;
            this.minBtn.TabStop = false;
            this.minBtn.Zoom = 10;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(139)))), ((int)(((byte)(229)))));
            this.bunifuTransition1.SetDecoration(this.cancelBtn, BunifuAnimatorNS.DecorationType.None);
            this.cancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.Image")));
            this.cancelBtn.ImageActive = null;
            this.cancelBtn.Location = new System.Drawing.Point(1158, 3);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(25, 25);
            this.cancelBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cancelBtn.TabIndex = 18;
            this.cancelBtn.TabStop = false;
            this.cancelBtn.Zoom = 10;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.projectTab1);
            this.panel2.Controls.Add(this.commentsTab1);
            this.panel2.Controls.Add(this.sharedTab1);
            this.bunifuTransition1.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Location = new System.Drawing.Point(255, 198);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 498);
            this.panel2.TabIndex = 1;
            // 
            // projectTab1
            // 
            this.projectTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.projectTab1, BunifuAnimatorNS.DecorationType.None);
            this.projectTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectTab1.Location = new System.Drawing.Point(0, 0);
            this.projectTab1.Name = "projectTab1";
            this.projectTab1.Size = new System.Drawing.Size(918, 498);
            this.projectTab1.TabIndex = 0;
            // 
            // commentsTab1
            // 
            this.commentsTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.commentsTab1, BunifuAnimatorNS.DecorationType.None);
            this.commentsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentsTab1.Location = new System.Drawing.Point(0, 0);
            this.commentsTab1.Name = "commentsTab1";
            this.commentsTab1.Size = new System.Drawing.Size(918, 498);
            this.commentsTab1.TabIndex = 1;
            // 
            // sharedTab1
            // 
            this.sharedTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.sharedTab1, BunifuAnimatorNS.DecorationType.None);
            this.sharedTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sharedTab1.Location = new System.Drawing.Point(0, 0);
            this.sharedTab1.Name = "sharedTab1";
            this.sharedTab1.Size = new System.Drawing.Size(918, 498);
            this.sharedTab1.TabIndex = 2;
            // 
            // projectsTab
            // 
            this.projectsTab.AutoSize = true;
            this.projectsTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.projectsTab, BunifuAnimatorNS.DecorationType.None);
            this.projectsTab.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectsTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.projectsTab.Location = new System.Drawing.Point(273, 161);
            this.projectsTab.Name = "projectsTab";
            this.projectsTab.Size = new System.Drawing.Size(79, 18);
            this.projectsTab.TabIndex = 2;
            this.projectsTab.Text = "PROJECTS";
            this.projectsTab.Click += new System.EventHandler(this.projectsTab_Click);
            // 
            // commentsTab
            // 
            this.commentsTab.AutoSize = true;
            this.commentsTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.commentsTab, BunifuAnimatorNS.DecorationType.None);
            this.commentsTab.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentsTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.commentsTab.Location = new System.Drawing.Point(398, 161);
            this.commentsTab.Name = "commentsTab";
            this.commentsTab.Size = new System.Drawing.Size(97, 18);
            this.commentsTab.TabIndex = 3;
            this.commentsTab.Text = "DISCUSSION";
            this.commentsTab.Click += new System.EventHandler(this.commentsTab_Click);
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
            // 
            // shareTab
            // 
            this.shareTab.AutoSize = true;
            this.shareTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.shareTab, BunifuAnimatorNS.DecorationType.None);
            this.shareTab.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shareTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.shareTab.Location = new System.Drawing.Point(541, 161);
            this.shareTab.Name = "shareTab";
            this.shareTab.Size = new System.Drawing.Size(54, 18);
            this.shareTab.TabIndex = 5;
            this.shareTab.Text = "SHARE";
            this.shareTab.Click += new System.EventHandler(this.shareTab_Click);
            // 
            // seperatorLine
            // 
            this.seperatorLine.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.seperatorLine, BunifuAnimatorNS.DecorationType.None);
            this.seperatorLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(252)))));
            this.seperatorLine.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(252)))));
            this.seperatorLine.LineThickness = 3;
            this.seperatorLine.Location = new System.Drawing.Point(267, 182);
            this.seperatorLine.Name = "seperatorLine";
            this.seperatorLine.Size = new System.Drawing.Size(85, 10);
            this.seperatorLine.TabIndex = 4;
            this.seperatorLine.Transparency = 255;
            this.seperatorLine.Vertical = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.nameLabel, BunifuAnimatorNS.DecorationType.None);
            this.nameLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.nameLabel.Location = new System.Drawing.Point(64, 51);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(103, 23);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Username";
            // 
            // pictureBox2
            // 
            this.bunifuTransition1.SetDecoration(this.pictureBox2, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox2.Image = global::Client.Properties.Resources.MaleIcon;
            this.pictureBox2.Location = new System.Drawing.Point(3, 32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 55);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel3.Controls.Add(this.bunifuFlatButton1);
            this.panel3.Controls.Add(this.bunifuFlatButton3);
            this.panel3.Controls.Add(this.bunifuFlatButton2);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.nameLabel);
            this.panel3.Controls.Add(this.bunifuSeparator1);
            this.bunifuTransition1.SetDecoration(this.panel3, BunifuAnimatorNS.DecorationType.None);
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(252, 684);
            this.panel3.TabIndex = 0;
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "My Profile";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.bunifuFlatButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(6, 134);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(246, 67);
            this.bunifuFlatButton1.TabIndex = 21;
            this.bunifuFlatButton1.Text = "My Profile";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // bunifuFlatButton3
            // 
            this.bunifuFlatButton3.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuFlatButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton3.BorderRadius = 0;
            this.bunifuFlatButton3.ButtonText = "Logout";
            this.bunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.bunifuFlatButton3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuFlatButton3.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.Iconimage = global::Client.Properties.Resources.Logout;
            this.bunifuFlatButton3.Iconimage_right = null;
            this.bunifuFlatButton3.Iconimage_right_Selected = null;
            this.bunifuFlatButton3.Iconimage_Selected = null;
            this.bunifuFlatButton3.IconMarginLeft = 0;
            this.bunifuFlatButton3.IconMarginRight = 0;
            this.bunifuFlatButton3.IconRightVisible = true;
            this.bunifuFlatButton3.IconRightZoom = 0D;
            this.bunifuFlatButton3.IconVisible = true;
            this.bunifuFlatButton3.IconZoom = 90D;
            this.bunifuFlatButton3.IsTab = false;
            this.bunifuFlatButton3.Location = new System.Drawing.Point(3, 280);
            this.bunifuFlatButton3.Name = "bunifuFlatButton3";
            this.bunifuFlatButton3.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuFlatButton3.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.bunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.bunifuFlatButton3.selected = false;
            this.bunifuFlatButton3.Size = new System.Drawing.Size(246, 67);
            this.bunifuFlatButton3.TabIndex = 23;
            this.bunifuFlatButton3.Text = "Logout";
            this.bunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton3.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.bunifuFlatButton3.TextFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton3.Click += new System.EventHandler(this.bunifuFlatButton3_Click);
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 0;
            this.bunifuFlatButton2.ButtonText = "Search Users";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.bunifuFlatButton2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton2.Iconimage")));
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 90D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(3, 207);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(246, 67);
            this.bunifuFlatButton2.TabIndex = 22;
            this.bunifuFlatButton2.Text = "Search Users";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.bunifuSeparator1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.bunifuSeparator1.LineThickness = 3;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 93);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(249, 35);
            this.bunifuSeparator1.TabIndex = 24;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(24, 75);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(168, 45);
            this.bunifuCustomLabel2.TabIndex = 2;
            this.bunifuCustomLabel2.Text = "My Profile";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(252)))));
            this.panel1.BackgroundImage = global::Client.Properties.Resources.Background;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.bunifuCustomLabel2);
            this.bunifuTransition1.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Location = new System.Drawing.Point(235, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 152);
            this.panel1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1185, 708);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.seperatorLine);
            this.Controls.Add(this.shareTab);
            this.Controls.Add(this.commentsTab);
            this.Controls.Add(this.projectsTab);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelBtn)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel commentsTab;
        private Bunifu.Framework.UI.BunifuCustomLabel projectsTab;
        private ProjectTab projectTab1;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private CommentsTab commentsTab1;
        private Bunifu.Framework.UI.BunifuCustomLabel shareTab;
        private SharedTab sharedTab1;
        private Bunifu.Framework.UI.BunifuSeparator seperatorLine;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuCustomLabel nameLabel;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton3;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuImageButton cancelBtn;
        private Bunifu.Framework.UI.BunifuImageButton minBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label mainLabel;
    }
}