using classroom.models;

namespace classroom.services.Interface
{
    public interface IUsersService
    {
        Users GetById(string Name);
    }
}
