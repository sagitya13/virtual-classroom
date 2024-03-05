using classroom.models;

namespace classroom.Repository.Interface
{
    public interface IMessageRepo
    {

        List<Messages> GetMessageById(int CourseId);
        Messages AddMessage(Messages message);

    }
}
