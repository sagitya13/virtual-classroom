using classroom.models;

namespace classroom.Repository.Interface
{
    public interface IcourseRepo
    {
    
        List<course> GetCourses();
        course GetCourseById(int id);
        void CreateCourse(course course);
        bool DeleteCourse(int id);
    }
}
