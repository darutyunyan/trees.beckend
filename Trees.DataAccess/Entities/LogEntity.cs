namespace Trees.DataAccess.Entities
{
    public class LogEntity
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public required string Message { get; set; }
        public required string StackTrace { get; set; }
        public string? InnerMessage { get; set; }
        public string? InnerStackTrace { get; set; }
    }
}
