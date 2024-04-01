using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Configurations
{
    public class ImgTypeEntityConfiguration : IEntityTypeConfiguration<ImgTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ImgTypeEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Name).IsUnique();
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.Property(a => a.Description).HasMaxLength(120);
        }
    }
}
