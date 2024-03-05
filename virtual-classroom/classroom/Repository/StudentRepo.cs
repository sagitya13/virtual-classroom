using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using classroom.models;
using classroom.Repository.Interface;

namespace classroom.Repository
{
    public class StudentRepo : IStudentRepo
    {
        readonly string connectionString = @"Data Source=APINP-ELPT4W3IG\SQLEXPRESS;Initial Catalog=backend;User ID=tap2023;Password=tap2023;Encrypt=False";

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT Id, UsersId, Password FROM Student";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Student student = new Student();
                                student.Id = reader.IsDBNull(0) ? (int?)null : reader.GetInt32(0);
                                student.UsersId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1);
                                student.Password = reader.IsDBNull(2) ? null : reader.GetString(2);

                                students.Add(student);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw; // Rethrow the exception to indicate failure
            }

            return students;
        }

        public Student GetStudentById(int id)
        {
            Student student = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT Id, UsersId, Password FROM Student WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                student = new Student();
                                student.Id = reader.IsDBNull(0) ? (int?)null : reader.GetInt32(0);
                                student.UsersId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1);
                                student.Password = reader.IsDBNull(2) ? null : reader.GetString(2);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw; // Rethrow the exception to indicate failure
            }

            return student;
        }

        public void AddStudent(Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string insertQuery = @"INSERT INTO Student (UsersId, Password)
                                           VALUES (@UsersId, @Password)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UsersId", student.UsersId);
                        command.Parameters.AddWithValue("@Password", student.Password);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("New student added successfully.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void DeleteStudent(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string deleteQuery = "DELETE FROM Student WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Student with ID {id} deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"No student found with ID {id}.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw; // Rethrow the exception to indicate failure
            }
        }
    }
}
