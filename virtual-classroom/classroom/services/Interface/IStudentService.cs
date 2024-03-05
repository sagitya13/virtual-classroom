using classroom.models;

namespace classroom.services.Interface
{
     
        public interface IStudentService
        {
            List<Student> GetAllStudents();
            Student GetStudentById(int id);
            void AddStudent(Student student); 
            void DeleteStudent(int id);
        }
 
}
