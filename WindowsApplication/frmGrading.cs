using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BITCollege_KS.Models;
using Utility;

namespace WindowsApplication
{
    /// <summary>
    /// Represents the Grading form of BIT college.
    /// </summary>
    public partial class frmGrading : Form
    {
        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;
        ServiceReference1.CollegeRegistrationClient reference = new ServiceReference1.CollegeRegistrationClient();

        /// <summary>
        /// Initializes the Grading form.
        /// </summary>
        public frmGrading()
        {
            InitializeComponent();
        }


        /// <summary>
        /// given:  This constructor will be used when called from 
        /// frmStudent.  This constructor will receive 
        /// specific information about the student and registration
        /// further code required:  
        /// </summary>
        /// <param name="client">specific client instance</param>
        /// <param name="account">specific bank account instance</param>
        public frmGrading(ConstructorData constructorData)
        {
            InitializeComponent();

            this.constructorData = constructorData;

            studentBindingSource.DataSource = constructorData.student;
            registrationBindingSource.DataSource = constructorData.registration;

        }


        /// <summary>
        /// given: this code will navigate back to frmStudent with
        /// the specific student and registration data that launched
        /// this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //return to student with the data selected for this form
            frmStudent frmStudent = new frmStudent(constructorData);
            frmStudent.MdiParent = this.MdiParent;
            frmStudent.Show();
            this.Close();
        }

        /// <summary>
        /// given:  open in top right of frame
        ///  Handles the Load event for the Grading form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGrading_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Location = new Point(0, 0);


            try
            {
                courseNumberMaskedLabel.Mask = BusinessRules.courseFormat(constructorData.registration.Course.CourseType);

                if (gradeTextBox.Text != "")
                {
                    gradeTextBox.Enabled = false;
                    lnkUpdate.Enabled = false;
                    lblExisting.Visible = true;
                }
                else
                {
                    gradeTextBox.Enabled = true;
                    lnkUpdate.Enabled = true;
                    lblExisting.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Update linked clicked Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkUpdate_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                double grade;
                if (!double.TryParse(gradeTextBox.Text, out grade))
                {

                    MessageBox.Show("Not numeric data entered");
                }
                else
                {

                    if (grade >= 0 && grade <= 100)
                    {
                        reference.updateGrade(grade, constructorData.registration.RegistrationId, constructorData.registration.Notes);

                        this.lnkReturn_LinkClicked(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Has to be between 0 and 100");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

    }
}
