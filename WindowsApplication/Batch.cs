using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using BITCollege_KS.Models;

namespace WindowsApplication
{
    /// <summary>
    /// Represents a Batch class.
    /// </summary>
    public class Batch
    {
        BITCollege_KSContext db = new BITCollege_KSContext();
        ServiceReference1.CollegeRegistrationClient reference = new ServiceReference1.CollegeRegistrationClient();

        private string inputFileName;
        private string logFileName;
        private string logData;

        /// <summary>
        /// Processes errors that are caught.
        /// </summary>
        /// <param name="beforeQuery">List of Xelement objects from the before query</param>
        /// <param name="afterQuery">List of Xelement objects generated from the before query</param>
        /// <param name="message">Error message</param>
        private void processErrors(IEnumerable<XElement> beforeQuery, IEnumerable<XElement> afterQuery, string message)
        {

            IEnumerable<XElement> errors = beforeQuery.Except(afterQuery);
            foreach (XElement record in errors)
            {
                if (record.Elements() != afterQuery.Elements())
                {
                    logData += "\n--------ERROR-------\nFile: " + inputFileName + "\nProgram: " + record.Element("program") + "\nStudent Number: "
                        + record.Element("student_no") + "/nCourse Number: " + record.Element("course_no") + "\nRegistration Number: " + record.Element("registration_no") +
                        "\nType: " + record.Element("type") + "\nGrade: " + record.Element("grade") + "\nNotes: " + record.Element("notes") +
                        "\nNodes: " + record.Nodes().Count() + "\n" + message + "-------------\n";

                }
               
            }
        }

        /// <summary>
        /// This method is used to verify the attributes of the xml file’s root element
        /// </summary>
        /// <returns>If the attributes match up. True or False</returns>
        private bool processHeader()
        {
            bool validated = true;
            try
            {
                long checkSumNumber = 0;

                string today = DateTime.Today.ToShortDateString();

                XDocument xmlFile = XDocument.Load(inputFileName);

                XElement studentUpdate = xmlFile.Element("student_update");

                IEnumerable<XElement> transactions = studentUpdate.Descendants().Where(x => x.Name == "transaction");

                IEnumerable<XElement> studentNumbers = transactions.Descendants().Where(x => x.Name == "student_no");

                foreach (XElement value in studentNumbers)
                {
                    checkSumNumber += long.Parse(value.Value);
                }


                if (studentUpdate.Attributes().Count() != 3)
                {
                    throw new Exception("There is not 3 attributes");
                }


                string date = studentUpdate.Attribute("date").Value;
                DateTime time = DateTime.Parse(date);

                if (date != today)
                {
                    throw new Exception("The date does not match");
                }

                string xmlAcro = studentUpdate.Attribute("program").Value;

                if (db.Programs.Where(x => x.ProgramAcronym.Equals(xmlAcro)).Count() != 1)
                {
                    throw new Exception("The program acronym does not match");
                }

                string xmlCheckSum = studentUpdate.Attribute("checksum").Value;

                if (long.Parse(xmlCheckSum) != checkSumNumber)
                {
                    throw new Exception("The checksum numbers do not match");
                }


            }
            catch (Exception ex)
            {

                logData += ex.Message;
                validated = false;
            }

            return validated;
        }

        /// <summary>
        /// This method is used to verify the contents of the detail records in the xml file. 
        /// </summary>
        private void processDetails()
        {
            XDocument xmlFile = XDocument.Load(inputFileName);

            //Transaction validation

            IEnumerable<XElement> transaction = xmlFile.Descendants().Where(x => x.Name == "transaction");

            IEnumerable<XElement> transactionNodesCount = transaction.Where(x => x.Nodes().Count() == 7);

            processErrors(transaction, transactionNodesCount, "Does not contain 7 child nodes");

            //Program validation

            XElement studentUpdate = xmlFile.Element("student_update");

            string xmlAcro = studentUpdate.Attribute("program").Value;

            IEnumerable<XElement> programCheck = transactionNodesCount.Where(x => x.Element("program").Value == xmlAcro);

            processErrors(transactionNodesCount, programCheck, "Program attribute does not match");

            //Type validation
            int num ;

            IEnumerable<XElement> typeCheck = programCheck.Where(x=>int.TryParse(x.Element("type").Value, out num) == true);

            processErrors(programCheck, typeCheck, "The type node is not numeric");

            //Grade validation
            double number;

            IEnumerable<XElement> gradeCheck = typeCheck.Where(x => double.TryParse(x.Element("grade").Value, out number) == true || x.Element("grade").Value == "*");

            processErrors(typeCheck,gradeCheck,"The grade is not numeric or *");

            //Type validation #2

            IEnumerable<XElement> typeCheckTwo = gradeCheck.Where(x => int.Parse(x.Element("type").Value) == 1 || int.Parse(x.Element("type").Value) == 2);

            processErrors(gradeCheck, typeCheckTwo, "Type node is not 1 or 2");

            //Grade validation #2

            IEnumerable<XElement> gradeCheckTwo = typeCheckTwo.Where(x => (x.Element("type").Value == "1" 
                && x.Element("grade").Value == "*") 
                ||
                (x.Element("type").Value == "2" 
                && double.Parse(x.Element("grade").Value) >= 0 
                && double.Parse(x.Element("grade").Value) <= 100) );

            processErrors(typeCheckTwo, gradeCheckTwo, "The input type value does not match the rules for grade value");

            //Student num validation

            IEnumerable<long> studentNumbers = db.Students.Select(x => x.StudentNumber);

            IEnumerable<XElement> studentNumCheck = gradeCheckTwo.Where(x => studentNumbers.Contains(long.Parse(x.Element("student_no").Value)));

            processErrors(gradeCheckTwo, studentNumCheck, "Student number node does not match any student number in database");

            //Course number validation

            IEnumerable<string> courseNumbers = db.Courses.Select(x => x.CourseNumber);

            IEnumerable<XElement> courseNumbersCheck = studentNumCheck.Where(x=>(x.Element("type").Value == "2" && x.Element("course_no").Value == "*") ||
                (courseNumbers.Contains(x.Element("course_no").Value)));

            processErrors(studentNumCheck,courseNumbersCheck,"The course number does not match any in the database or does not equal * if type is 2");



            //Registation number validation

            IEnumerable<long> regNumbers = db.Registrations.Select(x=>x.RegistrationNumber);

            IEnumerable<XElement> regNumberCheck = courseNumbersCheck.Where(x=>(x.Element("type").Value == "1" && x.Element("registration_no").Value == "*") ||
                regNumbers.Contains(long.Parse(x.Element("registration_no").Value)));

            processErrors(courseNumbersCheck,regNumberCheck,"The reg number does no match any in the database or does not equal * if type is 1");


            //All validated
            processTransactionRecords(regNumberCheck);
        }

