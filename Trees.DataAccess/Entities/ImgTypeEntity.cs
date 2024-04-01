using Microsoft.EntityFrameworkCore;
using Trees.DataAccess.Configurations;

namespace Trees.DataAccess.Entities
{
    [EntityTypeConfiguration(typeof(ImgTypeEntityConfiguration))]
    public class ImgTypeEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
