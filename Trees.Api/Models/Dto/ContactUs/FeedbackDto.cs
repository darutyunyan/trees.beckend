using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto.ContactUs
{
    public class FeedbackDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        [Phone]
        public required string Phone { get; set; }

        public string? Email { get; set; }

        [Required]
        public required string Message { get; set; }
    }
}
