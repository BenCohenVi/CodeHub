namespace Client
{
    partial class ProjectTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectTab));
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.projectList = new System.Windows.Forms.ListBox();
            this.versionList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.deleteProjectBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.newProjectBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.downloadBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.uploadBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.branchBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.openFileDialogU = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogU = new System.Windows.Forms.FolderBrowserDialog();
            this.errorMessage1 = new Client.ErrorMessage();
            this.successMessage1 = new Client.SuccessMessage();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deleteProjectBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newProjectBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uploadBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.label8, BunifuAnimatorNS.DecorationType.None);
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.label8.Location = new System.Drawing.Point(773, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 21);
            this.label8.TabIndex = 63;
            this.label8.Text = "Delete Project";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.label3, BunifuAnimatorNS.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.label3.Location = new System.Drawing.Point(604, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 61;
            this.label3.Text = "New Project";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.label6, BunifuAnimatorNS.DecorationType.None);
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.label6.Location = new System.Drawing.Point(433, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 21);
            this.label6.TabIndex = 59;
            this.label6.Text = "Download";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.label7, BunifuAnimatorNS.DecorationType.None);
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.label7.Location = new System.Drawing.Point(443, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 21);
            this.label7.TabIndex = 57;
            this.label7.Text = "Update";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.label4, BunifuAnimatorNS.DecorationType.None);
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(604, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 55;
            this.label4.Text = "New Branch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(59, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 50;
            this.label1.Text = "PROJECTS";
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
            // projectList
            // 
            this.projectList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.projectList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuTransition1.SetDecoration(this.projectList, BunifuAnimatorNS.DecorationType.None);
            this.projectList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.projectList.FormattingEnabled = true;
            this.projectList.ItemHeight = 21;
            this.projectList.Location = new System.Drawing.Point(64, 66);
            this.projectList.Name = "projectList";
            this.projectList.Size = new System.Drawing.Size(160, 378);
            this.projectList.TabIndex = 64;
            this.projectList.SelectedIndexChanged += new System.EventHandler(this.projectList_SelectedIndexChanged);
            // 
            // versionList
            // 
            this.versionList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.versionList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuTransition1.SetDecoration(this.versionList, BunifuAnimatorNS.DecorationType.None);
            this.versionList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.versionList.FormattingEnabled = true;
            this.versionList.ItemHeight = 21;
            this.versionList.Location = new System.Drawing.Point(183, 66);
            this.versionList.Name = "versionList";
            this.versionList.Size = new System.Drawing.Size(160, 378);
            this.versionList.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.label2, BunifuAnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(178, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 66;
            this.label2.Text = "VERSIONS";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.errorMessage1);
            this.panel1.Controls.Add(this.successMessage1);
            this.bunifuTransition1.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Location = new System.Drawing.Point(602, 442);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 52);
            this.panel1.TabIndex = 67;
            // 
            // deleteProjectBtn
            // 
            this.deleteProjectBtn.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.deleteProjectBtn, BunifuAnimatorNS.DecorationType.None);
            this.deleteProjectBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteProjectBtn.Image")));
            this.deleteProjectBtn.ImageActive = null;
            this.deleteProjectBtn.Location = new System.Drawing.Point(777, 85);
            this.deleteProjectBtn.Name = "deleteProjectBtn";
            this.deleteProjectBtn.Size = new System.Drawing.Size(96, 96);
            this.deleteProjectBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.deleteProjectBtn.TabIndex = 62;
            this.deleteProjectBtn.TabStop = false;
            this.deleteProjectBtn.Zoom = 10;
            this.deleteProjectBtn.Click += new System.EventHandler(this.deleteProjectBtn_Click);
            // 
            // newProjectBtn
            // 
            this.newProjectBtn.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.newProjectBtn, BunifuAnimatorNS.DecorationType.None);
            this.newProjectBtn.Image = global::Client.Properties.Resources.New;
            this.newProjectBtn.ImageActive = null;
            this.newProjectBtn.Location = new System.Drawing.Point(602, 241);
            this.newProjectBtn.Name = "newProjectBtn";
            this.newProjectBtn.Size = new System.Drawing.Size(96, 96);
            this.newProjectBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.newProjectBtn.TabIndex = 60;
            this.newProjectBtn.TabStop = false;
            this.newProjectBtn.Zoom = 10;
            this.newProjectBtn.Click += new System.EventHandler(this.newProjectBtn_Click);
            // 
            // downloadBtn
            // 
            this.downloadBtn.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.downloadBtn, BunifuAnimatorNS.DecorationType.None);
            this.downloadBtn.Image = ((System.Drawing.Image)(resources.GetObject("downloadBtn.Image")));
            this.downloadBtn.ImageActive = null;
            this.downloadBtn.Location = new System.Drawing.Point(427, 241);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(96, 96);
            this.downloadBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.downloadBtn.TabIndex = 58;
            this.downloadBtn.TabStop = false;
            this.downloadBtn.Zoom = 10;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // uploadBtn
            // 
            this.uploadBtn.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.uploadBtn, BunifuAnimatorNS.DecorationType.None);
            this.uploadBtn.Image = global::Client.Properties.Resources.Upload;
            this.uploadBtn.ImageActive = null;
            this.uploadBtn.Location = new System.Drawing.Point(427, 85);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(96, 96);
            this.uploadBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.uploadBtn.TabIndex = 56;
            this.uploadBtn.TabStop = false;
            this.uploadBtn.Zoom = 10;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // branchBtn
            // 
            this.branchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuTransition1.SetDecoration(this.branchBtn, BunifuAnimatorNS.DecorationType.None);
            this.branchBtn.Image = global::Client.Properties.Resources.BranchNew;
            this.branchBtn.ImageActive = null;
            this.branchBtn.Location = new System.Drawing.Point(602, 85);
            this.branchBtn.Name = "branchBtn";
            this.branchBtn.Size = new System.Drawing.Size(96, 96);
            this.branchBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.branchBtn.TabIndex = 54;
            this.branchBtn.TabStop = false;
            this.branchBtn.Zoom = 10;
            this.branchBtn.Click += new System.EventHandler(this.branchBtn_Click);
            // 
            // openFileDialogU
            // 
            this.openFileDialogU.FileName = "openFileDialog1";
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
            // ProjectTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.versionList);
            this.Controls.Add(this.projectList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.deleteProjectBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newProjectBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.branchBtn);
            this.Controls.Add(this.label1);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Name = "ProjectTab";
            this.Size = new System.Drawing.Size(938, 494);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deleteProjectBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newProjectBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uploadBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private Bunifu.Framework.UI.BunifuImageButton deleteProjectBtn;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuImageButton newProjectBtn;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuImageButton downloadBtn;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuImageButton uploadBtn;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuImageButton branchBtn;
        private System.Windows.Forms.Label label1;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private System.Windows.Forms.ListBox projectList;
        private System.Windows.Forms.OpenFileDialog openFileDialogU;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogU;
        private System.Windows.Forms.ListBox versionList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private SuccessMessage successMessage1;
        private ErrorMessage errorMessage1;
    }
}
