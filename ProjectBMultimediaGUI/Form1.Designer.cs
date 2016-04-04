namespace ProjectBMultimediaGUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMS = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostsLB = new System.Windows.Forms.ListBox();
            this.playpauseBUT = new System.Windows.Forms.Button();
            this.butIML = new System.Windows.Forms.ImageList(this.components);
            this.stopBUT = new System.Windows.Forms.Button();
            this.availclientsLBL = new System.Windows.Forms.Label();
            this.filepathTB = new System.Windows.Forms.TextBox();
            this.browseBUT = new System.Windows.Forms.Button();
            this.sendwavBUT = new System.Windows.Forms.Button();
            this.filesendPB = new System.Windows.Forms.ProgressBar();
            this.dataavailLBL = new System.Windows.Forms.Label();
            this.mainMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMS
            // 
            this.mainMS.BackColor = System.Drawing.Color.White;
            this.mainMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMS.Location = new System.Drawing.Point(0, 0);
            this.mainMS.Name = "mainMS";
            this.mainMS.Size = new System.Drawing.Size(178, 24);
            this.mainMS.TabIndex = 0;
            this.mainMS.Text = "menuStrip1";
            this.mainMS.Paint += new System.Windows.Forms.PaintEventHandler(this.mainMS_Paint);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // hostsLB
            // 
            this.hostsLB.FormattingEnabled = true;
            this.hostsLB.Location = new System.Drawing.Point(12, 42);
            this.hostsLB.Name = "hostsLB";
            this.hostsLB.Size = new System.Drawing.Size(150, 95);
            this.hostsLB.TabIndex = 1;
            // 
            // playpauseBUT
            // 
            this.playpauseBUT.BackColor = System.Drawing.Color.Transparent;
            this.playpauseBUT.FlatAppearance.BorderSize = 0;
            this.playpauseBUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playpauseBUT.ImageIndex = 0;
            this.playpauseBUT.ImageList = this.butIML;
            this.playpauseBUT.Location = new System.Drawing.Point(12, 224);
            this.playpauseBUT.Name = "playpauseBUT";
            this.playpauseBUT.Size = new System.Drawing.Size(65, 65);
            this.playpauseBUT.TabIndex = 2;
            this.playpauseBUT.UseVisualStyleBackColor = false;
            this.playpauseBUT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.playpauseBUT_MouseClick);
            // 
            // butIML
            // 
            this.butIML.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("butIML.ImageStream")));
            this.butIML.TransparentColor = System.Drawing.Color.Transparent;
            this.butIML.Images.SetKeyName(0, "playbutton.png");
            this.butIML.Images.SetKeyName(1, "pausebutton.png");
            this.butIML.Images.SetKeyName(2, "stopbutton.png");
            // 
            // stopBUT
            // 
            this.stopBUT.BackColor = System.Drawing.Color.Transparent;
            this.stopBUT.FlatAppearance.BorderSize = 0;
            this.stopBUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopBUT.ImageIndex = 2;
            this.stopBUT.ImageList = this.butIML;
            this.stopBUT.Location = new System.Drawing.Point(97, 224);
            this.stopBUT.Name = "stopBUT";
            this.stopBUT.Size = new System.Drawing.Size(65, 65);
            this.stopBUT.TabIndex = 2;
            this.stopBUT.UseVisualStyleBackColor = false;
            this.stopBUT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.stopBUT_MouseClick);
            // 
            // availclientsLBL
            // 
            this.availclientsLBL.AutoSize = true;
            this.availclientsLBL.Location = new System.Drawing.Point(12, 26);
            this.availclientsLBL.Name = "availclientsLBL";
            this.availclientsLBL.Size = new System.Drawing.Size(84, 13);
            this.availclientsLBL.TabIndex = 3;
            this.availclientsLBL.Text = "Available Clients";
            // 
            // filepathTB
            // 
            this.filepathTB.Location = new System.Drawing.Point(12, 143);
            this.filepathTB.Name = "filepathTB";
            this.filepathTB.Size = new System.Drawing.Size(150, 20);
            this.filepathTB.TabIndex = 4;
            // 
            // browseBUT
            // 
            this.browseBUT.Location = new System.Drawing.Point(12, 169);
            this.browseBUT.Name = "browseBUT";
            this.browseBUT.Size = new System.Drawing.Size(75, 20);
            this.browseBUT.TabIndex = 5;
            this.browseBUT.Text = "Browse";
            this.browseBUT.UseVisualStyleBackColor = true;
            this.browseBUT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.browseBUT_MouseClick);
            // 
            // sendwavBUT
            // 
            this.sendwavBUT.Location = new System.Drawing.Point(87, 169);
            this.sendwavBUT.Name = "sendwavBUT";
            this.sendwavBUT.Size = new System.Drawing.Size(75, 20);
            this.sendwavBUT.TabIndex = 6;
            this.sendwavBUT.Text = "Send";
            this.sendwavBUT.UseVisualStyleBackColor = true;
            this.sendwavBUT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sendwavBUT_MouseClick);
            // 
            // filesendPB
            // 
            this.filesendPB.Location = new System.Drawing.Point(12, 195);
            this.filesendPB.Name = "filesendPB";
            this.filesendPB.Size = new System.Drawing.Size(150, 23);
            this.filesendPB.TabIndex = 7;
            this.filesendPB.UseWaitCursor = true;
            // 
            // dataavailLBL
            // 
            this.dataavailLBL.AutoSize = true;
            this.dataavailLBL.Location = new System.Drawing.Point(12, 296);
            this.dataavailLBL.Name = "dataavailLBL";
            this.dataavailLBL.Size = new System.Drawing.Size(89, 13);
            this.dataavailLBL.TabIndex = 8;
            this.dataavailLBL.Text = "Data Unavailable";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 323);
            this.ControlBox = false;
            this.Controls.Add(this.dataavailLBL);
            this.Controls.Add(this.filesendPB);
            this.Controls.Add(this.sendwavBUT);
            this.Controls.Add(this.browseBUT);
            this.Controls.Add(this.filepathTB);
            this.Controls.Add(this.availclientsLBL);
            this.Controls.Add(this.stopBUT);
            this.Controls.Add(this.playpauseBUT);
            this.Controls.Add(this.hostsLB);
            this.Controls.Add(this.mainMS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMS;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Multimedia App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMS.ResumeLayout(false);
            this.mainMS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMS;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ListBox hostsLB;
        private System.Windows.Forms.Button playpauseBUT;
        private System.Windows.Forms.ImageList butIML;
        private System.Windows.Forms.Button stopBUT;
        private System.Windows.Forms.Label availclientsLBL;
        private System.Windows.Forms.TextBox filepathTB;
        private System.Windows.Forms.Button browseBUT;
        private System.Windows.Forms.Button sendwavBUT;
        private System.Windows.Forms.ProgressBar filesendPB;
        private System.Windows.Forms.Label dataavailLBL;
    }
}

