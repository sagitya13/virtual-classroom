using classroom.models;
using classroom.Repository;
using classroom.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace classroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     public class MessagesController : ControllerBase
        {
        private readonly IMessageRepo _messageRepo;

        public MessagesController(IMessageRepo messageRepo)
        {
            _messageRepo = messageRepo;
        }

        [HttpPost("CreateMessage")]
        public ActionResult<Messages> CreateMessage([FromBody] Messages message)
        { 
            Messages addedMessage = _messageRepo.AddMessage(message);
             
            return CreatedAtAction(nameof(GetMessageById), new { CourseId = addedMessage.CourseId },addedMessage);
        }
         
        [HttpGet("{CourseId}")]
        public ActionResult<List<Messages>> GetMessageById(int CourseId)
        {
            var message = _messageRepo.GetMessageById(CourseId);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

     

    }
}
