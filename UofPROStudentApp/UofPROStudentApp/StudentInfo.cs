using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace UofPROStudentApp
{
    class StudentInfo
    {
        public static object FullName { get; private set; }
        public static object Email { get; private set; }
        public static object PhoneNumber { get; private set; }
        public static object Major { get; private set; }

        public static Students GetStudentInfo()
        {
            Console.WriteLine("Please enter your name");
            var studentName = Console.ReadLine();
            Console.WriteLine("Please enter your email.");
            var studentEmail = Console.ReadLine();
            Console.WriteLine("Please enter your phone number.");
            var studentPhone = Console.ReadLine();
            Console.WriteLine("What is your Major?");
            var studentMajor = Console.ReadLine();

            var newStudent = new Students
            {
                FullName = studentName,
                Email = studentEmail,
                PhoneNumber = studentPhone,
                Major = studentMajor
            };
            return newStudent;
        }

        public static void InsertStudent(SqlConnection connection, Students student)
        {
            var _insert = "INSERT INTO Students (FullName, Email, PhoneNumber, Major)" +
                          "Values (@FullName, @Email, @PhoneNumber, @Major)";
            var cmd = new SqlCommand(_insert, connection);

            cmd.Parameters.AddWithValue("FullName", student.FullName);
            cmd.Parameters.AddWithValue("Email", student.Email);
            cmd.Parameters.AddWithValue("PhoneNumber", student.PhoneNumber);
            cmd.Parameters.AddWithValue("Major", student.Major);

            cmd.ExecuteScalar();
        }
    }
}

