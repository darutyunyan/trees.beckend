using Microsoft.EntityFrameworkCore;
using Trees.Core.Entities;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistance.Context;

namespace Trees.Infrastructure.Persistance.Repository
{
    public class LogRepository : ILogRepository
    {
        public LogRepository(ILogDbContext context)
        {
            _context = context;

        }

        public async Task AddAsync(Log log)
        {
            if (log == null)
                throw new ArgumentNullException(nameof(log));

            await _context.Log.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Log>> GetTopAsync(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            return await _context.Log.OrderByDescending(t => t.Timestamp).Take(count).ToListAsync();
        }

        public async Task ClearAsync()
        {
            _context.Log.RemoveRange(_context.Log);
            await _context.SaveChangesAsync();
        }

        private readonly ILogDbContext _context;
    }
}
