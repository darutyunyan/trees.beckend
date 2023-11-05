namespace Trees.Api.Models.Dto.Log
{
    public class LogResultDto
    {
        public DateTime Timestamp { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
        public string? InnerMessage { get; set; }
        public string? InnerStackTrace { get; set; }
    }
}
