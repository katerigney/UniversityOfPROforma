using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace UofPROStudentApp
{
    class FindCourseID
    {
        public static int Go(SqlConnection connection, string courseSelection)
        {
            Console.WriteLine($"test Find Course ID Method {courseSelection}");

            var _select = "SELECT Courses.ID" +
                " FROM Courses" +
                $" WHERE Courses.Number = @courseSelection";

            var query = new SqlCommand(_select, connection);
            query.Parameters.AddWithValue("courseSelection", courseSelection);
            var reader = query.ExecuteReader();
            reader.Read();
            //var findcourse = new Courses(reader);
            int courseID = (int)reader["ID"];

            reader.Close();

            return courseID;
        }
    }
}
