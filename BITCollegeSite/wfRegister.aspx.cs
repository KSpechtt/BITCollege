using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_KS.Models;


/// <summary>
/// Represents a class for Register page.
/// </summary>
public partial class wfRegister : System.Web.UI.Page
{
    BITCollege_KSContext db = new BITCollege_KSContext();
    ServiceReference1.CollegeRegistrationClient service = new ServiceReference1.CollegeRegistrationClient();
    
    /// <summary>
    /// Handles the page load event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Student studentID = GetStudent();
                lblName.Text = studentID.FullName;

                IQueryable<Course> courses = GetCourses(studentID);
                ddlCourseTitle.DataSource = courses.Select(x => x.Title).ToList();
                this.DataBind();
            }
            catch (Exception ex)
            {

                lblException.Text = ex.Message;
                lblException.Visible = true;
            } 
        }
    }

    /// <summary>
    /// Gets a list of courses.
    /// </summary>
    /// <param name="studentID">Student's ID Number</param>
    /// <returns>A list of courses based on the students id.</returns>
    private IQueryable<Course> GetCourses(Student studentID)
    {
        IQueryable<Course> courses = db.Courses.Where(x => x.ProgramId == studentID.ProgramId);
        return courses;
    }

    /// <summary>
    /// Gets a single student record
    /// </summary>
    /// <returns>A single student</returns>
    private Student GetStudent()
    {
        Student studentID = (Student)Session["SessionStudentNumber"];
        return studentID;
    }

    /// <summary>
    /// Handles the register click button event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbRegister_Click(object sender, EventArgs e)
    {
        Student student = GetStudent();
        IQueryable<Course> courses = GetCourses(student);
        string courseTitle = ddlCourseTitle.SelectedValue;
        int courseId = db.Courses.Where(x=>x.Title == courseTitle).Select(x=>x.CourseId).SingleOrDefault();
        int code = service.registerCourse(student.StudentId, courseId, txtNotes.Text);
        
            if (code != 0)
            {
                lblException.Text = Utility.BusinessRules.registerError(code);
                lblException.Visible = true;
            }
            else
            {
                lblException.Visible = false;
                Server.Transfer("wfstudent.aspx");
            }
        
    }

    /// <summary>
    /// Handles the return click button event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbReturn_Click(object sender, EventArgs e)
    {
        Server.Transfer("wfstudent.aspx");
    }
}