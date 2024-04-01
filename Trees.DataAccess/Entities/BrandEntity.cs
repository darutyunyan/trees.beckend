using Microsoft.EntityFrameworkCore;
using Trees.DataAccess.Configurations;

namespace Trees.DataAccess.Entities
{
    [EntityTypeConfiguration(typeof(BrandEntityConfiguration))]
    public class BrandEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required List<TreeEntity> Trees { get; set; }
    }
}
