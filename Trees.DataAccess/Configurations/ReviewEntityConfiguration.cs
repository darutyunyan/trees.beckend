using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Configurations
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<ReviewEntity>
    {
        public void Configure(EntityTypeBuilder<ReviewEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Author).IsUnique();
            builder.Property(a => a.Author).HasMaxLength(120);
            builder.Property(a => a.Comment).HasMaxLength(4000);
        }
    }
}
