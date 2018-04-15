using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UofPROStudentApp
{
    class ViewEnrolledCourses
    {
        public static void ViewCourses(SqlConnection connection, string studentName)
        {

            var _select = "SELECT Courses.Name, Courses.Number, Courses.CourseLevel, Courses.StartTime, Courses.Room" +
                " FROM Courses" +
                " JOIN Enrollment ON Enrollment.CourseID = Courses.ID" +
                " JOIN Students ON Enrollment.StudentID = Students.ID" +
                $" WHERE Students.FullName = '{studentName}'";

            var query = new SqlCommand(_select, connection);
            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                var course = new Courses(reader);
                Console.WriteLine($"Course Number: {course.Number} | Course Name: {course.Name} | Course Level: {course.CourseLevel} | Course Start Time: {course.StartTime}");
            }
        }

    }
}
