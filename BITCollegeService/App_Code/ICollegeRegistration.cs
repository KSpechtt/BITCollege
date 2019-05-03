using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICollegeRegistration" in both code and config file together.
[ServiceContract]
public interface ICollegeRegistration
{
    /// <summary>
    /// 
    /// </summary>
	[OperationContract]
	void DoWork();

    /// <summary>
    /// Drops a selected course.
    /// </summary>
    /// <param name="registrationId">registered id</param>
    /// <returns>Whether the course dropped or not.</returns>
    [OperationContract]
    bool dropCourse(int registrationId);

    /// <summary>
    /// Registers a course to a student
    /// </summary>
    /// <param name="studentId">Students id</param>
    /// <param name="courseId">Course id</param>
    /// <param name="notes">Course notes</param>
    /// <returns>Returns validator code depending on if it was successful or not.</returns>
    [OperationContract]
    int registerCourse(int studentId, int courseId, string notes);

    /// <summary>
    /// Updates grade of a student
    /// </summary>
    /// <param name="grade">students grade</param>
    /// <param name="registrationId">registration id</param>
    /// <param name="notes">course notes</param>
    [OperationContract]
    void updateGrade(double grade, int registrationId, string notes);

}
