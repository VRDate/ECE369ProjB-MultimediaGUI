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
            this.mainMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMS
            // 
            this.mainMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMS.Location = new System.Drawing.Point(0, 0);
            this.mainMS.Name = "mainMS";
            this.mainMS.Size = new System.Drawing.Size(676, 24);
            this.mainMS.TabIndex = 0;
            this.mainMS.Text = "menuStrip1";
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
            this.hostsLB.Location = new System.Drawing.Point(12, 27);
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
            this.playpauseBUT.Location = new System.Drawing.Point(12, 128);
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 482);
            this.Controls.Add(this.playpauseBUT);
            this.Controls.Add(this.hostsLB);
            this.Controls.Add(this.mainMS);
            this.MainMenuStrip = this.mainMS;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ECE 369 Project B -- Multimedia Application";
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
    }
}

