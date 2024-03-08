

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

        
    }



}