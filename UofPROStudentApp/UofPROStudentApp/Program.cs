using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace UofPROStudentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CONNECTION_TO_DATABASE = @"Server=localhost\SQLEXPRESS;Database=UniversityofPROforma;Trusted_Connection=True;";

            Console.WriteLine("Welcome to University of PROforma Student Portal");
            Console.WriteLine("---------------------------------------");


            using (var connection = new SqlConnection(CONNECTION_TO_DATABASE))
            {
                connection.Open();

                var portalOpen = true;
                while (portalOpen == true)
                {
                    Console.WriteLine("Please select from the following options:");
                    Console.WriteLine("1) View Schedule");
                    Console.WriteLine("2) Enroll in a Course");
                    Console.WriteLine("3) Exit");

                    var response = Console.ReadLine();

                    if (response == "1")
                    {
                        Console.WriteLine("Please enter your name.");
                        var studentName = Console.ReadLine();
                    
                        ViewEnrolledCourses.ViewCourses(connection, studentName);
                    }
                     else if (response == "2")
                     {
                        var newStudentInfo = StudentInfo.GetStudentInfo();
                        StudentInfo.InsertStudent(connection, newStudentInfo);

                        Console.WriteLine($"test in main program {newStudentInfo.FullName}");
                        //User Select course
                        var courseSelection = Enroll.SelectCourse(connection);
                        

                         Enroll.InsertStudentIntoCourse(connection, courseSelection, newStudentInfo);
                         //Console.WriteLine($"Successfully enrolled in {newCourse.Name}.");
                     }
                    else
                    {
                        Console.WriteLine("Goodbye.");
                        portalOpen = false;
                    }

                }
            }
        }
    }
}
