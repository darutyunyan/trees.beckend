namespace Trees.Infrastructure.Persistance.Models
{
	public class LocationModel
	{
		public Guid Id { get; set; }
		public required string Lat { get; set; }
		public required string Lng { get; set; }
	}
}
