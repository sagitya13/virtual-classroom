using classroom.models;
using classroom.services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using classroom.services;

namespace classroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class courseController : ControllerBase
    {

        private readonly courseService _courseService;

        public courseController(courseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Route("course")]
        public ActionResult<List<course>> GetCourses()
        {
            var courses = _courseService.GetCourses();
            return Ok(courses);
        }

        [HttpPost]
        [Route("course")]
        public ActionResult<course> CreateCourse([FromBody] course course)
        {
           _courseService.CreateCourse(course);
            return Ok();
        }

        [HttpGet]
        [Route("courses/{id}")]
        public ActionResult<course> GetCourseById(int id)
        {
            var course = _courseService.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        

        [HttpDelete]
        [Route("courses/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var success = _courseService.DeleteCourse(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}