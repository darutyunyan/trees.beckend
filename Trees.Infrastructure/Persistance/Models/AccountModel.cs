namespace Trees.Infrastructure.Persistance.Models
{
	public class AccountModel
	{
		public Guid Id { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }
		public required string Salt { get; set; }
	}
}
