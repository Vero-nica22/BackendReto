// using ExtraHours.Core.Models;
// using ExtraHours.Core.Services;
// using ExtraHours.Infrastructure.Data;
// using Microsoft.EntityFrameworkCore;

// namespace ExtraHours.Infrastructure.Service
// {
//     public class RoleService : IRoleService
//     {
//         private readonly AppDbContext _context;

//         public RoleService(AppDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<IEnumerable<Role>> GetAllRolesAsync()
//         {
//             return await _context.Roles.ToListAsync();
//         }

//         public async Task<Role?> GetRoleByIdAsync(int id)
//         {
//             return await _context.Roles.FindAsync(id);
//         }

//         public async Task AddRoleAsync(Role role)
//         {
//             _context.Roles.Add(role);
//             await _context.SaveChangesAsync();
//         }

//         public async Task UpdateRoleAsync(Role role)
//         {
//             var existingRole = await _context.Roles.FindAsync(role.Id);
//             if (existingRole != null)
//             {
//                 _context.Entry(existingRole).CurrentValues.SetValues(role);
//                 await _context.SaveChangesAsync();
//             }
//         }

//         public async Task DeleteRoleAsync(int id)
//         {
//             var role = await _context.Roles.FindAsync(id);
//             if (role != null)
//             {
//                 _context.Roles.Remove(role);
//                 await _context.SaveChangesAsync();
//             }
//         }
//     }
// }