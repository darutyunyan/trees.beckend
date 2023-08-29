namespace Trees.Core.Entities
{
	public class Location
	{
		public Guid Id { get; set; }
		public required string Lat { get; set; }
		public required string Lng { get; set; }
	}
}
