using classroom.models;
using classroom.Repository;
using classroom.Repository.Interface;
using classroom.services;
using classroom.services.Interface;
using System.Xml.Linq;

namespace classroom.services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepo _usersRepo;

        public UsersService(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public Users GetById(string Name)
        {
            return _usersRepo.GetById(Name);    
        }
        

    }
}






