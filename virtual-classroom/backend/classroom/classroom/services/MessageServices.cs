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
            return _messageRepo.AddMessage(message);
        }
        public List<Messages> GetMessageById(int CourseId)
        {
            return _messageRepo.GetMessageById(CourseId);
        } 
    }
}
        public interface IMessageService
        {
            Messages AddMessage(Messages message);
    List<Messages> GetMessageById(int CourseId); 
        }
 
