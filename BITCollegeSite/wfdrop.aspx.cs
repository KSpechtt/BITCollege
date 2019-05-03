using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_KS.Models;

/// <summary>
/// Represents a page for drop page.
/// </summary>
public partial class wfdrop : System.Web.UI.Page
{
    BITCollege_KSContext db = new BITCollege_KSContext();

    /// <summary>
    /// Handles the load event for the page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetRecords();
        }
    }

    /// <summary>
    /// Handles the Page index change event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

        dvRegistrations.PageIndex = e.NewPageIndex;
        GetRecords();
    }

    /// <summary>
    /// Handles the drop button link event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButtonDrop_Click(object sender, EventArgs e)
    {

        Registration reg = new Registration();
        reg.RegistrationId = int.Parse(dvRegistrations.Rows[0].Cells[1].Text);

        ServiceReference1.CollegeRegistrationClient service = new ServiceReference1.CollegeRegistrationClient();

        service.dropCourse(reg.RegistrationId);

        Server.Transfer("wfstudent.aspx");
        
       
    }

    /// <summary>
    /// Handles the return button click event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButtonReturn_Click(object sender, EventArgs e)
    {
        Server.Transfer("wfstudent.aspx");
    }

    /// <summary>
    /// Gets the records for the page.
    /// </summary>
    protected void GetRecords()
    {
        try
        {
            Student studentID = (Student)Session["SessionStudentNumber"];
            string courseNumbers = (string)Session["SessionSelectedCourseNumber"];
            IQueryable<Course> courseList = (IQueryable<Course>)Session["SessionCourse"];

            IQueryable<int> courseID = db.Courses.Where(x => x.CourseNumber == courseNumbers).Select(x => x.CourseId);
            int theCourseID = courseID.Single();
            IQueryable<Registration> registrationRecords = db.Registrations.Where(x => x.StudentId == studentID.StudentId).Where(x=> x.CourseId == theCourseID);
            dvRegistrations.DataSource = registrationRecords.ToList();
            this.DataBind();

            if (dvRegistrations.Rows[4].Cells[1].Text == "&nbsp;")
            {
                LinkButtonDrop.Enabled = true;
            }
            else
            {
                LinkButtonDrop.Enabled = false;

            }
        }
        catch (Exception ex)
        {

            lblException.Text = ex.Message;
            lblException.Visible = true;
        }
    }
}