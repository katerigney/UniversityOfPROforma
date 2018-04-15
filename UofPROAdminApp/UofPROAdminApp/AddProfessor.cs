using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace UofPROAdminApp
{
    class AddProfessor
    {
        public static Professors CreateProf()
        {
            Console.WriteLine("Please enter the professor's title.");
            var pTitle = Console.ReadLine();
            Console.WriteLine("Please enter the professor's full name.");
            var pName = Console.ReadLine();

            var newProfessor = new Professors
            {
                Name = pName,
                Title = pTitle
            };
            return newProfessor;
        }

        public static void InsertProftoBD(SqlConnection connection, Professors newProfessor)
        {
            var _insert = "INSERT INTO Professors (Name, Title)" + 
                          "Values (@Name, @Title)";
            var cmd = new SqlCommand(_insert, connection);

            cmd.Parameters.AddWithValue("Name", newProfessor.Name);
            cmd.Parameters.AddWithValue("Title", newProfessor.Title);
            cmd.ExecuteScalar();
        }
    }
}
