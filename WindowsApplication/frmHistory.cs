using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BITCollege_KS.Models;

namespace WindowsApplication
{
    /// <summary>
    /// Represents a History form for BIT College.
    /// </summary>
    public partial class frmHistory : Form
    {
        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;
        BITCollege_KSContext db = new BITCollege_KSContext();

        /// <summary>
        /// Initializes the History Form.
        /// </summary>
        public frmHistory()
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
        public frmHistory(ConstructorData constructorData)
        {
            InitializeComponent();

            this.constructorData = constructorData;

            studentBindingSource.DataSource = constructorData.student;
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
        /// Handles the load event of the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistory_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            try
            {
                var query = db.Registrations.Where(x => x.StudentId == constructorData.student.StudentId)
                        .Join(db.Courses,
                        r => r.CourseId,
                        c => c.CourseId,
                        (r, c)
                        => new
                        {
                            RegistrationNumber = r.RegistrationNumber,
                            RegistrationDate = r.RegistrationDate,
                            Course = c.Title,
                            Grade = r.Grade / 100,
                            Notes = r.Notes

                        }).ToList();

                registrationBindingSource.DataSource = query;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

                
        }
    }
}
