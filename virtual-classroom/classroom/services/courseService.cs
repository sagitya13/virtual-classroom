using classroom.models;
using classroom.Repository.Interface;
using classroom.services.Interface;

namespace classroom.services
{
    public class courseService : IcourseService
    {


        private readonly IcourseRepo _repo;
        public courseService(IcourseRepo repo)
        {
            _repo = repo;
        }
        public void CreateCourse(course course)
        {   
             _repo.CreateCourse(course);
        }

        public bool DeleteCourse(int id)
        {
            return _repo.DeleteCourse(id);
        }

        public course GetCourseById(int id)
        {
            return _repo.GetCourseById(id);
        }

        public List<course> GetCourses()
        {
            return _repo.GetCourses();
        }

        
    }
}
