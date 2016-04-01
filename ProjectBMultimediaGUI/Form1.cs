using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectBMultimediaGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        { Application.Exit(); }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fopen = new OpenFileDialog();
            fopen.CheckFileExists = true; fopen.CheckPathExists = true; fopen.Filter = "WAV Files|*.wav";
            fopen.ShowDialog();
        }

        private void playpauseBUT_MouseClick(object sender, MouseEventArgs e)
        {
            (sender as Button).ImageIndex = ((sender as Button).ImageIndex == 0) ? 1 : 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            butIML.ImageSize = new Size(playpauseBUT.Size.Width-1,playpauseBUT.Size.Height-1); // This ensures the play and pause buttons are always the same size as the button they are encased in
        }
    }
}
