using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace UofPROAdminApp
{
    class AddCourse
    {
        public static Courses CreateCourse()
        {
            Console.WriteLine("Please enter the course name.");
            var courseName = Console.ReadLine();
            Console.WriteLine("Please enter the course number.");
            var courseNumber = Console.ReadLine();
            Console.WriteLine("Please enter the course level.");
            var courseLevel = Console.ReadLine();
            Console.WriteLine("Please enter the course room.");
            var courseRoom = Console.ReadLine();
            Console.WriteLine("Please enter the start time for this course.");
            var cStartTime = Console.ReadLine();

            var newCourse = new Courses
            {
                Name = courseName,
                Number = courseNumber,
                CourseLevel = courseLevel,
                Room = courseRoom,
                StartTime = cStartTime
            };
            return newCourse;
        }

        public static void InsertCoursetoBD(SqlConnection connection, Courses newCourse)
        {
            var _insert = "INSERT INTO Courses (Name, Number, CourseLevel, Room, StartTime)" +
                          "Values (@Name, @Number, @CourseLevel, @Room, @StartTime)";
            var cmd = new SqlCommand(_insert, connection);

            cmd.Parameters.AddWithValue("Name", newCourse.Name);
            cmd.Parameters.AddWithValue("Number", newCourse.Number);
            cmd.Parameters.AddWithValue("CourseLevel", newCourse.CourseLevel);
            cmd.Parameters.AddWithValue("Room", newCourse.Room);
            cmd.Parameters.AddWithValue("StartTime", newCourse.StartTime);
            cmd.ExecuteScalar();
        }
    }
}
