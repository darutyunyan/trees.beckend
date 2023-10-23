using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto.Review
{
    public class ReviewDto
    {
        public string? Author { get; set; }

        [Required]
        public required string Date { get; set; }

        [Required]
        public required string Comment { get; set; }
    }
}
