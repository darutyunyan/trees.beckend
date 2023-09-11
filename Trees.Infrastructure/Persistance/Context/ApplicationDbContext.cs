using Microsoft.EntityFrameworkCore;
using Trees.Infrastructure.Persistance.Models;

namespace Trees.Infrastructure.Persistance.Context
{
    public partial class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<TreeModel> Trees { get; set; }
        public DbSet<ImgModel> Imgs { get; set; }
        public DbSet<MaterialModel> Materials { get; set; }
        public DbSet<BrandModel> Brands { get; set; }
        public DbSet<LegModel> Legs { get; set; }
        public DbSet<AssemblyMethodModel> AssemblyMethods { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }

        public async Task SaveChangesAsync() => await SaveChangesAsync();
    }
}
