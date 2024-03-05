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
            // Call the AddMessage method from your repository
            Messages addedMessage = _messageRepo.AddMessage(message);

            // Return the created message along with the status code 201 Created
            return CreatedAtAction(nameof(GetMessageById), new { CourseId = addedMessage.CourseId },addedMessage);
        }

        // Example GET method to retrieve a message by ID
        // You'll need to implement this method based on your actual repository and model
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
