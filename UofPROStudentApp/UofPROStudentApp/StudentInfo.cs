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
    }
}
