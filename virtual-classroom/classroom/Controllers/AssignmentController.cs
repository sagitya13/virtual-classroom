using classroom.models;
using classroom.Repository;
using classroom.Repository.Interface;
using classroom.services;
using classroom.services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace classroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentRepo _assignmentRepo;

        public AssignmentsController(IAssignmentRepo assignmentRepo)
        {
            _assignmentRepo = assignmentRepo;
        }

        // POST api/assignments
        [HttpPost]
        public IActionResult CreateAssignment([FromBody] Assignment assignment)
        {
            _assignmentRepo.CreateAssignment(assignment);
            return CreatedAtAction("GetAssignmentById", new { id = assignment.id }, assignment);
        }





        // GET api/assignments/5
        [HttpGet("{id}")]
        public IActionResult GetAssignmentById(int id)
        {
            var assignment = _assignmentRepo.GetAssignmentById(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);

        }



        // DELETE api/assignments/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAssignment(int id)
        {
            _assignmentRepo.DeleteAssignment(id);
            return NoContent();
        }


        // GET api/assignments
        [HttpGet]
        public ActionResult<List<Assignment>> GetAssignments()
        {
            var assignment = _assignmentRepo.GetAssignments();
            return Ok(assignment);



        }


    }

    }



