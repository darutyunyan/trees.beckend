using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Configurations
{
    public class TreeEntityConfiguration : IEntityTypeConfiguration<TreeEntity>
    {
        public void Configure(EntityTypeBuilder<TreeEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Name).IsUnique();
            builder.Property(a => a.Name).HasMaxLength(120);
            builder.Property(a => a.FullName).HasMaxLength(240);
            builder.Property(a => a.Description).HasMaxLength(4000);
        }
    }
}
