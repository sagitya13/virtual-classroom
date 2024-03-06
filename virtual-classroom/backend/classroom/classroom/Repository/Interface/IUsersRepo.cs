using classroom.models;

namespace classroom.Repository.Interface
{
    public interface IUsersRepo
    {
        Users AuthenticateUser(string Name, string providedPassword);
        public void CreateUser(Users user);
    }
}



