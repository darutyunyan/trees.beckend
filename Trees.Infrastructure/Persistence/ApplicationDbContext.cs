using Microsoft.EntityFrameworkCore;
using Trees.Infrastructure.Persistence.Entities;

namespace Trees.Infrastructure.Persistence
{
    public partial class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<AccountEntity> Account { get; set; }
        public DbSet<LocationEntity> Location { get; set; }
        public DbSet<TreeEntity> Tree { get; set; }
        public DbSet<ImgEntity> Img { get; set; }
        public DbSet<MaterialEntity> Material { get; set; }
        public DbSet<BrandEntity> Brand { get; set; }
        public DbSet<LegEntity> Leg { get; set; }
        public DbSet<AssemblyMethodEntity> AssemblyMethod { get; set; }
        public DbSet<ReviewEntity> Review { get; set; }

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();
    }
}