        /// <summary>
        /// This method processes all good transactions.
        /// </summary>
        /// <param name="transactionRecords">All good transactions</param>
        private void processTransactionRecords(IEnumerable<XElement> transactionRecords)
        {
            IEnumerable<Student> students = db.Students;

            IEnumerable<Course> courses = db.Courses;
            
            IEnumerable<Registration> registrations = db.Registrations;

            IEnumerable<XElement> registerStudents = transactionRecords.Where(x=>x.Element("type").Value == "1");

            IEnumerable<XElement> updateGrade = transactionRecords.Where(x=>x.Element("type").Value == "2");


            foreach (XElement records in transactionRecords)
            {
                if (records.Element("type").Value == "1")
                {
                    int studentNum = int.Parse(records.Element("student_no").Value);
                    int studentId = students.Where(x => x.StudentNumber == studentNum).Select(x => x.StudentId).Single();

                    string courseNum = records.Element("course_no").Value;
                    int courseId = courses.Where(x => x.CourseNumber == courseNum).Select(x => x.CourseId).Single();

                    string notes = records.Element("notes").Value;

                    reference.registerCourse(studentId, courseId, notes);

                    logData += "\nSuccessful Registration Student " + studentNum + " course " + courseNum + "\n";
                }
                else
                {
                    int studentNum = int.Parse(records.Element("student_no").Value);

                    int regNum = int.Parse(records.Element("registration_no").Value);
                    int regId = registrations.Where(x => x.RegistrationNumber == regNum).Select(x => x.RegistrationId).Single();

                    double grade = double.Parse(records.Element("grade").Value);

                    string notes = records.Element("notes").Value;



                    reference.updateGrade(grade, regId, notes);

                    logData += "\ngrade " + grade + " applied to student " + studentNum + " for registration " + regNum + "\n";
                }
            }

        }

        /// <summary>
        /// Writes data from the logfile.
        /// </summary>
        /// <returns>All messages that were sent to the log data.</returns>
        public string writeLogData()
        {
            string contentsLogData = "";

            if (File.Exists("COMPLETE-" + inputFileName))
            {
                File.Delete("COMPLETE-" + inputFileName);
            }

            if (File.Exists(inputFileName))
            {
                File.Move(inputFileName, "COMPLETE-" + inputFileName);
            }

            if(!File.Exists(logFileName))
            {
                logFileName = "LOG " + inputFileName.Replace(".xml", ".txt");
            }

            StreamWriter stream = new StreamWriter(logFileName, true);
            stream.Write(logData);
            stream.Close();
            contentsLogData = logData;
            logData = "";
            logFileName = "";      
                
            
            return contentsLogData;
        }

        /// <summary>
        /// Processes all xml transaction files.
        /// </summary>
        /// <param name="program">Program Acryonym</param>
        /// <param name="key">Key for encryption</param>
        public void processTransmission(string program, string key)
        {
            try
            {
                inputFileName = DateTime.Today.Year + "-" + DateTime.Today.DayOfYear + "-" + program + ".xml";

                string encryptedFileName = inputFileName + ".encrypted";

                logFileName = "LOG " + inputFileName.Replace(".xml", ".txt");

                if (File.Exists(encryptedFileName))
                {
                    Utility.Encryption.decrypt(encryptedFileName, inputFileName, key);
                        
                }
                else
                {
                    logData += "The encrypted file does not exist";
                }

                if (!File.Exists(inputFileName))
                {
                    logData += "\nThe file " + inputFileName + " does not exist\n";
                }
                else
                {
                    if (!processHeader())
                    {
                        logData += "\nUnable to process header\n";
                    }
                    else
                    {
                        processDetails();
                    }

                }
            }
               
         
            catch (Exception ex)
            {

                logData += "\n" + ex.Message + "\n";
            }
        }

    }
}
