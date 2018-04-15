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

            var _select = "SELECT Courses.ID" +
                " FROM Courses" +
                $" WHERE Courses.Number = '{courseSelection}'";

            var query = new SqlCommand(_select, connection);
            var reader = query.ExecuteReader();

            var findcourse = new Courses(reader);
            int courseID = findcourse.ID;

            return courseID;
        }
    }
}
