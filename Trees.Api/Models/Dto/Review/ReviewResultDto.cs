using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto.Review
{
    public class ReviewResultDto
    {
        public required string Id { get; set; }

        public string? Author { get; set; }

        public required DateTime Date { get; set; }

        public required string Comment { get; set; }
    }
}
