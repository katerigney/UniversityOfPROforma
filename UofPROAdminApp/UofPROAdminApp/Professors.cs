
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UofPROAdminApp
{
    class Professors
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public Professors(SqlDataReader reader)
        {
            ID = (int)reader["ID"];
            Name = reader["Name"].ToString();
            Title = reader["Title"].ToString();
        }

        public Professors()
        {

        }
    }
}