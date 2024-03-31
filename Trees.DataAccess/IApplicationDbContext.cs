using Microsoft.EntityFrameworkCore;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess
{
    public interface IApplicationDbContext
    {
        DbSet<AccountEntity> Account { get; set; }
        DbSet<LocationEntity> Location { get; set; }
        DbSet<TreeEntity> Tree { get; set; }
        DbSet<ImgEntity> Img { get; set; }
        DbSet<MaterialEntity> Material { get; set; }
        DbSet<BrandEntity> Brand { get; set; }
        DbSet<LegEntity> Leg { get; set; }
        DbSet<AssemblyMethodEntity> AssemblyMethod { get; set; }
        DbSet<ReviewEntity> Review { get; set; }

        Task SaveChangesAsync();
    }
}
