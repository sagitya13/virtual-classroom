using classroom.models;

namespace classroom.services.Interface
{
    public interface IadminService
    {
        Task<Admin> GetAdminByIdAsync(int adminId);
        Task AddAdminAsync(Admin admin);
    }
}
