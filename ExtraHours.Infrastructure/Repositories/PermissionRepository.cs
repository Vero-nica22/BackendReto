using ExtraHours.Core.Models;
using ExtraHours.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExtraHours.Core.Repositories
{
    public class PermissionRepository
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            return await _context.Permissions.ToListAsync();
        }


        public async Task<Permission?> GetPermissionByIdAsync(int id)
        {
            return await _context.Permissions.FindAsync(id);
        }


        public async Task AddPermissionAsync(Permission permission)
        {
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
        }


        public async Task UpdatePermissionAsync(Permission permission)
        {
            var existingPermission = await _context.Permissions.FindAsync(permission.Id);
            if (existingPermission != null)
            {
                _context.Entry(existingPermission).CurrentValues.SetValues(permission);
                await _context.SaveChangesAsync();
            }
        }


        public async Task DeletePermissionAsync(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission != null)
            {
                _context.Permissions.Remove(permission);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<Permission>> GetActivePermissionsAsync()
        {
            return await _context.Permissions
                .Where(p => p.IsActivePermission)
                .ToListAsync();
        }
    }
}