using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Configurations
{
    public class LegEntityConfiguration : IEntityTypeConfiguration<LegEntity>
    {
        public void Configure(EntityTypeBuilder<LegEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Name).IsUnique();
            builder.Property(a => a.Name).HasMaxLength(120);
        }
    }
}
