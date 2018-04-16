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
            Console.WriteLine($"test Find Student ID Method {student.FullName}");

            //PROBLEM: ONly pulling the ID, but the app is expcting everything
            var _select = "SELECT Students.ID" +
                " FROM Students" +
                $" WHERE Students.FullName = @Name";

            var query = new SqlCommand(_select, connection);
            query.Parameters.AddWithValue("Name", student.FullName);
            var reader = query.ExecuteReader();
            reader.Read();
            //var findStudent = new Students(reader);
            int studentID = (int)reader["ID"];

            reader.Close();

            return studentID;
        }
    }
}
