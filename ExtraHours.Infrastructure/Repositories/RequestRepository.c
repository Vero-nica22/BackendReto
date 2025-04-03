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


        public async Task<IEnumerable<Request>> GetAllRequestsAsync()
        {
            return await _context.Requests
                .Include(r => r.User) 
                .Include(r => r.ExtraHours) 
                .Include(r => r.Status) 
                .ToListAsync();
        }


        public async Task<Request?> GetRequestByIdAsync(int id)
        {
            return await _context.Requests
                .Include(r => r.User) 
                .Include(r => r.ExtraHours)
                .Include(r => r.Status) 
                .FirstOrDefaultAsync(r => r.Id == id);
        }


        public async Task<IEnumerable<Request>> GetRequestsByUserIdAsync(int userId)
        {
            return await _context.Requests
                .Where(r => r.UserId == userId)
                .Include(r => r.Status) 
                .ToListAsync();
        }


        public async Task AddRequestAsync(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateRequestStatusAsync(int requestId, int statusId)
        {
            var request = await _context.Requests.FindAsync(requestId);
            if (request != null)
            {
                request.StatusId = statusId;
                await _context.SaveChangesAsync();
            }
        }


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