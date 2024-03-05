using classroom.models;
using classroom.Repository.Interface;
using System;
using System.Data.SqlClient;
namespace classroom.Repository
{
    public class MessageRepo : IMessageRepo
    {
        readonly string connectionString = "";
        public MessageRepo()
        {
            // Update the connection string with your database details
            connectionString = @"Data Source=APINP-ELPT4W3IG\SQLEXPRESS;Initial Catalog=backend;Persist Security Info=True;User ID=tap2023;Password=tap2023;Encrypt=False";
        }
        public List<Messages> GetMessageById(int CourseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Messages WHERE CourseId = @CourseId ORDER BY Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseId", CourseId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                       if(true)
                        {
                            List<Messages> messages = new List<Messages>();
                            while (reader.Read())
                            {
                                messages.Add(new Messages
                                {

                                    Id = Convert.ToInt32(reader["Id"]),
                                    MessageContent = reader["MessageContent"].ToString(), // Corrected column name
                                    UserName = reader["UserName"].ToString(), // Corrected column name
                                    CourseId = Convert.ToInt32(reader["CourseId"])
                                });
                            }
                            return messages;
                            
                        }
                    }
                }
            }
            return null;
        }
        public Messages AddMessage(Messages message)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = @"INSERT INTO Messages (MessageContent, UserName, CourseId)
                                      VALUES (@MessageContent, @UserName, @CourseId); ";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@MessageContent", message.MessageContent);
                    command.Parameters.AddWithValue("@UserName", message.UserName);
                    command.Parameters.AddWithValue("@CourseId", message.CourseId);
                    connection.Open();
                    int Id = Convert.ToInt32(command.ExecuteScalar()); // Get the newly inserted Id
                    message.Id = Id; // Update the message object with the newly generated Id
                }
            }
            return message; // Return the message object with the newly assigned Id
        }
    }



}