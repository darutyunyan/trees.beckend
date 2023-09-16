using Microsoft.EntityFrameworkCore;
using Trees.Infrastructure.Persistance.Models;

namespace Trees.Infrastructure.Persistance.Context
{
    public interface IApplicationDbContext
    {
        DbSet<AccountModel> Account { get; set; }
        DbSet<LocationModel> Location { get; set; }
        DbSet<TreeModel> Tree { get; set; }
        DbSet<ImgModel> Img { get; set; }
        DbSet<MaterialModel> Material { get; set; }
        DbSet<BrandModel> Brand { get; set; }
        DbSet<LegModel> Leg { get; set; }
        DbSet<AssemblyMethodModel> AssemblyMethod { get; set; }
        DbSet<ReviewModel> Review { get; set; }

        Task SaveChangesAsync();
    }
}
