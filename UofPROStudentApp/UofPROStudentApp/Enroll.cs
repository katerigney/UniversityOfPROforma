using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace UofPROStudentApp
{
    class Enroll
    {
        
        public static string SelectCourse(SqlConnection connection)
        {
            var courseList = new List<Courses>();

            var _select = "SELECT Courses.Name, Courses.Number, Courses.CourseLevel, Courses.StartTime" +
                " FROM Courses";

            var query = new SqlCommand(_select, connection);
            var reader = query.ExecuteReader();
            var _rv = new List<Courses>();
            while (reader.Read())
            {
                var course = new Courses(reader);
                Console.WriteLine($"Course Number: {course.Number} | Course Name: {course.Name} | Course Level: {course.CourseLevel} | Course Start Time: {course.StartTime}");
            }

            Console.WriteLine("Which course would you like to enroll in? Please provide the course number.");
            var studentCourseSelection = Console.ReadLine();
            return studentCourseSelection;
        }

        public static void InsertStudentIntoCourse(SqlConnection connection, string courseSelection, Students student)
        {
            //select from list of students where student.name == student.name
            int studentID = FIndStudentID.Go(connection,student); //get student ID

            //select from list of courses where courseSelection == courseID
            int courseID = FindCourseID.Go(connection, courseSelection);//get course ID

            //insert into enrollment table course ID and StudentID
            var _insert = "INSERT INTO Enrollment (CourseID, StudentID)" +
                          "Values (@CourseID, @StudentID)";
            var cmd = new SqlCommand(_insert, connection);

            cmd.Parameters.AddWithValue("CourseID", courseID);
            cmd.Parameters.AddWithValue("StudentID", studentID);
            cmd.ExecuteScalar();
        }
    }
}
