// using ExtraHours.Core.Models;
// using ExtraHours.Core.Services;
// using ExtraHours.Infrastructure.Data;
// using Microsoft.EntityFrameworkCore;

// namespace ExtraHours.Infrastructure.Service
// {
//     public class ExtraHourService : IExtraHourService
//     {
//         private readonly AppDbContext _context;

//         public ExtraHourService(AppDbContext context)
//         {
//             _context = context;
//         }

//         // Obtener todas las horas extra
//         public async Task<IEnumerable<ExtraHour>> GetAllExtraHoursAsync()
//         {
//             return await _context.ExtraHours.ToListAsync();
//         }

//         public async Task<ExtraHour?> GetExtraHourByIdAsync(int id)
//         {
//             return await _context.ExtraHours.FindAsync(id);
//         }


//         public async Task AddExtraHourAsync(ExtraHour extraHour)
//         {
//             _context.ExtraHours.Add(extraHour);
//             await _context.SaveChangesAsync();
//         }


//         public async Task UpdateExtraHourAsync(ExtraHour extraHour)
//         {
//             var existingExtraHour = await _context.ExtraHours.FindAsync(extraHour.Id);
//             if (existingExtraHour != null)
//             {
//                 _context.Entry(existingExtraHour).CurrentValues.SetValues(extraHour);
//                 await _context.SaveChangesAsync();
//             }
//         }


//         public async Task DeleteExtraHourAsync(int id)
//         {
//             var extraHour = await _context.ExtraHours.FindAsync(id);
//             if (extraHour != null)
//             {
//                 _context.ExtraHours.Remove(extraHour);
//                 await _context.SaveChangesAsync();
//             }
//         }
//     }
// }