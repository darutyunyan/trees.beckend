using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;

namespace Trees.DataAccess
{
    public class LogDbContext : DbContext, ILogDbContext
    {
        public LogDbContext()
        {
        }

        public LogDbContext(DbContextOptions<LogDbContext> options)
            : base(options) { }

        public DbSet<Log> Log { get; set; }

        public async Task SaveChangesAsync() => await SaveChangesAsync();

    }
}
