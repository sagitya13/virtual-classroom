
using classroom.models;
using classroom.Repository.Interface;
using System.Data.SqlClient;
using static classroom.Repository.UsersRepo;
namespace classroom.Repository
{
    public class UsersRepo : IUsersRepo
    {
        readonly string connectionString = "";
        public UsersRepo()
        {
            connectionString = @"Data Source=APINP-ELPT4W3IG\SQLEXPRESS;Initial Catalog=backend;User ID=tap2023;Password=tap2023;Encrypt=False";

        }

        public Users GetById(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Users user = new Users();
                try
                {
                    connection.Open();

                    // Create SQL command to retrieve user details by name
                    string sql = "SELECT  Name, Password, Role FROM Users WHERE Name = @name";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);

                        // Execute the query and retrieve results
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Create User object and assign values
                               // user.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                                user.Name = reader.GetString(reader.GetOrdinal("Name"));
                                user.Password = reader.GetString(reader.GetOrdinal("Password"));
                                user.Role = reader.GetString(reader.GetOrdinal("Role"));
                            }
                            else
                            {
                                return null; // No user found with the specified name
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Handle database errors gracefully
                    Console.WriteLine("Error connecting to database: " + ex.Message);
                    throw; // Rethrow the exception to allow for further handling
                }
                return user;
            }
        }

        // Other method implementations...

    }
    
}


        

        