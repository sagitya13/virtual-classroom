using classroom.models;

namespace classroom.Repository.Interface
{
    public interface IStudentRepo
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student); 
        void DeleteStudent(int id);
    }
}