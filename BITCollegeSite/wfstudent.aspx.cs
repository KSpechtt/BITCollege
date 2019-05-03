using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_KS.Models; 
using com.dataaccess.www;


/// <summary>
/// Represents a class for student page.
/// </summary>
public partial class wfstudent : System.Web.UI.Page
{
    BITCollege_KSContext db = new BITCollege_KSContext();
    Student sessionStudent;
    IQueryable<Course> sessionCourse;
    com.dataaccess.www.NumberConversion numTick = new com.dataaccess.www.NumberConversion();
    DateTime time = new DateTime();
    
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
                long studentNumber = long.Parse(Page.User.Identity.Name);
                Student student = db.Students.Where(x => x.StudentNumber == studentNumber).SingleOrDefault();
                sessionStudent = student;
                Session["SessionStudentNumber"] = sessionStudent;
                lblStudentName.Text = student.FullName;


                ulong ticks = (ulong)time.Ticks;
                lblServiceResults.Text = numTick.NumberToWords((ulong)(DateTime.Today.Ticks));
                

                IQueryable<Course> course = db.Registrations.Where(x => x.StudentId == student.StudentId).Select(x => x.Course);

                dgvCourses.DataSource = course.ToList();
                sessionCourse = course;
                Session["SessionCourse"] = sessionCourse;
                this.DataBind();
            }

            catch (Exception ex)
            {
                lblStudentName.Visible = false;
                lblServiceResults.Visible = false;
                lbRegisterForCourse.Enabled = false;
                lblExceptionResults.Text = ex.Message;
                lblExceptionResults.Visible = true;

            }
        }
    }

    /// <summary>
    /// Handles the selected index change event of the page.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dgvCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string selectedCourse = dgvCourses.Rows[dgvCourses.SelectedIndex].Cells[1].Text;
            Session["SessionSelectedCourseNumber"] = selectedCourse;

            Server.Transfer("wfdrop.aspx");
        }
        catch (Exception ex)
        {

            lblExceptionResults.Text = ex.Message;
            lblExceptionResults.Visible = true;
        }
    }

    /// <summary>
    /// Handles the course registration click button event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbRegisterForCourse_Click(object sender, EventArgs e)
    {
        Server.Transfer("wfRegister.aspx");
    }
}