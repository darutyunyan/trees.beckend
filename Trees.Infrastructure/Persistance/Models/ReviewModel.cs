namespace Trees.Infrastructure.Persistance.Models
{
	public class ReviewModel
    {
		public Guid Id { get; set; }
		public string? Author { get; set; }
		public required DateTime Date { get; set; }
		public required string Comment { get; set; }
	}
}
