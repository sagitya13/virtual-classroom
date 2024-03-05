
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection.PortableExecutable;
using classroom.models;
using classroom.Repository.Interface;

namespace classroom.Repository
{
    public class AssignmentRepo : IAssignmentRepo
    {
        readonly string connectionString = "";
        public AssignmentRepo()
        {
            connectionString = @"Data Source=APINP-ELPT4W3IG\SQLEXPRESS;Initial Catalog=backend;User ID=tap2023;Password=tap2023;Encrypt=False";

        }
         public void CreateAssignment(Assignment assignment)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string insertQuery = @"INSERT INTO Assignment (id,questionId, AssignmentTitle, StartDate, EndDate, MaxPoints, NumberOfQuestions)
                                   VALUES (@id,@questionId, @AssignmentTitle, @StartDate, @EndDate, @MaxPoints, @NumberOfQuestions)";
                                //   SELECT CAST(SCOPE_IDENTITY() as int);";
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                             
                            command.Parameters.AddWithValue("@id", assignment.id);
                            command.Parameters.AddWithValue("@QuestionId", assignment.questionId);
                            command.Parameters.AddWithValue("@AssignmentTitle", assignment.AssignmentTitle);
                            command.Parameters.AddWithValue("@StartDate", assignment.StartDate);
                            command.Parameters.AddWithValue("@EndDate", assignment.EndDate);
                            command.Parameters.AddWithValue("@MaxPoints", assignment.MaxPoints);
                            command.Parameters.AddWithValue("@NumberOfQuestions", assignment.NumberOfQuestions);
                            connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine("New assignment inserted successfully");// Assuming the Id is auto-generated and returned by the database
                    }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    // Consider handling the exception more gracefully in a production environment
                }
            }
       
        public void DeleteAssignment(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string deleteQuery = @"DELETE FROM Assignment WHERE id = @Id";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            Console.WriteLine("No assignment found with the given ID");
                        }
                        else
                        {
                            Console.WriteLine("Assignment deleted successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Consider handling the exception more gracefully in a production environment
            }
        }

        public List<Assignment> GetAssignmentById(int id)
        {
            List<Assignment> assignments = new List<Assignment>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT * FROM Assignment WHERE id = @Id";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Assignment assignment = new Assignment();

                                assignment.id = reader.GetInt32(reader.GetOrdinal("id"));
                                assignment.AssignmentTitle = reader.GetString(reader.GetOrdinal("AssignmentTitle"));
                                assignment.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")).ToString("yyyy-MM-dd");
                                assignment.EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")).ToString("yyyy-MM-dd");
                                assignment.MaxPoints = reader.GetDecimal(reader.GetOrdinal("MaxPoints"));
                                assignment.NumberOfQuestions = reader.GetInt32(reader.GetOrdinal("NumberOfQuestions"));
                                assignment.result = reader.GetInt32(reader.GetOrdinal("result"));
                                assignment.questionId = Convert.ToInt32(reader["questionId"]);
                                Console.WriteLine(assignment.questionId);
                                assignments.Add(assignment);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Consider handling the exception more gracefully in a production environment
            }

            return assignments;
        }
    

        public List<Assignment> GetAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT * FROM Assignment";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Assignment assignment = new Assignment();

                                assignment.id = reader.GetInt32(reader.GetOrdinal("id"));
                                assignment.AssignmentTitle = reader.GetString(reader.GetOrdinal("AssignmentTitle"));
                                assignment.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")).ToString("yyyy-MM-dd");
                                assignment.EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")).ToString("yyyy-MM-dd");
                                assignment.MaxPoints = reader.GetDecimal(reader.GetOrdinal("MaxPoints"));
                                    assignment.NumberOfQuestions = reader.GetInt32(reader.GetOrdinal("NumberOfQuestions"));
                                 assignment.result = reader.IsDBNull(reader.GetOrdinal("result")) ? 0 : reader.GetInt32(reader.GetOrdinal("result"));
                                assignment.questionId = Convert.ToInt32(reader["questionId"]);
                               Console.WriteLine(assignment.questionId);
                                assignments.Add(assignment);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Consider handling the exception more gracefully in a production environment
            }

            return assignments;
        }

       
    }
}
      