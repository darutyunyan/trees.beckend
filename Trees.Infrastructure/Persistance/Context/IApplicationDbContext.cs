using Microsoft.EntityFrameworkCore;
using Trees.Infrastructure.Persistance.Models;

namespace Trees.Infrastructure.Persistance.Context
{
    public interface IApplicationDbContext
    {
        DbSet<AccountModel> Accounts { get; set; }
        DbSet<LocationModel> Locations { get; set; }
        DbSet<TreeModel> Trees { get; set; }
        DbSet<ImgModel> Imgs { get; set; }
        DbSet<MaterialModel> Materials { get; set; }
        DbSet<BrandModel> Brands { get; set; }
        DbSet<LegModel> Legs { get; set; }
        DbSet<AssemblyMethodModel> AssemblyMethods { get; set; }
        DbSet<ReviewModel> Reviews { get; set; }

        Task SaveChangesAsync();
    }
}
