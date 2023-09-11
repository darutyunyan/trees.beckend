using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Core.Entities;

namespace Trees.Infrastructure.Persistance.Context
{
    public interface ILogDbContext
    {
        public DbSet<Log> Log { get; set; }

        Task SaveChangesAsync();
    }
}
