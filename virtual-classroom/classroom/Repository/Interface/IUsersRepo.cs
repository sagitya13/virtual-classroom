using classroom.models;

namespace classroom.Repository.Interface
{
    public interface IUsersRepo
    {
        Users GetById(string Name);
    }
}


