using classroom.models;
using classroom.Repository;
using classroom.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace classroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepo _questionRepo;

        public QuestionsController(IQuestionRepo questionRepo)
        {
            _questionRepo = questionRepo;
        }

        [HttpPost]
        public IActionResult CreateQuestion([FromBody] Question question)
        {
            _questionRepo.CreateQuestion(question);
            
            return CreatedAtAction("GetQuestionById", new { id = question.id }, question);
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestionById(int id)
        {
            var question = _questionRepo.GetQuestionById(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);

        }
    

        

        [HttpDelete("{id}")]
            public IActionResult DeleteQuestion(int id)
            {
            _questionRepo.DeleteQuestion(id);
            return NoContent();
        }

            [HttpGet]
            public IActionResult GetQuestions()
            {
             var questions= _questionRepo.GetQuestions();
            return Ok(questions);

         
        }
        }


    }

