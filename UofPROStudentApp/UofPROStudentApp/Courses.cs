﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UofPROStudentApp
{
    class Courses
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string CourseLevel { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public string StartTime { get; set; }
        public string Student { get; set; }
        public string Professor { get; set; }


        public Courses(SqlDataReader reader)
        {

            //ID = (int)reader["ID"];
            Number = reader["Number"].ToString();
            CourseLevel = reader["CourseLevel"].ToString();
            Name = reader["Name"].ToString();
            //Room = reader["Room"].ToString();
        }

        public Courses()
        {

        }
    }
}