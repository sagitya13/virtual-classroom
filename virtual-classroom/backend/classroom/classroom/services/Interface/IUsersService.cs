using classroom.models;

namespace classroom.services.Interface
{
    public interface IUsersService
    {
        Users AuthenticateUser(string name, string providedPassword, string Role);
        public void CreateUser(Users user);


    }
}
