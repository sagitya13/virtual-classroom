using classroom.models;
using classroom.Repository.Interface;

using System.Data.SqlClient;
namespace classroom.Repository
{
    public class courseRepo : IcourseRepo
    {

        readonly string connectionString = "";
        public courseRepo()
        {
            connectionString = @"Data Source=APINP-ELPT4W3IG\SQLEXPRESS;Initial Catalog=backend;User ID=tap2023;Password=tap2023;Encrypt=False";

        }

        public course GetCourseById(int id)
        {
            course course = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string selectQuery = @"SELECT * FROM course WHERE id = @Id";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                course = new course
                                {
                                    id = Convert.ToInt32(reader["id"]),
                                    name = reader["name"].ToString(),
                                    description = reader["description"].ToString(),
                                    Material_id = Convert.ToInt32(reader["Material_id"]),  
                                    teacher_id = Convert.ToInt32(reader["teacher_id"]),
                                    type = reader["type"].ToString(),
                                    date = Convert.ToDateTime(reader["date"]),
                                    start_time = reader["start_time"] != DBNull.Value ? TimeSpan.Parse(reader["start_time"].ToString()) : TimeSpan.Zero, 
                                    Student_id = Convert.ToInt32(reader["Student_id"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Consider logging the exception or handling it more gracefully in a production environment
            }

            return course;
        }


        public bool DeleteCourse(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string deleteQuery = "DELETE FROM course WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Course deleted successfully");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("No course found with the given ID");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

       

       public List<course> GetCourses()
{
    List<course> courses = new List<course>();
    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string selectQuery = @"SELECT * FROM course";
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new course
                        {
                            id = !reader.IsDBNull(reader.GetOrdinal("id")) ? Convert.ToInt32(reader["id"]) : 0,
                            name = reader["name"].ToString(),
                            description = reader["description"].ToString(),
                            Material_id = !reader.IsDBNull(reader.GetOrdinal("Material_id")) ? Convert.ToInt32(reader["Material_id"]) : 0, 
                            teacher_id = !reader.IsDBNull(reader.GetOrdinal("teacher_id")) ? Convert.ToInt32(reader["teacher_id"]) : 0,
                            type = reader["type"].ToString(),
                            date = !reader.IsDBNull(reader.GetOrdinal("date")) ? Convert.ToDateTime(reader["date"]) : DateTime.MinValue,
                            start_time = !reader.IsDBNull(reader.GetOrdinal("start_time")) ? TimeSpan.Parse(reader["start_time"].ToString()) : TimeSpan.Zero, 
                            Student_id = !reader.IsDBNull(reader.GetOrdinal("Student_id")) ? Convert.ToInt32(reader["Student_id"]) : 0
                        });
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        // Consider logging the exception or handling it more gracefully in a production environment
    }

    return courses;
}

        public void CreateCourse(course course)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string insertQuery = @"INSERT INTO course (id, name, description, Material_id, teacher_id, type, date, start_time,  Student_id)
                                   VALUES (@Id, @Name, @Description, @MaterialId, @TeacherId, @Type, @Date, @StartTime, @StudentId)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", course.id);
                        command.Parameters.AddWithValue("@Name", course.name);
                        command.Parameters.AddWithValue("@Description", course.description);
                        command.Parameters.AddWithValue("@MaterialId", course.Material_id); 
                        command.Parameters.AddWithValue("@TeacherId", course.teacher_id);
                        command.Parameters.AddWithValue("@Type", course.type);
                        command.Parameters.AddWithValue("@Date", course.date);  
                        command.Parameters.AddWithValue("@StartTime",   course.start_time.ToString() ) ;  
                        command.Parameters.AddWithValue("@StudentId", course.Student_id);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine("New course inserted successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Consider logging the exception or handling it more gracefully in a production environment
            }
        }

       
    }
}
