using classroom.models;
using classroom.Repository.Interface;
using classroom.services.Interface;
using classroom.models;

namespace classroom.services
{
    public class MessageServices : IMessageService
    {
        private readonly IMessageRepo _messageRepo;

        public MessageServices(IMessageRepo messageRepo)
        {
            _messageRepo = messageRepo;
        }


        public Messages AddMessage(Messages message)
        {
            // You can add any business logic or validation here before adding the message
            return _messageRepo.AddMessage(message);
        }
        public List<Messages> GetMessageById(int CourseId)
        {
            return _messageRepo.GetMessageById(CourseId);
        }
        // Add other methods as needed
    }
}
        public interface IMessageService
        {
            Messages AddMessage(Messages message);
    List<Messages> GetMessageById(int CourseId);
            // Add other method signatures as needed
        }
 
