using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BITCollege_KS.Models;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CollegeRegistration" in code, svc and config file together.

/// <summary>
/// Represents the college interface.
/// </summary>
public class CollegeRegistration : ICollegeRegistration
{
    BITCollege_KSContext db = new BITCollege_KSContext();

    public void DoWork()
    {
    }

    /// <summary>
    /// Drops a selected course.
    /// </summary>
    /// <param name="registrationId">registered id</param>
    /// <returns>Whether the course dropped or not.</returns>
    public bool dropCourse(int registrationId)
    {
        try
        {
            Registration regId = RetrieveRegistrationRecord(registrationId);
            db.Registrations.Remove(regId);
            db.SaveChanges();
        }
        catch (Exception)
        {

            return false;
        }

        return true;
    }

    /// <summary>
    /// Registers a course to a student
    /// </summary>
    /// <param name="studentId">Students id</param>
    /// <param name="courseId">Course id</param>
    /// <param name="notes">Course notes</param>
    /// <returns>Returns validator code depending on if it was successful or not.</returns>
    public int registerCourse(int studentId, int courseId, string notes)
    {
        int code = 0; int masteryAttemptsLimit = 0; int regAttemptLimit = 0;

        IQueryable<Registration> incompleteGradeNull = db.Registrations.Where(x => x.Grade == null).Where(x => x.CourseId == courseId).Where(x => x.StudentId == studentId);

        Course masteryCourse = db.Courses.Where(x => x.CourseId == courseId).SingleOrDefault();//.Select(x => x.CourseType).SingleOrDefault();

        //If student exceed max attempts of mastery course
        if (masteryCourse.CourseType == "Mastery")
        {
            masteryAttemptsLimit = db.MasteryCourses.Where(x => x.CourseId == courseId).Select(x => x.MaximumAttempts).SingleOrDefault();
            regAttemptLimit = db.Registrations.Where(x => x.CourseId == courseId).Where(x => x.StudentId == studentId).Count();

            if (masteryAttemptsLimit <= regAttemptLimit)
            {
                code = -200;
            }
        }
        //if a student already Has an ungraded registration.
        else if (incompleteGradeNull.Count() > 0)
        {
            code = -100;
        }
        //registration successful
        if(code == 0)
        {
            try
            {
                Registration newRegister = new Registration();
                newRegister.StudentId = studentId;
                newRegister.CourseId = courseId;
                newRegister.Notes = notes;
                newRegister.RegistrationDate = DateTime.Today;
                newRegister.setNextRegistrationNumber();
                db.Registrations.Add(newRegister);
                db.SaveChanges();
                Student student = db.Students.Where(x => x.StudentId == newRegister.StudentId).SingleOrDefault();
                double tuitionAmount = db.Courses.Where(x => x.CourseId == newRegister.CourseId).Select(x=>x.TuitionAmount).SingleOrDefault();
                double rate = student.GPAState.tuitionRateAdjustment(student);
                double cost = tuitionAmount * rate;
                student.OutstandingFees += cost;
                db.SaveChanges();
                code = 0;
            }
            catch (Exception ex)
            {
                code = -300;
            }
        }

        return code;

    }

    /// <summary>
    /// Updates grade of a student
    /// </summary>
    /// <param name="grade">students grade</param>
    /// <param name="registrationId">registration id</param>
    /// <param name="notes">course notes</param>
    public void updateGrade(double grade, int registrationId, string notes)
    {
        Registration regId = RetrieveRegistrationRecord(registrationId);
        regId.Grade = grade;
        regId.Notes = notes;
        db.SaveChanges();
        calculateGPA(regId.StudentId);
        db.SaveChanges();
    }


    /// <summary>
    /// Calculates the new GPA
    /// </summary>
    /// <param name="studentId">Students id</param>
    /// <returns>Returns the new gpa number</returns>
    /// 

    // 
    //ASK LAURIE HOW THE RETURN WORKS. SHOULD THE METHOD BE private double? SINCE WE DONT WANT IT TO RETURN A 0 IF ITS AN AUDIT COURSE THAN GPA WILL BE 0 AND NOT EMPTY.
    private double calculateGPA(int studentId)
    {
        IQueryable<Registration> allRegRecords = db.Registrations.Where(x => x.StudentId == studentId);
        double totalGPV = 0;
        double totalCH = 0;
        double courseGPA = 0;
        double? gpa = null;
        foreach (Registration records in allRegRecords)
        {
            if (records.Grade != null)
            {
                double? grade;
                Course course = records.Course;//db.Courses.Where(x => x.CourseId == records.CourseId).SingleOrDefault();
                grade = records.Grade;
                Utility.CourseType courseType = Utility.BusinessRules.courseTypeLookup(course.CourseType);
                double gradePointValue;
                gradePointValue = Utility.BusinessRules.gradeLookup((double)grade, courseType);
                if (courseType != Utility.CourseType.AUDIT)
                {
                    courseGPA = course.CreditHours * gradePointValue;
                    totalCH += course.CreditHours;
                    totalGPV += courseGPA;
                } 
            }
        }

        if (totalCH == 0 && courseGPA == 0)
        {
            gpa = null;
        }
        else
        {
            gpa = totalGPV / totalCH;
        }
            Student student = db.Students.Where(x => x.StudentId == studentId).SingleOrDefault();
            student.GradePointAverage = gpa;
            student.changeState();
            db.SaveChanges();
        
        if (gpa == null)
        {
            gpa = 0;
        }
        return (double)gpa;
    }

    /// <summary>
    /// Retrieves a registration record.
    /// </summary>
    /// <param name="registrationId">registration id</param>
    /// <returns>A registration record.</returns>
    private Registration RetrieveRegistrationRecord(int registrationId)
    {
        Registration regId = db.Registrations.Where(x => x.RegistrationId == registrationId).SingleOrDefault();
        return regId;
    }
}
