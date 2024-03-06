using classroom.models;

namespace classroom.services.Interface
{
    public interface IUsersService
    {
        Users AuthenticateUser(string name, string providedPassword);
        public void CreateUser(Users user);


    }
}
