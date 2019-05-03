namespace WindowsApplication
{
    partial class frmStudent
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
            System.Windows.Forms.Label gradePointAverageLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label fullAddressLabel;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label courseNumberLabel;
            System.Windows.Forms.Label titleLabel;
            System.Windows.Forms.Label creditHoursLabel;
            System.Windows.Forms.Label studentNumberLabel;
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label provinceLabel;
            System.Windows.Forms.Label postalCodeLabel;
            System.Windows.Forms.Label registrationNumberLabel;
            System.Windows.Forms.Label outstandingFeesLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.postalCodeMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.provinceMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.dateCreatedMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.studentNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.gpaDescriptionLabel1 = new System.Windows.Forms.Label();
            this.cityLabel1 = new System.Windows.Forms.Label();
            this.fullAddressLabel1 = new System.Windows.Forms.Label();
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.gradePointAverageLabel1 = new System.Windows.Forms.Label();
            this.lblRFID = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.registrationNumberComboBox = new System.Windows.Forms.ComboBox();
            this.registrationBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.creditHoursLabel1 = new System.Windows.Forms.Label();
            this.titleLabel1 = new System.Windows.Forms.Label();
            this.courseNumberLabel1 = new System.Windows.Forms.Label();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.lnkDetails = new System.Windows.Forms.LinkLabel();
            this.outstandingFeesLabel1 = new System.Windows.Forms.Label();
            gradePointAverageLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            fullAddressLabel = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            courseNumberLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            creditHoursLabel = new System.Windows.Forms.Label();
            studentNumberLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            provinceLabel = new System.Windows.Forms.Label();
            postalCodeLabel = new System.Windows.Forms.Label();
            registrationNumberLabel = new System.Windows.Forms.Label();
            outstandingFeesLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gradePointAverageLabel
            // 
            gradePointAverageLabel.AutoSize = true;
            gradePointAverageLabel.Location = new System.Drawing.Point(65, 230);
            gradePointAverageLabel.Name = "gradePointAverageLabel";
            gradePointAverageLabel.Size = new System.Drawing.Size(145, 17);
            gradePointAverageLabel.TabIndex = 1;
            gradePointAverageLabel.Text = "Grade Point Average:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(65, 70);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(75, 17);
            fullNameLabel.TabIndex = 3;
            fullNameLabel.Text = "Full Name:";
            // 
            // fullAddressLabel
            // 
            fullAddressLabel.AutoSize = true;
            fullAddressLabel.Location = new System.Drawing.Point(65, 110);
            fullAddressLabel.Name = "fullAddressLabel";
            fullAddressLabel.Size = new System.Drawing.Size(90, 17);
            fullAddressLabel.TabIndex = 5;
            fullAddressLabel.Text = "Full Address:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(65, 145);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(35, 17);
            cityLabel.TabIndex = 7;
            cityLabel.Text = "City:";
            // 
            // courseNumberLabel
            // 
            courseNumberLabel.AutoSize = true;
            courseNumberLabel.Location = new System.Drawing.Point(65, 118);
            courseNumberLabel.Name = "courseNumberLabel";
            courseNumberLabel.Size = new System.Drawing.Size(111, 17);
            courseNumberLabel.TabIndex = 2;
            courseNumberLabel.Text = "Course Number:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(351, 118);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(39, 17);
            titleLabel.TabIndex = 4;
            titleLabel.Text = "Title:";
            // 
            // creditHoursLabel
            // 
            creditHoursLabel.AutoSize = true;
            creditHoursLabel.Location = new System.Drawing.Point(64, 193);
            creditHoursLabel.Name = "creditHoursLabel";
            creditHoursLabel.Size = new System.Drawing.Size(91, 17);
            creditHoursLabel.TabIndex = 6;
            creditHoursLabel.Text = "Credit Hours:";
            // 
            // studentNumberLabel
            // 
            studentNumberLabel.AutoSize = true;
            studentNumberLabel.Location = new System.Drawing.Point(65, 31);
            studentNumberLabel.Name = "studentNumberLabel";
            studentNumberLabel.Size = new System.Drawing.Size(115, 17);
            studentNumberLabel.TabIndex = 16;
            studentNumberLabel.Text = "Student Number:";
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(64, 187);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(96, 17);
            dateCreatedLabel.TabIndex = 17;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // provinceLabel
            // 
            provinceLabel.AutoSize = true;
            provinceLabel.Location = new System.Drawing.Point(383, 145);
            provinceLabel.Name = "provinceLabel";
            provinceLabel.Size = new System.Drawing.Size(67, 17);
            provinceLabel.TabIndex = 18;
            provinceLabel.Text = "Province:";
            // 
            // postalCodeLabel
            // 
            postalCodeLabel.AutoSize = true;
            postalCodeLabel.Location = new System.Drawing.Point(596, 145);
            postalCodeLabel.Name = "postalCodeLabel";
            postalCodeLabel.Size = new System.Drawing.Size(88, 17);
            postalCodeLabel.TabIndex = 19;
            postalCodeLabel.Text = "Postal Code:";
            // 
            // registrationNumberLabel
            // 
            registrationNumberLabel.AutoSize = true;
            registrationNumberLabel.Location = new System.Drawing.Point(64, 61);
            registrationNumberLabel.Name = "registrationNumberLabel";
            registrationNumberLabel.Size = new System.Drawing.Size(142, 17);
            registrationNumberLabel.TabIndex = 7;
            registrationNumberLabel.Text = "Registration Number:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(outstandingFeesLabel);
            this.groupBox1.Controls.Add(this.outstandingFeesLabel1);
            this.groupBox1.Controls.Add(postalCodeLabel);
            this.groupBox1.Controls.Add(this.postalCodeMaskedLabel);
            this.groupBox1.Controls.Add(provinceLabel);
            this.groupBox1.Controls.Add(this.provinceMaskedLabel);
            this.groupBox1.Controls.Add(dateCreatedLabel);
            this.groupBox1.Controls.Add(this.dateCreatedMaskedLabel);
            this.groupBox1.Controls.Add(studentNumberLabel);
            this.groupBox1.Controls.Add(this.studentNumberMaskedTextBox);
            this.groupBox1.Controls.Add(this.gpaDescriptionLabel1);
            this.groupBox1.Controls.Add(cityLabel);
            this.groupBox1.Controls.Add(this.cityLabel1);
            this.groupBox1.Controls.Add(fullAddressLabel);
            this.groupBox1.Controls.Add(this.fullAddressLabel1);
            this.groupBox1.Controls.Add(fullNameLabel);
            this.groupBox1.Controls.Add(this.fullNameLabel1);
            this.groupBox1.Controls.Add(gradePointAverageLabel);
            this.groupBox1.Controls.Add(this.gradePointAverageLabel1);
            this.groupBox1.Controls.Add(this.lblRFID);
            this.groupBox1.Location = new System.Drawing.Point(41, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(873, 282);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Data";
            // 
            // postalCodeMaskedLabel
            // 
            this.postalCodeMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postalCodeMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "PostalCode", true));
            this.postalCodeMaskedLabel.Location = new System.Drawing.Point(690, 145);
            this.postalCodeMaskedLabel.Mask = ">L0L 0L0";
            this.postalCodeMaskedLabel.Name = "postalCodeMaskedLabel";
            this.postalCodeMaskedLabel.Size = new System.Drawing.Size(163, 23);
            this.postalCodeMaskedLabel.TabIndex = 20;
            this.postalCodeMaskedLabel.Text = "    ";
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(BITCollege_KS.Models.Student);
            // 
            // provinceMaskedLabel
            // 
            this.provinceMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.provinceMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "Province", true));
            this.provinceMaskedLabel.Location = new System.Drawing.Point(456, 145);
            this.provinceMaskedLabel.Mask = ">LL";
            this.provinceMaskedLabel.Name = "provinceMaskedLabel";
            this.provinceMaskedLabel.Size = new System.Drawing.Size(124, 23);
            this.provinceMaskedLabel.TabIndex = 19;
            // 
            // dateCreatedMaskedLabel
            // 
            this.dateCreatedMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateCreatedMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "DateCreated", true));
            this.dateCreatedMaskedLabel.Location = new System.Drawing.Point(227, 187);
            this.dateCreatedMaskedLabel.Mask = "00/00/0000";
            this.dateCreatedMaskedLabel.Name = "dateCreatedMaskedLabel";
            this.dateCreatedMaskedLabel.Size = new System.Drawing.Size(124, 23);
            this.dateCreatedMaskedLabel.TabIndex = 18;
            this.dateCreatedMaskedLabel.Text = "  -  -";
            // 
            // studentNumberMaskedTextBox
            // 
            this.studentNumberMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "StudentNumber", true));
            this.studentNumberMaskedTextBox.Location = new System.Drawing.Point(230, 28);
            this.studentNumberMaskedTextBox.Mask = "0000-0000";
            this.studentNumberMaskedTextBox.Name = "studentNumberMaskedTextBox";
            this.studentNumberMaskedTextBox.Size = new System.Drawing.Size(100, 22);
            this.studentNumberMaskedTextBox.TabIndex = 17;
            this.studentNumberMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // gpaDescriptionLabel1
            // 
            this.gpaDescriptionLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpaDescriptionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "GPAState.Description", true));
            this.gpaDescriptionLabel1.Location = new System.Drawing.Point(386, 229);
            this.gpaDescriptionLabel1.Name = "gpaDescriptionLabel1";
            this.gpaDescriptionLabel1.Size = new System.Drawing.Size(124, 23);
            this.gpaDescriptionLabel1.TabIndex = 16;
            // 
            // cityLabel1
            // 
            this.cityLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cityLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "City", true));
            this.cityLabel1.Location = new System.Drawing.Point(227, 145);
            this.cityLabel1.Name = "cityLabel1";
            this.cityLabel1.Size = new System.Drawing.Size(142, 23);
            this.cityLabel1.TabIndex = 8;
            // 
            // fullAddressLabel1
            // 
            this.fullAddressLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullAddressLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullAddress", true));
            this.fullAddressLabel1.Location = new System.Drawing.Point(227, 110);
            this.fullAddressLabel1.Name = "fullAddressLabel1";
            this.fullAddressLabel1.Size = new System.Drawing.Size(223, 23);
            this.fullAddressLabel1.TabIndex = 6;
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(227, 70);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(230, 23);
            this.fullNameLabel1.TabIndex = 4;
            // 
            // gradePointAverageLabel1
            // 
            this.gradePointAverageLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradePointAverageLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "GradePointAverage", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.gradePointAverageLabel1.Location = new System.Drawing.Point(227, 230);
            this.gradePointAverageLabel1.Name = "gradePointAverageLabel1";
            this.gradePointAverageLabel1.Size = new System.Drawing.Size(124, 23);
            this.gradePointAverageLabel1.TabIndex = 2;
            this.gradePointAverageLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRFID
            // 
            this.lblRFID.AutoSize = true;
            this.lblRFID.ForeColor = System.Drawing.Color.Red;
            this.lblRFID.Location = new System.Drawing.Point(393, 44);
            this.lblRFID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRFID.Name = "lblRFID";
            this.lblRFID.Size = new System.Drawing.Size(331, 17);
            this.lblRFID.TabIndex = 0;
            this.lblRFID.Text = "RFID Unavailable - Enter Student Number Manually";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(registrationNumberLabel);
            this.groupBox2.Controls.Add(this.registrationNumberComboBox);
            this.groupBox2.Controls.Add(creditHoursLabel);
            this.groupBox2.Controls.Add(this.creditHoursLabel1);
            this.groupBox2.Controls.Add(titleLabel);
            this.groupBox2.Controls.Add(this.titleLabel1);
            this.groupBox2.Controls.Add(courseNumberLabel);
            this.groupBox2.Controls.Add(this.courseNumberLabel1);
            this.groupBox2.Location = new System.Drawing.Point(41, 369);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(869, 256);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registration Data";
            // 
            // registrationNumberComboBox
            // 
            this.registrationNumberComboBox.DataSource = this.registrationBindingSource1;
            this.registrationNumberComboBox.DisplayMember = "RegistrationNumber";
            this.registrationNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.registrationNumberComboBox.FormattingEnabled = true;
            this.registrationNumberComboBox.Location = new System.Drawing.Point(230, 58);
            this.registrationNumberComboBox.Name = "registrationNumberComboBox";
            this.registrationNumberComboBox.Size = new System.Drawing.Size(121, 24);
            this.registrationNumberComboBox.TabIndex = 8;
            this.registrationNumberComboBox.ValueMember = "RegistrationId";
            // 
            // registrationBindingSource1
            // 
            this.registrationBindingSource1.DataSource = typeof(BITCollege_KS.Models.Registration);
            // 
            // creditHoursLabel1
            // 
            this.creditHoursLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.creditHoursLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource1, "Course.CreditHours", true));
            this.creditHoursLabel1.Location = new System.Drawing.Point(227, 193);
            this.creditHoursLabel1.Name = "creditHoursLabel1";
            this.creditHoursLabel1.Size = new System.Drawing.Size(100, 23);
            this.creditHoursLabel1.TabIndex = 7;
            this.creditHoursLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // titleLabel1
            // 
            this.titleLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource1, "Course.Title", true));
            this.titleLabel1.Location = new System.Drawing.Point(465, 118);
            this.titleLabel1.Name = "titleLabel1";
            this.titleLabel1.Size = new System.Drawing.Size(270, 23);
            this.titleLabel1.TabIndex = 5;
            // 
            // courseNumberLabel1
            // 
            this.courseNumberLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.courseNumberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource1, "Course.CourseNumber", true));
            this.courseNumberLabel1.Location = new System.Drawing.Point(227, 118);
            this.courseNumberLabel1.Name = "courseNumberLabel1";
            this.courseNumberLabel1.Size = new System.Drawing.Size(100, 23);
            this.courseNumberLabel1.TabIndex = 3;
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Enabled = false;
            this.lnkUpdate.Location = new System.Drawing.Point(300, 644);
            this.lnkUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(98, 17);
            this.lnkUpdate.TabIndex = 2;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "Update Grade";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // lnkDetails
            // 
            this.lnkDetails.AutoSize = true;
            this.lnkDetails.Enabled = false;
            this.lnkDetails.Location = new System.Drawing.Point(492, 642);
            this.lnkDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkDetails.Name = "lnkDetails";
            this.lnkDetails.Size = new System.Drawing.Size(84, 17);
            this.lnkDetails.TabIndex = 3;
            this.lnkDetails.TabStop = true;
            this.lnkDetails.Text = "View Details";
            this.lnkDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetails_LinkClicked);
            // 
            // outstandingFeesLabel
            // 
            outstandingFeesLabel.AutoSize = true;
            outstandingFeesLabel.Location = new System.Drawing.Point(596, 236);
            outstandingFeesLabel.Name = "outstandingFeesLabel";
            outstandingFeesLabel.Size = new System.Drawing.Size(124, 17);
            outstandingFeesLabel.TabIndex = 20;
            outstandingFeesLabel.Text = "Outstanding Fees:";
            // 
            // outstandingFeesLabel1
            // 
            this.outstandingFeesLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "OutstandingFees", true));
            this.outstandingFeesLabel1.Location = new System.Drawing.Point(726, 236);
            this.outstandingFeesLabel1.Name = "outstandingFeesLabel1";
            this.outstandingFeesLabel1.Size = new System.Drawing.Size(100, 23);
            this.outstandingFeesLabel1.TabIndex = 21;
            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 751);
            this.Controls.Add(this.lnkDetails);
            this.Controls.Add(this.lnkUpdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStudent";
            this.Text = "Student Information";
            this.Load += new System.EventHandler(this.frmStudent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRFID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.LinkLabel lnkDetails;
        private System.Windows.Forms.Label gradePointAverageLabel1;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private EWSoftware.MaskedLabelControl.MaskedLabel postalCodeMaskedLabel;
        private EWSoftware.MaskedLabelControl.MaskedLabel provinceMaskedLabel;
        private EWSoftware.MaskedLabelControl.MaskedLabel dateCreatedMaskedLabel;
        private System.Windows.Forms.MaskedTextBox studentNumberMaskedTextBox;
        private System.Windows.Forms.Label gpaDescriptionLabel1;
        private System.Windows.Forms.Label cityLabel1;
        private System.Windows.Forms.Label fullAddressLabel1;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.ComboBox registrationNumberComboBox;
        private System.Windows.Forms.BindingSource registrationBindingSource1;
        private System.Windows.Forms.Label creditHoursLabel1;
        private System.Windows.Forms.Label titleLabel1;
        private System.Windows.Forms.Label courseNumberLabel1;
        private System.Windows.Forms.Label outstandingFeesLabel1;
    }
}