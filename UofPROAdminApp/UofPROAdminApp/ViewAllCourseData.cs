using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace UofPROAdminApp
{
    class ViewAllCourseData
    {
        public static List<Courses> GetAllCourseData(SqlConnection connection)
        {
            var _select = "SELECT Courses.Number, Courses.Name, Courses.Room, Professors.Name as Professor, Students.FullName as Student" +
                " FROM Courses" +
                " JOIN InSession ON InSession.CourseID = Courses.ID" +
                " FULL OUTER JOIN Professors ON InSession.ProfID = Professors.ID" +
                " JOIN Enrollment ON Enrollment.CourseID = Courses.ID" +
                " FULL OUTER JOIN Students ON Enrollment.StudentID = Students.ID";
                //WHAT KIND OF JOINS HERE???

            var query = new SqlCommand(_select, connection);
            var reader = query.ExecuteReader();
            var _rv = new List<Courses>();
            while (reader.Read())
            {
                var course = new Courses(reader);
                Console.WriteLine($"{course.Number} | {course.Name} | {course.Room} | {course.Professor} | {course.Student}");
            }
            return _rv;
        }
    }
}
