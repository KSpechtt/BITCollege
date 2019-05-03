using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BITCollege_KS.Models;
using WindowsApplication;

namespace WindowsApplication
{
    /// <summary>
    /// Represents a batch form.
    /// </summary>
    public partial class frmBatch : Form
    {
        BITCollege_KSContext db = new BITCollege_KSContext();
        //Batch batch = new Batch();

        /// <summary>
        /// Initializes the batch form.
        /// </summary>
        public frmBatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form batch load event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBatch_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            IQueryable<BITCollege_KS.Models.Program> programs = db.Programs;
            
            programBindingSource.DataSource = programs.ToList();
        }

        /// <summary>
        /// Handles the batch process link clicked event. Processes the files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Batch batch = new Batch();
            //given - for use in encryption assignment
            if (txtKey.Text.Trim().Length != 8)
            {
                MessageBox.Show("64 Bit Decryption Key must be entered", "Enter Key");
                txtKey.Focus();
            }
            else
            {
                if (radAll.Checked == true)
                {

                    foreach (BITCollege_KS.Models.Program descriptions in descriptionComboBox.Items)
                    {
                        //Batch batch = new Batch();
                        batch.processTransmission(descriptions.ProgramAcronym, txtKey.Text);
                        string logData = batch.writeLogData();
                        richTextBox1.Text += logData;
                    }
                }

                if (radSelect.Checked == true)
                {
                    // Batch batch = new Batch();
                    batch.processTransmission(descriptionComboBox.SelectedValue.ToString(), txtKey.Text);
                    string logData = batch.writeLogData();
                    richTextBox1.Text = logData;
                }
            }
        }

        /// <summary>
        /// Handles the Radio button All Checked event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            descriptionComboBox.Enabled = false;
        }

        /// <summary>
        /// Handles the radio button Selected checked event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radSelect_CheckedChanged(object sender, EventArgs e)
        {
            descriptionComboBox.Enabled = true;
        }


        /// <summary>
        /// Encrypts the file. Testing Purpose
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtKey.Text.Trim().Length != 8)
            {
                MessageBox.Show("64 Bit Decryption Key must be entered", "Enter Key");
                txtKey.Focus();
            }

            Utility.Encryption.encrypt("HeyKevin.txt", "Kevin.txt.encrypted", txtKey.Text);

        }

        /// <summary>
        /// Decrypts the file. Testing purpose
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtKey.Text.Trim().Length != 8)
            {
                MessageBox.Show("64 Bit Decryption Key must be entered", "Enter Key");
                txtKey.Focus();
            }

            Utility.Encryption.decrypt("Kevin.txt.encrypted", "Kevin.txt", txtKey.Text);
        }
    }
}
