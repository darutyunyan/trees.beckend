using Microsoft.EntityFrameworkCore;
using Trees.DataAccess.Configurations;

namespace Trees.DataAccess.Entities
{
    [EntityTypeConfiguration(typeof(ImgEntityConfiguration))]
    public class ImgEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Path { get; set; }
        public required int TypeId { get; set; }
        public required ImgTypeEntity Type { get; set; }
        public required List<TreeEntity> Trees { get; set; }
    }
}
