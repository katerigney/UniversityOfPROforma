using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace UofPROAdminApp
{
    class ViewEnrollment
    {

        public static List<Courses> GetEnrollment(SqlConnection connection)
        {
            var _select = "SELECT Courses.Name, Courses.Number, Students.FullName as Student" +
                " FROM Courses" +
                " JOIN Enrollment ON Enrollment.CourseID = Courses.ID" +
                " JOIN Students ON Enrollment.StudentID = Students.ID" ;

            var query = new SqlCommand(_select, connection);
            var reader = query.ExecuteReader();
            var _rv = new List<Courses>();
            while (reader.Read())
            {
                var course = new Courses(reader);
                Console.WriteLine($"{course.Student} is enrolled in {course.Number} {course.Name} this semester.");
            }
            return _rv;
        }
    }
}
