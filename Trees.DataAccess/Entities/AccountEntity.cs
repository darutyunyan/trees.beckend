using Microsoft.EntityFrameworkCore;
using Trees.DataAccess.Configurations;

namespace Trees.DataAccess.Entities
{
    [EntityTypeConfiguration(typeof(AccountEntityConfiguration))]
    public class AccountEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
    }
}
