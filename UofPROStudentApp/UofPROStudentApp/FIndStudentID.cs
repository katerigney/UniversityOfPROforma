using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace UofPROStudentApp
{
    class FIndStudentID
    {
        public static int Go(SqlConnection connection, Students student)
        {

            var _select = "SELECT Students.ID" +
                " FROM Students" +
                $" WHERE Students.FullName = '{student.FullName}'";

            var query = new SqlCommand(_select, connection);
            var reader = query.ExecuteReader();

            var findStudent = new Students(reader);
            int studentID = findStudent.ID;

            return studentID;
        }
    }
}
