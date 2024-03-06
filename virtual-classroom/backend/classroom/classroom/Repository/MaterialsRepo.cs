

using classroom.models;
using classroom.Repository.Interface;
using System.Data;
using System.Data.SqlClient;


namespace classroom.Repository{

public class MaterialsRepo : IMaterialsRepo
{
     
        readonly string connectionString = "";

        public MaterialsRepo()
        {
            connectionString = @"Data Source=APINP-ELPT4W3IG\SQLEXPRESS;Initial Catalog=backend;User ID=tap2023;Password=tap2023;Encrypt=False";
        }

        public List<Materials> GetMaterialBycourseId(int courseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Materials WHERE courseId = @courseId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@CourseId", courseId);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (true)
                    {
                        List<Materials> material = new List<Materials>();

                        while (reader.Read())
                        {
                            material.Add(new Materials

                            {

                                fileName = (string)reader["fileName"],
                                filePath = (string)reader["filePath"],
                                courseId = (int)reader["courseId"]
                            });


                        }

                        return material;
                    }
                }
            }
        }

        public void CreateMaterial(Materials material)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Materials (fileName, filePath, courseId) VALUES (@fileName, @filePath, @courseId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fileName", material.fileName);
                command.Parameters.AddWithValue("@filePath", material.filePath);
                command.Parameters.AddWithValue("@courseId", material.courseId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        

       

       /* public Materials[] GetAllMaterials()
        {
            List<Materials> materialsList = new List<Materials>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string selectQuery = @"SELECT * FROM Materials";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                materialsList.Add(new Materials
                                {
                                    id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Title = reader.GetString(reader.GetOrdinal("Title")),
                                    Type = reader.GetString(reader.GetOrdinal("Type")),
                                    upload_date = reader.GetDateTime(reader.GetOrdinal("upload_date"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return materialsList.ToArray();
        }*/
    }



}