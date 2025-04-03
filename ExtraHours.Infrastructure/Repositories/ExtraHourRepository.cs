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

        // Obtener todas las horas extra
        public async Task<IEnumerable<ExtraHour>> GetAllExtraHoursAsync()
        {
            return await _context.ExtraHours
                .Include(e => e.UserId) // Incluye el ID del usuario (si está relacionado en el modelo)
                .Include(e => e.TypeExtraHourId) // Incluye el tipo de hora extra (relación definida en el modelo)
                .Include(e => e.StatusId) // Incluye el estado actual
                .ToListAsync();
        }

        // Obtener una hora extra por ID
        public async Task<ExtraHour?> GetExtraHourByIdAsync(int id)
        {
            return await _context.ExtraHours
                .Include(e => e.TypeExtraHourId)
                .Include(e => e.StatusId)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        // Agregar una nueva hora extra
        public async Task AddExtraHourAsync(ExtraHour extraHour)
        {
            _context.ExtraHours.Add(extraHour);
            await _context.SaveChangesAsync();
        }

        // Actualizar una hora extra existente
        public async Task UpdateExtraHourAsync(ExtraHour extraHour)
        {
            var existingExtraHour = await _context.ExtraHours.FindAsync(extraHour.Id);
            if (existingExtraHour != null)
            {
                _context.Entry(existingExtraHour).CurrentValues.SetValues(extraHour);
                await _context.SaveChangesAsync();
            }
        }

        // Eliminar una hora extra por ID
        public async Task DeleteExtraHourAsync(int id)
        {
            var extraHour = await _context.ExtraHours.FindAsync(id);
            if (extraHour != null)
            {
                _context.ExtraHours.Remove(extraHour);
                await _context.SaveChangesAsync();
            }
        }

        // Obtener todas las horas extra aprobadas
        public async Task<IEnumerable<ExtraHour>> GetApprovedExtraHoursAsync()
        {
            return await _context.ExtraHours
                .Where(e => e.StatusId == 1) // Suponiendo que 1 representa "Aprobado"
                .ToListAsync();
        }
    }
}