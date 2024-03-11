
using classroom.models;
using classroom.Repository.Interface;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using static classroom.Repository.UsersRepo;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
namespace classroom.Repository
{
    public class UsersRepo : IUsersRepo
    {
        readonly string connectionString = "";
        public UsersRepo()
        {
            connectionString = @"Data Source=APINP-ELPT4W3IG\SQLEXPRESS;Initial Catalog=backend;User ID=tap2023;Password=tap2023;Encrypt=False";

        }


        public void CreateUser(Users user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Hash the password
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        user.Password = builder.ToString();
                    }

                    // Correctly format the SQL command to insert user details
                    string sql = "INSERT INTO Users (Id, Name, Password, Role) VALUES (@Id, @Name, @Password, @Role)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Id", user.Id);
                        command.Parameters.AddWithValue("@Name", user.Name);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Role", user.Role);

                        // Execute the query
                        command.ExecuteNonQuery(); // Use ExecuteNonQuery for insert, update, delete
                    }
                }
                catch (SqlException ex)
                {
                    // Handle database errors gracefully
                    Console.WriteLine("Error connecting to database: " + ex.Message);
                    throw;
                }
            }



        }

        public Users AuthenticateUser(string name, string providedPassword,string Role)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Users user = null;
                try
                {
                    connection.Open();

                    // Hash the provided password
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(providedPassword));
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        string hashedPassword = builder.ToString();

                        // Create SQL command to retrieve user details by name and compare hashed passwords
                        string sql = "SELECT Id, Name, Password, Role FROM Users WHERE Name = @name AND Password = @password and Role=@Role";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@password", hashedPassword);
                            command.Parameters.AddWithValue("@Role", Role);


                            // Execute the query and retrieve results
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Create User object and assign values
                                    user = new Users
                                    {
                                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                        Name = reader.GetString(reader.GetOrdinal("Name")),
                                        Password = reader.GetString(reader.GetOrdinal("Password")),
                                        Role = reader.GetString(reader.GetOrdinal("Role"))
                                    };
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error connecting to database: " + ex.Message);
                    throw; // Rethrow the exception to allow for further handling
                }
                return user; // Return the user object or null if not found
            }
        }
    }
    }





        