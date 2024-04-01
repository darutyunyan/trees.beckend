using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Configurations
{
    public class AccountEntityConfiguration : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Email).IsUnique();
            builder.Property(a => a.Name).HasMaxLength(120);
            builder.Property(a => a.Email).HasMaxLength(120);
            builder.Property(a => a.PasswordHash).HasMaxLength(120);
        }
    }
}
