namespace Trees.Core.Entities
{
	public class Review
	{
		public Guid Id { get; set; }
		public required string Author { get; set; }
		public required DateTime Date { get; set; }
		public required string Comment { get; set; }
	}
}
