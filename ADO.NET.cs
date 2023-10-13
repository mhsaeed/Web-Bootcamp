using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {


            string connectionString = "Server=cmdlhrdb01;Database=5064_DB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 1. Execute Stored Procedure to Get All Employees
                using (SqlCommand command = new SqlCommand("GetAllStudents", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["StudentID"]}, FirstName: {reader["FirstName"]},  LastName: {reader["LastName"]},Age: {reader["Age"]}, CourseID: {reader["CourseID"]}");
                    }
                    connection.Close();
                }

                // 2. Execute Stored Procedure to Add an Employee
                using (SqlCommand command = new SqlCommand("AddStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", "Hamza");
                    command.Parameters.AddWithValue("@LastName", "Gates");
                    command.Parameters.AddWithValue("@Age", 30);
                    command.Parameters.AddWithValue("@CourseID", 1);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                // 3. Execute Stored Procedure to Update an Employee's Age
                using (SqlCommand command = new SqlCommand("UpdateStudentAge", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", 1);
                    command.Parameters.AddWithValue("@NewAge", 41);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                // 4. Execute Stored Procedure to Delete an Employee
                using (SqlCommand command = new SqlCommand("DeleteStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", 1);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM Students WHERE CourseID IS NULL; ", connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["StudentID"]}, FirstName: {reader["FirstName"]},  LastName: {reader["LastName"]},Age: {reader["Age"]}, CourseID: {reader["CourseID"]}");
                    }
                    connection.Close();
                }
                using (SqlCommand command = new SqlCommand("SELECT Courses.CourseName, COUNT(*) AS EnrollmentCount FROM Courses LEFT JOIN Students ON Courses.CourseID = Students.CourseID GROUP BY Courses.CourseName ORDER BY EnrollmentCount DESC ", connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"CourseName: {reader["CourseName"]},EnrollmentCount: {reader["EnrollmentCount"]} ");
                    }
                    connection.Close();
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM Students WHERE Age > (SELECT AVG(Age) FROM Students); ", connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["StudentID"]}, FirstName: {reader["FirstName"]},  LastName: {reader["LastName"]},Age: {reader["Age"]}, CourseID: {reader["CourseID"]}");
                    }
                    connection.Close();
                }
            }
            Console.ReadKey();
        }
    }
}
