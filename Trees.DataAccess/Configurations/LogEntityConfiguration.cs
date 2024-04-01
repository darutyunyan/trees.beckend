using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Configurations
{
    public class LogEntityConfiguration : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Message).HasMaxLength(4000);
            builder.Property(a => a.InnerMessage).HasMaxLength(4000);
        }
    }
}
