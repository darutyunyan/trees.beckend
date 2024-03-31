namespace Trees.DataAccess.Entities
{
    public class ReviewEntity
    {
        public Guid Id { get; set; }
        public string? Author { get; set; }
        public required DateTime Date { get; set; }
        public required string Comment { get; set; }
    }
}
