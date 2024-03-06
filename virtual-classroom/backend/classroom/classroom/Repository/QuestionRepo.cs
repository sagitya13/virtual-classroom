using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using classroom.models;
using classroom.Repository.Interface;
using System.Globalization;

namespace classroom.Repository
{
    public class QuestionRepo : IQuestionRepo
    {
        readonly string connectionString="";

        public QuestionRepo()
        {
            connectionString = @"Data Source=APINP-ELPT4W3IG\SQLEXPRESS;Initial Catalog=backend;User ID=tap2023;Password=tap2023;Encrypt=False";
        }

        public void CreateQuestion(Question question)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string insertQuery = @"INSERT INTO Question (id,question, Opt1, Opt2, Opt3, Opt4, answer)
                               VALUES (@id,@Question, @Opt1, @Opt2, @Opt3, @Opt4, @Answer)";
                    //SELECT CAST(SCOPE_IDENTITY() as int);";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", question.id);
                        command.Parameters.AddWithValue("@Question", question.question);
                        command.Parameters.AddWithValue("@Opt1", question.Opt1);
                        command.Parameters.AddWithValue("@Opt2", question.Opt2);
                        command.Parameters.AddWithValue("@Opt3", question.Opt3);
                        command.Parameters.AddWithValue("@Opt4", question.Opt4);
                        command.Parameters.AddWithValue("@Answer", question.answer);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();// Assuming the Id is auto-generated and returned by the database


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Consider handling the exception more gracefully in a production environment
            }
        }

        public void DeleteQuestion(int id)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string deleteQuery = @"DELETE FROM Question WHERE id = @Id";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new Exception("No question found with the given ID");
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

        
        public List<Question> GetQuestions()
        {
            List<Question> questions = new List<Question>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT * FROM Question";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //CultureInfo culture = CultureInfo.InvariantCulture;
                            while (reader.Read())
                            {
                                Question question=new Question();
                                question.id = reader.GetInt32(0);
                                question.question = reader.GetString(1);
                                question.Opt1 = reader.GetString(2);
                                question.Opt2 = reader.GetString(3);
                                question.Opt3 = reader.GetString(4);
                                question.Opt4 = reader.GetString(5);
                                question.answer = reader.GetString(6);
                                questions.Add(question);
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
            return questions;
        }

       
    }
}

