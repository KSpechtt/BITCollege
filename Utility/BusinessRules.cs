using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility   
{

    /// <summary>
    /// Represents a static utility class.
    /// </summary>
    public static class Utility
    {

        /// <summary>
        /// Formats a string to remove a certain index and beyond.
        /// </summary>
        /// <param name="name">The name of the string that you want formatted.</param>
        /// <param name="stringVar">The index in which will be removed.</param>
        /// <returns></returns>
        public static string StringFormat(string name, string stringVar)
        {
            return string.Format("{0}", name.Substring(0, name.IndexOf(stringVar)));
        }
    }

    /// <summary>
    /// given:  Enum listing course types
    /// </summary>
    public enum CourseType
    {
        GRADED, MASTERY, AUDIT
    }

    /// <summary>
    /// given:  Struct to align letter grades with gradepoint values
    /// Acts as an ENUM but with double values
    /// </summary>
    public struct GradePointValue
    {
        public const double A_PLUS = 4.5;
        public const double A = 4;
        public const double B_PLUS = 3.5;
        public const double B = 3;
        public const double C_PLUS = 2.5;
        public const double C = 2;
        public const double D = 1;
        public const double F = 0;
        public const double PASS = 4;
        public const double FAIL = 0;
        public const double INCOMPLETE = -1;
    }

    public static class BusinessRules
    {
        const string UNDEFINED = "";

        /// <summary>
        /// Provides a registration error.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        /// <returns>Returns a message explaining the error.</returns>
        public static string registerError(int errorCode)
        {
            string msg;

            if (errorCode == -100)
            {
                msg = "Student can't register for a course in which there is already an ungraded registration.";
            }
            else if(errorCode == -200)
            {
                msg = "Student has exceeded maximum attempts on mastery course.";
            }
            else if(errorCode == -300)
            {
                msg = "An error has occured while updating the registration.";
            }
            else
            {
                msg = "Unknown error.";
            }

            return msg;
        }

        /// <summary>
        /// Given:
        /// defines the mask display format for the various course types
        /// </summary>
        /// <param name="accountType">string course type name</param>
        /// <returns>string format</returns>
        public static string courseFormat(string courseType)
        {
            string[] COURSE_TYPE = { "Audit", "Mastery", "Graded"};
            string[] COURSE_MASK = { ">L-00-00", ">L-00-0-00", ">L-00-00-00" };


            //initial format (empty string)
            string format = UNDEFINED;

            //compare account type to predefined types
            for (int i = 0; i < COURSE_TYPE.Length; i++)
            {
                //if a match, return the corresonding mask
                if(courseType.ToLower() == COURSE_TYPE[i].ToLower())
                {
                    format = COURSE_MASK[i];
                    break;
                }
            }
            //return the mask or empty string
            return format;
        }



        /// <summary>
        /// Given:
        /// CourseTypeLookup:  Matches string description
        /// with CourseType enum
        /// </summary>
        /// <param name="courseDescription">String description of course</param>
        /// <returns>CourseType enum</returns>
        public static CourseType courseTypeLookup(string courseDescription)
        {
            CourseType courseType = CourseType.AUDIT;

            //switch course.CourseType
            switch (courseDescription)
            {
                case "Graded":
                    courseType = CourseType.GRADED;
                    break;
                case "Mastery":
                    courseType = CourseType.MASTERY;
                    break;
                default:
                    courseType = CourseType.AUDIT;
                    break;
            }

            return courseType;
        }


        /// <summary>
        /// Given:  Looks up letter grade based on course type and earned grade
        /// </summary>
        /// <param name="grade">double earned grade</param>
        /// <param name="courseType">uses course type enum</param>
        /// <returns></returns>
        public static double gradeLookup(double grade, CourseType courseType)
        {
            double gradePoint = GradePointValue.INCOMPLETE;

            switch (courseType)
            {
                case CourseType.GRADED:
                    {
                        if (grade >= 90)
                        {
                            gradePoint = GradePointValue.A_PLUS;
                        }
                        else if (grade >= 80)
                        {
                            gradePoint = GradePointValue.A;
                        }
                        else if (grade >= 75)
                        {
                            gradePoint = GradePointValue.B_PLUS;
                        }
                        else if (grade >= 70)
                        {
                            gradePoint = GradePointValue.B;
                        }
                        else if (grade >= 65)
                        {
                            gradePoint = GradePointValue.C_PLUS;
                        }
                        else if (grade >= 60)
                        {
                            gradePoint = GradePointValue.C;
                        }
                        else if (grade >= 50)
                        {
                            gradePoint = GradePointValue.D;
                        }
                        else
                        {
                            gradePoint = GradePointValue.F;
                        }
                        break;
                    }
                case CourseType.MASTERY:
                    {
                        gradePoint = grade >= 75 ? GradePointValue.PASS : GradePointValue.FAIL;
                        break;
                    }
                default:
                    {
                        gradePoint = GradePointValue.INCOMPLETE;
                        break;
                    }
            }

            return gradePoint;

        }

    }
}
