using ExtraHours.Core.Models;
using ExtraHours.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExtraHours.Core.Repositories
{
    public class ExtraHourRepository
    {
        private readonly AppDbContext _context;

        public ExtraHourRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ExtraHour>> GetAllExtraHoursAsync()
        {
            return await _context.ExtraHours
                .Include(e => e.UserId)
                .Include(e => e.TypeExtraHourId)
                .Include(e => e.StatusId)
                .ToListAsync();
        }


        public async Task<ExtraHour?> GetExtraHourByIdAsync(int id)
        {
            return await _context.ExtraHours
                .Include(e => e.TypeExtraHourId)
                .Include(e => e.StatusId)
                .FirstOrDefaultAsync(e => e.Id == id);
        }


        public async Task AddExtraHourAsync(ExtraHour extraHour)
        {
            _context.ExtraHours.Add(extraHour);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateExtraHourAsync(ExtraHour extraHour)
        {
            var existingExtraHour = await _context.ExtraHours.FindAsync(extraHour.Id);
            if (existingExtraHour != null)
            {
                _context.Entry(existingExtraHour).CurrentValues.SetValues(extraHour);
                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteExtraHourAsync(int id)
        {
            var extraHour = await _context.ExtraHours.FindAsync(id);
            if (extraHour != null)
            {
                _context.ExtraHours.Remove(extraHour);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<ExtraHour>> GetApprovedExtraHoursAsync()
        {
            return await _context.ExtraHours
                .Where(e => e.StatusId == 1)
                .ToListAsync();
        }
    }
}