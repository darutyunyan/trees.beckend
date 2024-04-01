using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Configurations
{
    public class ImgEntityConfiguration : IEntityTypeConfiguration<ImgEntity>
    {
        public void Configure(EntityTypeBuilder<ImgEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Name).IsUnique();
            builder.Property(a => a.Name).HasMaxLength(120);
        }
    }
}
