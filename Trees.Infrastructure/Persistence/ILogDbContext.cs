using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;

namespace Trees.Infrastructure.Persistence
{
    public interface ILogDbContext
    {
        public DbSet<Log> Log { get; set; }

        Task SaveChangesAsync();
    }
}
