using classroom.models;

namespace classroom.Repository.Interface
{
    public interface IUsersRepo
    {
        Users AuthenticateUser(string Name, string providedPassword,string Role);
        public void CreateUser(Users user);
    }
}



