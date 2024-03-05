using classroom.models;
using classroom.Repository.Interface;
using classroom.services;
using classroom.services.Interface;

namespace classroom.services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _repository;

        public StudentService(IStudentRepo repository)
        {
            _repository = repository;
        }

        public List<Student> GetAllStudents()
        {
            return _repository.GetAllStudents();
        }

        public Student GetStudentById(int id)
        {
            return _repository.GetStudentById(id);
        }

        public void AddStudent(Student student)
        {
            _repository.AddStudent(student);
        }

 

        public void DeleteStudent(int id)
        {
            _repository.DeleteStudent(id);
        }
         
    }
}