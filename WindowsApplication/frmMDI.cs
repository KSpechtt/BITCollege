using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given: Open student form in frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent instStudent = new frmStudent();
            instStudent.MdiParent = this;
            instStudent.Show();
        }


        /// <summary>
        /// given: Open batch form in frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatch instBatch = new frmBatch();
            instBatch.MdiParent = this;
            instBatch.Show();
        }

        /// <summary>
        /// given:  close the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// given:  Tile open windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// given:  layer open windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void layerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        //given:  cascade open windows
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        /// <summary>
        /// given:  shows about information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 instAbout = new AboutBox1();
            instAbout.ShowDialog();
        }


    }
}
