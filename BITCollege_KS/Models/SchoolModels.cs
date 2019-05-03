using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utility;
using System.Data.SqlClient;
using System.Data;

namespace BITCollege_KS.Models
{
    /// <summary>
    /// Represents the GPA State
    /// </summary>
    public abstract class GPAState
    {
        protected static BITCollege_KSContext db = new BITCollege_KSContext();

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GPAStateId { get; set; }

        [Required]
        [Display(Name="Lower\nLimit")]
        [DisplayFormat(DataFormatString="{0:F2}")]
        public double LowerLimit { get; set; }

        [Required]
        [Display(Name = "Upper\nLimit")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double UpperLimit { get; set; }

        [Required]
        [Display(Name = "Tuition\nRate\nFactor")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double TuitionRateFactor { get; set; }

        [Display(Name="GPA\nState")]
        public string Description
        { 
            get 
            {
                string name = GetType().Name;
                return string.Format("{0}", Utility.Utility.StringFormat(name, "State"));
            } 
        }

        /// <summary>
        /// Adjusts the tuition rate of a student.
        /// </summary>
        /// <param name="student">A student</param>
        /// <returns>The adjusted tuition of a student.</returns>
        public virtual double tuitionRateAdjustment(Student student)
        {
            return 0;
        }

        /// <summary>
        /// Checks the GPA state change.
        /// </summary>
        /// <param name="student">A student.</param>
        public virtual void stateChangeCheck(Student student)
        {
        }

        public virtual ICollection<Student> Student { get; set; }
    }

    /// <summary>
    /// Represents the Probation GPA state.
    /// </summary>
    public class ProbationState : GPAState
    {
        private static ProbationState _probationState;

        /// <summary>
        /// Constructs an instance of a Probation state.
        /// </summary>
        private ProbationState()
        {
            this.LowerLimit = 1.00;
            this.UpperLimit = 2.00;
            this.TuitionRateFactor = 1.075;
        }

        /// <summary>
        /// Gets Probation state instance.
        /// </summary>
        /// <returns>Probation state instance.</returns>
        public static ProbationState getInstance()
        {
            if (_probationState == null)
            {
                _probationState = db.ProbationStates.SingleOrDefault();
                if (_probationState == null)
                {
                    _probationState = new ProbationState();
                    db.ProbationStates.Add(_probationState);
                    db.SaveChanges();
                }
            }

            return _probationState;
        }

        /// <summary>
        /// Adjusts the tuition rate of a student.
        /// </summary>
        /// <param name="student">A student</param>
        /// <returns>The adjusted tuition of a student.</returns>
        public override double tuitionRateAdjustment(Student student)
        {
            double tuition = this.TuitionRateFactor;
            //IEnumerable<int> query = primes.Where(results => results > 10).Where(results => results / 2 > 7);
            IEnumerable<Registration> linqQuery =
                from results
                in student.Registration
                where results.Grade != null
                where results.StudentId == student.StudentId
                select results;

            IEnumerable<Registration> query = db.Registrations.Where(results => results.Grade != null && results.StudentId == student.StudentId);

            if (query.Count() >= 5)
            {
                tuition -= .04;
            }

            return tuition;
        }

        /// <summary>
        /// Checks the GPA state change.
        /// </summary>
        /// <param name="student">A student.</param>
        public override void stateChangeCheck(Student student)
        {
            if (student.GradePointAverage < getInstance().LowerLimit)
            {
                student.GPAStateId = SuspendedState.getInstance().GPAStateId;
            }
            else if (student.GradePointAverage > getInstance().UpperLimit)
            {
                student.GPAStateId = RegularState.getInstance().GPAStateId;
            }
        }
    }

    /// <summary>
    /// Represents a Honours state GPA
    /// </summary>
    public class HonoursState : GPAState
    {
        private static HonoursState _honoursState;

        /// <summary>
        /// Constructs an instance of a Honours state.
        /// </summary>
        private HonoursState()
        {
            this.LowerLimit = 3.7;
            this.UpperLimit = 4.5;
            this.TuitionRateFactor = .9;
        }

        /// <summary>
        /// Gets Honours state instance.
        /// </summary>
        /// <returns>Honours state instance.</returns>
        public static HonoursState getInstance()
        {
            if (_honoursState == null)
            {
                _honoursState = db.HonoursStates.SingleOrDefault();
                if (_honoursState == null)
                {
                    _honoursState = new HonoursState();
                    db.HonoursStates.Add(_honoursState);
                    db.SaveChanges();
                }
            }

            return _honoursState;       
        }

        /// <summary>
        /// Adjusts the tuition rate of a student.
        /// </summary>
        /// <param name="student">A student</param>
        /// <returns>The adjusted tuition of a student.</returns>
        public override double tuitionRateAdjustment(Student student)
        {
            double tuition = this.TuitionRateFactor;

            IEnumerable<Registration> query = student.Registration.Where(results => results.Grade != null && results.StudentId == student.StudentId);
          
            if (student.GradePointAverage > 4.25)
            {
                tuition -= .02;
            }

            if (query.Count() >= 5)
            {
                tuition -= .05;
            }
            
            return tuition;
        }

        /// <summary>
        /// Checks the GPA state change.
        /// </summary>
        /// <param name="student">A student.</param>
        public override void stateChangeCheck(Student student)
        {
            if (student.GradePointAverage < getInstance().LowerLimit)
            {
                student.GPAStateId = RegularState.getInstance().GPAStateId;
            }
        }
    }

    /// <summary>
    /// Represents a Suspended state GPA
    /// </summary>
    public class SuspendedState : GPAState
    {
        private static SuspendedState _suspendedState;

        /// <summary>
        /// Constructs an instance of a Suspended state.
        /// </summary>
        private SuspendedState()
        {
            this.LowerLimit = 0.00;
            this.UpperLimit = 1.00;
            this.TuitionRateFactor = 1.1;
        }

        /// <summary>
        /// Gets Suspended state instance.
        /// </summary>
        /// <returns>Suspended state instance.</returns>
        public static SuspendedState getInstance()
        {
            if (_suspendedState == null)
            {
                _suspendedState = db.SuspendedStates.SingleOrDefault();

                if (_suspendedState == null)
                {
                    _suspendedState = new SuspendedState();
                    db.SuspendedStates.Add(_suspendedState);
                    db.SaveChanges();
                }
            }

            return _suspendedState;
        }

        /// <summary>
        /// Adjusts the tuition rate of a student.
        /// </summary>
        /// <param name="student">A student</param>
        /// <returns>The adjusted tuition of a student.</returns>
        public override double tuitionRateAdjustment(Student student)
        {
            double tuition = this.TuitionRateFactor;

            if (student.GradePointAverage < 0.75 && student.GradePointAverage >= 0.50)
            {
                tuition += .02;
            }
            if (student.GradePointAverage < 0.50)
            {
                tuition += .05;
            }

            return tuition;       
        }

        /// <summary>
        /// Checks the GPA state change.
        /// </summary>
        /// <param name="student">A student.</param>
        public override void stateChangeCheck(Student student)
        {
            if (student.GradePointAverage > getInstance().UpperLimit)
            {
                student.GPAStateId = ProbationState.getInstance().GPAStateId;
            }
        }
    }

    /// <summary>
    /// Represents a Regular state GPA
    /// </summary>
    public class RegularState : GPAState
    {
        private static RegularState _regularState;

        /// <summary>
        /// Constructs an instance of a Regular state.
        /// </summary>
        private RegularState()
        {
            this.LowerLimit = 2;
            this.UpperLimit = 3.70;
            this.TuitionRateFactor = 1;
        }

        /// <summary>
        /// Gets Regular state instance.
        /// </summary>
        /// <returns>Regular state instance.</returns>
        public static RegularState getInstance()
        {
            if (_regularState == null)
            {
                _regularState = db.RegularStates.SingleOrDefault();
                if (_regularState == null)
                {
                    _regularState = new RegularState();
                    db.RegularStates.Add(_regularState);
                    db.SaveChanges();
                }
            }

            return _regularState;
        }

        /// <summary>
        /// Adjusts the tuition rate of a student.
        /// </summary>
        /// <param name="student">A student</param>
        /// <returns>The adjusted tuition of a student.</returns>
        public override double tuitionRateAdjustment(Student student)
        {
            double tuition = 1.0 ;

            return tuition;
        }

        /// <summary>
        /// Checks the GPA state change.
        /// </summary>
        /// <param name="student">A student.</param>
        public override void stateChangeCheck(Student student)
        {
            if (student.GradePointAverage > getInstance().UpperLimit)
            {
                student.GPAStateId = HonoursState.getInstance().GPAStateId;
            }
            else if (student.GradePointAverage < getInstance().LowerLimit)
            {
                student.GPAStateId = ProbationState.getInstance().GPAStateId;
            }
        }
    }

    /// <summary>
    /// Represents a Student.
    /// </summary>
    public class Student
    {
        private BITCollege_KSContext db = new BITCollege_KSContext();

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey("GPAState")]
        public int GPAStateId { get; set; }

        [ForeignKey("Program")]
        public int? ProgramId { get; set; } 

        [Display(Name="Student\nNumber")]
        public long StudentNumber { get; set; }
        
        [Required]
        [StringLength(35, MinimumLength=1)]
        [Display(Name="First\nName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        [Display(Name = "Last\nName")]
        public string LastName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string Address { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [RegularExpression("^(N[BLSTU]|[AMN]B|[BQ]C|ON|PE|SK|YT)$", ErrorMessage = "A Valid Canadian Provincial Code is Required")]
        public string Province { get; set; }

        [Required]
        [RegularExpression("[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]", ErrorMessage="A valid Canadian Postal Code is Required")]
        [Display(Name = "Postal\nCode")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name="Date\nCreated")]
        [DisplayFormat(DataFormatString="{0:d}")]
        public DateTime DateCreated { get; set; }

        [Display(Name="Grade\nPoint\nAverage")]
        [DisplayFormat(DataFormatString="{0:F2}")]
        public double? GradePointAverage { get; set; }

        [Display(Name = "Outstanding\nFees")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double OutstandingFees { get; set; }

        public string Notes { get; set; }

        [Display(Name="Name")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        [Display(Name="Address")]
        public string FullAddress { get { return string.Format("{0} {1}, {2} {3}", Address, City, Province, PostalCode); } }

        /// <summary>
        /// Sets the Student Number.
        /// </summary>
        public void setNextStudentNumber()
        {
            this.StudentNumber = (long)StoredProcedures.nextNumber("NextStudentNumbers");
        }

        /// <summary>
        /// Changes the GPA State of a student.
        /// </summary>
        public void changeState()
        {
            int currentState, newState;

            currentState = this.GPAStateId;

            do
            {
                newState = currentState;

                GPAState state = db.GPAStates.Where(x => x.GPAStateId == currentState).SingleOrDefault();

                state.stateChangeCheck(this);

                currentState = this.GPAStateId;

            } while (newState != currentState);     
        }

        public virtual GPAState GPAState { get; set; }
        public virtual Program Program { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
        public virtual ICollection<StudentCard> StudentCard { get; set; }
    }

    /// <summary>
    /// Represents a Student Card.
    /// </summary>
    public class StudentCard
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentCardId { get; set; }

        [Display(Name="Card\nNumber")]
        public long CardNumber { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

    }

    /// <summary>
    /// Represents the Next Student Number.
    /// </summary>
    public class NextStudentNumber
    {
        private static BITCollege_KSContext db = new BITCollege_KSContext();

        private static NextStudentNumber _nextStudentNumber;

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextStudentNumberId { get; set; }

        [Display(Name="Next\nAvailable\nNumber")]
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Constructs an instance of next student number.
        /// </summary>
        private NextStudentNumber()
        {
            this.NextAvailableNumber = 20000000;
        }

        /// <summary>
        /// Creates and/or gets the instance of the next student number.
        /// </summary>
        /// <returns>Next student number instance.</returns>
        public static NextStudentNumber getInstance()
        {
            if (_nextStudentNumber == null)
            {
                _nextStudentNumber = db.NextStudentNumbers.SingleOrDefault();

                if (_nextStudentNumber == null)
                {
                    _nextStudentNumber = new NextStudentNumber();
                    db.NextStudentNumbers.Add(_nextStudentNumber);
                    db.SaveChanges();
                }
            }

            return _nextStudentNumber;
        }
    }

    /// <summary>
    /// Represents a Program offered at the college.
    /// </summary>
    public class Program
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProgramId { get; set; }
 
        [Display(Name="Program\nAcronym")]
        public string ProgramAcronym { get; set; }
        
        public string Description { get; set; } 

        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }

    /// <summary>
    /// Represents Registration at the college.
    /// </summary>
    public class Registration
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RegistrationId { get; set; }

        [Display(Name = "Registration\nNumber")]
        public long RegistrationNumber { get; set; }  

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Registration\nDate")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime RegistrationDate { get; set; }

        [Range(0,100)]
        public double? Grade { get; set; }

        public string Notes { get; set; }


        /// <summary>
        /// Constructs an instance of a Registration. 
        /// </summary>
        public Registration()
        {
        }

        /// <summary>
        /// Sets the next registration number.
        /// </summary>
        public void setNextRegistrationNumber()
        {
            this.RegistrationNumber = (long)StoredProcedures.nextNumber("NextRegistrationNumbers");

        }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }

    /// <summary>
    /// Represents the next registration number.
    /// </summary>
    public class NextRegistrationNumber
    {
        private static BITCollege_KSContext db = new BITCollege_KSContext();

        private static NextRegistrationNumber _nextRegistrationNumber;

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextRegistrationNumberId { get; set; }

        [Display(Name="Next\nAvailable\nNumber")]
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Constructs an instance of Next registration number.
        /// </summary>
        private NextRegistrationNumber()
        {
            this.NextAvailableNumber = 700;
        }

        /// <summary>
        /// Creates and/or Gets the instance of next registration number.
        /// </summary>
        /// <returns>Instance of registration number</returns>
        public static NextRegistrationNumber getInstance()
        {
            if (_nextRegistrationNumber == null)
            {
                _nextRegistrationNumber = db.NextRegistrationNumbers.SingleOrDefault();

                if (_nextRegistrationNumber == null)
                {
                    _nextRegistrationNumber = new NextRegistrationNumber();
                    db.NextRegistrationNumbers.Add(_nextRegistrationNumber);
                    db.SaveChanges();
                }

            }

            return _nextRegistrationNumber;
        }
    }

    /// <summary>
    /// Represents a Course at the college.
    /// </summary>
    public abstract class Course
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        
        [ForeignKey("Program")]
        public int? ProgramId { get; set; }

        [Display(Name="Course\nNumber")]
        public string CourseNumber { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name="Credit\nHours")]
        [DisplayFormat(DataFormatString="{0:N0}")]
        public double CreditHours { get; set; }

        [Required]
        [Display(Name = "Tuition\nAmount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double TuitionAmount { get; set; }

        [Required]
        [Display(Name="Course\nType")]
        public string CourseType 
        {
            get
            {
                string name = GetType().Name;
                return string.Format("{0}", Utility.Utility.StringFormat(name, "Course")); 
            }
        }

        public string Notes { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
        public virtual Program Program { get; set; }
    }

    /// <summary>
    /// Represents a Graded Course
    /// </summary>
    public class GradedCourse : Course
    {
        [Required]
        [Display(Name = "Assignment\nWeight")]
        [DisplayFormat(DataFormatString = "{0:F2}" + "%")]
        public double AssignmentWeight { get; set; }

        [Required]
        [Display(Name = "Midterm\nWeight")]
        [DisplayFormat(DataFormatString = "{0:F2}" + "%")]
        public double MidtermWeight { get; set; }

        [Required]
        [Display(Name = "Final\nWeight")]
        [DisplayFormat(DataFormatString = "{0:F2}" + "%")]
        public double FinalWeight { get; set; }

        /// <summary>
        /// Sets the next course number.
        /// </summary>
        public void setNextCourseNumber()
        {
            this.CourseNumber = String.Format("G-{0}",(long)StoredProcedures.nextNumber("NextGradedCourses"));
        }
    }

    /// <summary>
    /// Represents an Audit Course.
    /// </summary>
    public class AuditCourse : Course
    {
        /// <summary>
        /// Sets the next course number.
        /// </summary>
        public void setNextCourseNumber()
        {
            this.CourseNumber = string.Format("A-{0}", (long)StoredProcedures.nextNumber("NextAuditCourses"));
        }
    }

    /// <summary>
    /// Represents a Mastery Course
    /// </summary>
    public class MasteryCourse : Course
    {
        [Required]
        [Display(Name = "Maximum\nAttempts")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int MaximumAttempts { get; set; }

        /// <summary>
        /// Sets the next course number.
        /// </summary>
        public void setNextCourseNumber()
        {
            this.CourseNumber = string.Format("M-{0}", (long)StoredProcedures.nextNumber("NextMasteryCourses"));
        }
    }

    /// <summary>
    /// Represents the next graded course.
    /// </summary>
    public class NextGradedCourse
    {
        private static BITCollege_KSContext db = new BITCollege_KSContext();

        private static NextGradedCourse _nextGradedCourse;

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextGradedCourseId { get; set; }

        [Display(Name = "Next\nAvailable\nNumber")]
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Constructs an instance of next graded course.
        /// </summary>
        private NextGradedCourse()
        {
            this.NextAvailableNumber = 200000;
        }

        /// <summary>
        /// Creates and or gets the instance of a next graded course.
        /// </summary>
        /// <returns>An instance of next graded course.</returns>
        public static NextGradedCourse getInstance()
        {
            if (_nextGradedCourse == null)
            {
                _nextGradedCourse = db.NextGradedCourses.SingleOrDefault();

                if (_nextGradedCourse == null)
                {
                    _nextGradedCourse = new NextGradedCourse();
                    db.NextGradedCourses.Add(_nextGradedCourse);
                    db.SaveChanges();
                }
            }

            return _nextGradedCourse;
        }
    }

    /// <summary>
    /// Represents a next audit course.
    /// </summary>
    public class NextAuditCourse
    {
        private static BITCollege_KSContext db = new BITCollege_KSContext();

        private static NextAuditCourse _nextAuditCourse;

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextAuditCourseId { get; set; }

        [Display(Name = "Next\nAvailable\nNumber")]
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Constructs an instance of a next audit course.
        /// </summary>
        private NextAuditCourse()
        {
            this.NextAvailableNumber = 2000;
        }

        /// <summary>
        /// Creates and or gets the instance of a next audit course.
        /// </summary>
        /// <returns>An instance of a next audit course.</returns>
        public static NextAuditCourse getInstance()
        {
            if (_nextAuditCourse == null)
            {
                _nextAuditCourse = db.NextAuditCourses.SingleOrDefault();

                if (_nextAuditCourse == null)
                {
                    _nextAuditCourse = new NextAuditCourse();
                    db.NextAuditCourses.Add(_nextAuditCourse);
                    db.SaveChanges();
                }
            }

            return _nextAuditCourse;
        }

    }

    /// <summary>
    /// Represents a next mastery course.
    /// </summary>
    public class NextMasteryCourse
    {
        private static BITCollege_KSContext db = new BITCollege_KSContext();

        private static NextMasteryCourse _nextMasteryCourse;

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextMasteryCourseId { get; set; }

        [Display(Name = "Next\nAvailable\nNumber")]
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Constructs an instance of a next mastery course.
        /// </summary>
        private NextMasteryCourse()
        {
            this.NextAvailableNumber = 20000;
        }

        /// <summary>
        /// Creates and or gets the instance of a next mastery course.
        /// </summary>
        /// <returns>An instance of a next mastery course.</returns>
        public static NextMasteryCourse getInstance()
        {
            if (_nextMasteryCourse == null)
            {
                _nextMasteryCourse = db.NextMasteryCourses.SingleOrDefault();

                if (_nextMasteryCourse == null)
                {
                    _nextMasteryCourse = new NextMasteryCourse();
                    db.NextMasteryCourses.Add(_nextMasteryCourse);
                    db.SaveChanges();
                }
            }

            return _nextMasteryCourse;
        }
            
    }

    /// <summary>
    /// Represents a StoredProcedures class.
    /// </summary>
    public static class StoredProcedures
    {
        /// <summary>
        /// Sets the next number to a table ID.
        /// </summary>
        /// <param name="tableName">The name of a table.</param>
        /// <returns>The new next number of a table ID.</returns>
        public static long? nextNumber(string tableName)
        {
            //Opening a new SQL Connection
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=BITCollege_KSContext;Integrated Security=True");
            //Creating a variable that can be nullable as our return value.
            long? returnValue = 0;
            //Creating a new SQL Command and passing the stored procedure name and our connection.
            SqlCommand storedProcedure = new SqlCommand("next_number", connection);
            //Defining the commandtype of our SQL command
            storedProcedure.CommandType = CommandType.StoredProcedure;
            //Adding parameters to our SQL command.
            storedProcedure.Parameters.AddWithValue("@TableName", tableName);
            //Creating an outpout parameter.
            SqlParameter outputParameter = new SqlParameter("@NewVal", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            //Adding the parameter to our SQL command.
            storedProcedure.Parameters.Add(outputParameter);
            //Wrapping our open and close connection along with our execute non query method in a Try and if we catch any exceptions we set our return to NULL.
            try
            {
                connection.Open();

                storedProcedure.ExecuteNonQuery();

                connection.Close();

                returnValue = (long?)outputParameter.Value;

                return returnValue;
            }
            catch (Exception)
            {
                returnValue = null;
                return returnValue;
            }
        }
    }



}
