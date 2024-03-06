using classroom.models;

namespace classroom.services.Interface
{
    public interface IcourseService 
    {
        List<course> GetCourses();
        course GetCourseById(int id);
        void CreateCourse(course course);
        bool DeleteCourse(int id);
    }
}
