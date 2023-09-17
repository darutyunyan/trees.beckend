namespace Trees.Core.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
        public string? InnerMessage { get; set; }
        public string? InnerStackTrace { get; set; }
    }
}
