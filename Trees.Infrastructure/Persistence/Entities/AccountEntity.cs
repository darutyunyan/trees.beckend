namespace Trees.Infrastructure.Persistence.Entities
{
	public class AccountEntity
	{
		public Guid Id { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }
		public required string Salt { get; set; }
	}
}
