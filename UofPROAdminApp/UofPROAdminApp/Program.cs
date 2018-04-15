using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UofPROAdminApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CONNECTION_TO_DATABASE = @"Server=localhost\SQLEXPRESS;Database=UniversityofPROforma;Trusted_Connection=True;";

            Console.WriteLine("Welcome to University of PROforma Admin");

            using (var connection = new SqlConnection(CONNECTION_TO_DATABASE))
            {
                connection.Open();

                var adminWorking = true;
                while (adminWorking == true)
                {
                    Console.WriteLine("Please select from the following options:");
                    Console.WriteLine("1) Add Professor");
                    Console.WriteLine("2) Add Course");
                    Console.WriteLine("3) View Student Enrollment");
                    Console.WriteLine("4) View All Courses");
                    Console.WriteLine("5) Exit");

                    var response = Console.ReadLine();

                    if (response == "1")
                    {
                        //Add new professor data
                        var newProfessor = AddProfessor.CreateProf();

                        //insert new professor data into DB
                        AddProfessor.InsertProftoBD(connection, newProfessor);
                        Console.WriteLine($"Successfully added {newProfessor.Title} {newProfessor.Name}.");
                    }
                    else if (response == "2")
                    {
                        //Add new course data
                        var newCourse = AddCourse.CreateCourse();

                        //insert new professor data into DB
                        AddCourse.InsertCoursetoBD(connection, newCourse);
                        Console.WriteLine($"Successfully added {newCourse.Name}.");
                    }
                    else if (response == "3")
                    {
                        ViewEnrollment.GetEnrollment(connection);
                    }
                    else if (response == "4")
                    {
                        //View all Classes, who is teaching them, and who is enrolled

                    }
                    else
                    {
                        Console.WriteLine("Goodbye.");
                        adminWorking = false;
                    }

                }
            }
        }
    }
}
