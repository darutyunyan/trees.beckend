namespace Trees.Infrastructure.Persistence.Entities
{
	public class LocationEntity
	{
		public Guid Id { get; set; }
		public required string Lat { get; set; }
		public required string Lng { get; set; }
	}
}
