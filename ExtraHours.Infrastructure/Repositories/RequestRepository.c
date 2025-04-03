using ExtraHours.Core.Models;
using ExtraHours.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExtraHours.Core.Repositories
{
    public class RequestRepository
    {
        private readonly AppDbContext _context;

        public RequestRepository(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todas las solicitudes
        public async Task<IEnumerable<Request>> GetAllRequestsAsync()
        {
            return await _context.Requests
                .Include(r => r.User) // Incluye datos del usuario
                .Include(r => r.ExtraHours) // Incluye datos de horas extras relacionadas
                .Include(r => r.Status) // Incluye el estado actual
                .ToListAsync();
        }

        // Obtener una solicitud por su ID
        public async Task<Request?> GetRequestByIdAsync(int id)
        {
            return await _context.Requests
                .Include(r => r.User) // Incluye datos del usuario
                .Include(r => r.ExtraHours) // Incluye datos de horas extras relacionadas
                .Include(r => r.Status) // Incluye el estado actual
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        // Obtener solicitudes de un usuario en particular
        public async Task<IEnumerable<Request>> GetRequestsByUserIdAsync(int userId)
        {
            return await _context.Requests
                .Where(r => r.UserId == userId)
                .Include(r => r.Status) // Incluye el estado actual
                .ToListAsync();
        }

        // Agregar una nueva solicitud
        public async Task AddRequestAsync(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
        }

        // Actualizar el estado de una solicitud
        public async Task UpdateRequestStatusAsync(int requestId, int statusId)
        {
            var request = await _context.Requests.FindAsync(requestId);
            if (request != null)
            {
                request.StatusId = statusId;
                await _context.SaveChangesAsync();
            }
        }

        // Eliminar una solicitud
        public async Task DeleteRequestAsync(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}