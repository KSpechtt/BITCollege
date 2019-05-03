using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO.Ports;      //for rfid assignment
using BITCollege_KS.Models;


namespace WindowsApplication
{
    /// <summary>
    /// Represents the Student Form for BIT College.
    /// </summary>
    public partial class frmStudent : Form
    {

        ///given: client and bankaccount data will be retrieved
        ///in this form and passed throughout application
        ///these variables will be used to store the current
        ///client and selected bankaccount
        ConstructorData constructorData = new ConstructorData();

        BITCollege_KSContext db = new BITCollege_KSContext();

        /// <summary>
        /// Sets the leavecall Back
        /// </summary>
        /// <param name="data">The student Number</param>
        delegate void SetLeaveCallBack(string data);

        /// <summary>
        /// Creates our Student by reading the RFID and transforming it into a student number.
        /// </summary>
        /// <param name="data">Student Number</param>
        private void setLeave(string data)
        {
            if (this.studentNumberMaskedTextBox.InvokeRequired)
            {
                object[] objArray = new object[] { data };

                SetLeaveCallBack objCallBack = new SetLeaveCallBack(setLeave);

                this.Invoke(objCallBack, objArray);
            }
            else
            {
                try
                {
                    long lastThree = long.Parse(data.Substring(7));
                    long studentNum = long.Parse(data) * lastThree;

                    string hexaStudentNum = studentNum.ToString("X");

                    int start = hexaStudentNum.Length - 1;
                    int end = hexaStudentNum.Length - 4;

                    for (int i = start; i > end; i--)
                    {

                        char value = hexaStudentNum[i];


                        if (value == 'A' || value == 'B' || value == 'C' || value == 'D' || value == 'E' || value == 'F')
                        {
                            hexaStudentNum = hexaStudentNum.Substring(0, hexaStudentNum.Length - 3);
                            break;
                        }
                    }



                    long finalStudentNum = long.Parse(hexaStudentNum, System.Globalization.NumberStyles.HexNumber);


                    StudentCard query = db.StudentCards.Where(x => x.CardNumber == finalStudentNum).SingleOrDefault();

                    if (query == null)
                    {
                        throw new Exception("The student card is invalid");

                    }

                    long studentQuery = db.Students.Where(x => x.StudentId == query.StudentId).Select(x => x.StudentNumber).Single();

                    studentNumberMaskedTextBox.Text = studentQuery.ToString();

                    studentNumberMaskedTextBox_Leave(null, null);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }



            }
        }

        /// <summary>
        /// Opens our RFID Port and reads it.
        /// </summary>
        /// <param name="name">The port being used</param>
        private void openPort(string name)
        {
            lblRFID.Visible = false;

            if (!rfid.IsOpen)
            {
                rfid.BaudRate = 9600;
                rfid.PortName = name;
                rfid.Parity = Parity.None;
                rfid.DataBits = 8;
                rfid.StopBits = StopBits.One;
                rfid.Handshake = Handshake.None;
                rfid.ReadTimeout = 3000;
                rfid.ReceivedBytesThreshold = 1;
                rfid.DtrEnable = true;

                try
                {
                    rfid.Open();
                }
                catch (Exception)
                {

                    lblRFID.Visible = true;
                }

            }
        }

        /// <summary>
        /// Initializes the Student Form.
        /// </summary>
        public frmStudent()
        {
            InitializeComponent();
            studentNumberMaskedTextBox.Leave += new EventHandler(studentNumberMaskedTextBox_Leave);
            this.FormClosed += new FormClosedEventHandler(frmStudent_FormClosed);


        }

        /// <summary>
        /// Handles the form closed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (rfid.IsOpen)
            {
                rfid.Close();
            }
        }

        /// <summary>
        /// given:  This constructor will be used when returning to frmStudnet
        /// from another form.  This constructor will pass back
        /// specific information about the student and registration
        /// based on activites taking place in another form
        /// </summary>
        /// <param name="constructorData">Student data passed among forms</param>
        public frmStudent(ConstructorData constructorData)
        {
            InitializeComponent();

            this.constructorData = constructorData;

            studentNumberMaskedTextBox.Leave += new EventHandler(studentNumberMaskedTextBox_Leave);

            studentBindingSource.DataSource = constructorData.student;

            registrationBindingSource1.DataSource = constructorData.registration;

            studentNumberMaskedTextBox.Text = constructorData.student.StudentNumber.ToString();

            studentNumberMaskedTextBox_Leave(null,null);

        }

        /// <summary>
        /// given: open history form passing data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //instance of frmHistory passing constructor data
            loadConstructor();
            frmHistory frmHistory = new frmHistory(constructorData);
            //open in frame
            frmHistory.MdiParent = this.MdiParent;
            //show form
            frmHistory.Show();
            this.Close();
        }

        /// <summary>
        /// given: open grading form passing constructor data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //instance of frmTransaction passing constructor data
            loadConstructor();
            frmGrading frmGrading = new frmGrading(constructorData);
            //open in frame
            frmGrading.MdiParent = this.MdiParent;
            //show form
            frmGrading.Show();
            this.Close();

        }

        /// <summary>
        /// given:  opens form in top right of frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStudent_Load(object sender, EventArgs e)
        {
            //keeps location of form static when opened and closed
            this.Location = new Point(0, 0);


            for (int i = 3; i < 10; i++)
            {
                if (!rfid.IsOpen)
                {
                    openPort("COM" + i);
                }
            }
        }

        /// <summary>
        /// Handles the Leave event of the Masked Textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void studentNumberMaskedTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                lnkDetails.Enabled = false;
                lnkUpdate.Enabled = false;
                if (studentNumberMaskedTextBox.MaskCompleted)
                {
                    int studentNum = int.Parse(studentNumberMaskedTextBox.Text);

                    Student student = db.Students.Where(x => x.StudentNumber == studentNum).SingleOrDefault();
                    studentBindingSource.DataSource = student;

                    if (student == null)
                    {
                        MessageBox.Show("Student Number does not exist");
                        lnkDetails.Enabled = false;
                        lnkUpdate.Enabled = false;
                        studentNumberMaskedTextBox.Focus();
                        registrationBindingSource1.Clear();
                        studentBindingSource.Clear();
                    }
                    else
                    {
                        studentBindingSource.DataSource = student;

                        IQueryable<Registration> reg = db.Registrations.Where(x => x.StudentId == student.StudentId);

                        if (reg.Count() == 0)
                        {
                            lnkDetails.Enabled = false;
                            lnkUpdate.Enabled = false;
                            registrationBindingSource1.Clear();
                        }
                        else
                        {
                            constructorData.student = student;
                            
                            registrationBindingSource1.DataSource = reg.ToList();
                            lnkDetails.Enabled = true;
                            lnkUpdate.Enabled = true;

                            if (constructorData.registration != null)
                            {
                                registrationNumberComboBox.Text = constructorData.registration.RegistrationNumber.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Loads the form after returning from another form and passing the data to show the appropriate data.
        /// </summary>
        private void loadConstructor()
        {
            this.constructorData.student = (Student)studentBindingSource.Current;
            this.constructorData.registration = (Registration)registrationBindingSource1.Current;
        }

        /// <summary>
        /// Handles the data recieved event from the serial port.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string results = rfid.ReadExisting();

            results.Trim();

            while (results.Length < 12)
            {
                results += rfid.ReadExisting();

            }

            results = results.Substring(1, results.Length - 2);

            setLeave(results);
        }
    }
}
