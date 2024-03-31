using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;

namespace Trees.DataAccess
{
    public interface ILogDbContext
    {
        public DbSet<Log> Log { get; set; }

        Task SaveChangesAsync();
    }
}
