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

        public DbSet<AccountModel> Account { get; set; }
        public DbSet<LocationModel> Location { get; set; }
        public DbSet<TreeModel> Tree { get; set; }
        public DbSet<ImgModel> Img { get; set; }
        public DbSet<MaterialModel> Material { get; set; }
        public DbSet<BrandModel> Brand { get; set; }
        public DbSet<LegModel> Leg { get; set; }
        public DbSet<AssemblyMethodModel> AssemblyMethod { get; set; }
        public DbSet<ReviewModel> Review { get; set; }

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();
    }
}
