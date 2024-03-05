using classroom.models;

namespace classroom.services.Interface
{
    public interface IMessagesService
    {

        List<Messages> GetMessageById(int CourseId);
        Messages AddMessage(Messages message);
       
    }
}
