using ExtraHours.Core.Models;
namespace ExtraHours.Core.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByIdAsync(int id);
        Task AddRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
    }
}