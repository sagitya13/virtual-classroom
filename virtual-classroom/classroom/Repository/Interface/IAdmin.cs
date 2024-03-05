using classroom.models;

namespace classroom.Repository.Interface
{
    public interface IAdmin
    {
        Task<Admin> GetAdminByIdAsync(int adminId);
        Task AddAdminAsync(Admin admin);
    }
}
