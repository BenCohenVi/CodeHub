namespace Client
{
    partial class NewProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.exitBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.minBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnameBox = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.pathBox = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.chBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.createBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.cancelBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minBtn)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.bunifuCustomLabel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(252)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 97);
            this.panel1.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(139)))), ((int)(((byte)(229)))));
            this.panel3.Controls.Add(this.exitBtn);
            this.panel3.Controls.Add(this.minBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(545, 32);
            this.panel3.TabIndex = 18;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseUp);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(139)))), ((int)(((byte)(229)))));
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.ImageActive = null;
            this.exitBtn.Location = new System.Drawing.Point(517, 4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(25, 25);
            this.exitBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitBtn.TabIndex = 15;
            this.exitBtn.TabStop = false;
            this.exitBtn.Zoom = 10;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // minBtn
            // 
            this.minBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(139)))), ((int)(((byte)(229)))));
            this.minBtn.Image = global::Client.Properties.Resources.Minimize;
            this.minBtn.ImageActive = null;
            this.minBtn.Location = new System.Drawing.Point(486, 4);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(25, 25);
            this.minBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minBtn.TabIndex = 16;
            this.minBtn.TabStop = false;
            this.minBtn.Zoom = 10;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(40, 35);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(323, 45);
            this.bunifuCustomLabel2.TabIndex = 1;
            this.bunifuCustomLabel2.Text = "Create A New Project";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(44, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name";
            // 
            // pnameBox
            // 
            this.pnameBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.pnameBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnameBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.pnameBox.Location = new System.Drawing.Point(48, 156);
            this.pnameBox.Name = "pnameBox";
            this.pnameBox.Size = new System.Drawing.Size(447, 29);
            this.pnameBox.TabIndex = 13;
            this.pnameBox.Text = "project name";
            this.pnameBox.Click += new System.EventHandler(this.pnameBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(45, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Local Path";
            // 
            // pathBox
            // 
            this.pathBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.pathBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.pathBox.Location = new System.Drawing.Point(49, 245);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(301, 29);
            this.pathBox.TabIndex = 15;
            // 
            // chBtn
            // 
            this.chBtn.ActiveBorderThickness = 1;
            this.chBtn.ActiveCornerRadius = 5;
            this.chBtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(230)))));
            this.chBtn.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.chBtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(230)))));
            this.chBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.chBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chBtn.BackgroundImage")));
            this.chBtn.ButtonText = "Choose";
            this.chBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.chBtn.IdleBorderThickness = 1;
            this.chBtn.IdleCornerRadius = 5;
            this.chBtn.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(230)))));
            this.chBtn.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.chBtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.chBtn.Location = new System.Drawing.Point(358, 237);
            this.chBtn.Margin = new System.Windows.Forms.Padding(5);
            this.chBtn.Name = "chBtn";
            this.chBtn.Size = new System.Drawing.Size(137, 45);
            this.chBtn.TabIndex = 16;
            this.chBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chBtn.Click += new System.EventHandler(this.chBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.ActiveBorderThickness = 1;
            this.createBtn.ActiveCornerRadius = 5;
            this.createBtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(230)))));
            this.createBtn.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.createBtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(230)))));
            this.createBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.createBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("createBtn.BackgroundImage")));
            this.createBtn.ButtonText = "Create Project";
            this.createBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.createBtn.IdleBorderThickness = 1;
            this.createBtn.IdleCornerRadius = 5;
            this.createBtn.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(230)))));
            this.createBtn.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.createBtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.createBtn.Location = new System.Drawing.Point(175, 320);
            this.createBtn.Margin = new System.Windows.Forms.Padding(5);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(155, 45);
            this.createBtn.TabIndex = 17;
            this.createBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.ActiveBorderThickness = 1;
            this.cancelBtn.ActiveCornerRadius = 5;
            this.cancelBtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cancelBtn.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.cancelBtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.cancelBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelBtn.BackgroundImage")));
            this.cancelBtn.ButtonText = "Cancel";
            this.cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.cancelBtn.IdleBorderThickness = 1;
            this.cancelBtn.IdleCornerRadius = 5;
            this.cancelBtn.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cancelBtn.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.cancelBtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.cancelBtn.Location = new System.Drawing.Point(340, 320);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(5);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(155, 45);
            this.cancelBtn.TabIndex = 18;
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.statusLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(545, 310);
            this.panel2.TabIndex = 19;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(23)))), ((int)(((byte)(58)))));
            this.statusLabel.Location = new System.Drawing.Point(45, 10);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(43, 17);
            this.statusLabel.TabIndex = 20;
            this.statusLabel.Text = "Status";
            this.statusLabel.Visible = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // statusTimer
            // 
            this.statusTimer.Enabled = true;
            this.statusTimer.Interval = 3000;
            this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
            // 
            // NewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(545, 405);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.chBtn);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Project";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minBtn)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuImageButton exitBtn;
        private Bunifu.Framework.UI.BunifuImageButton minBtn;
        private System.Windows.Forms.Label label1;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox pnameBox;
        private Bunifu.Framework.UI.BunifuThinButton2 chBtn;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox pathBox;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuThinButton2 createBtn;
        private Bunifu.Framework.UI.BunifuThinButton2 cancelBtn;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuCustomLabel statusLabel;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.Panel panel3;
    }
}