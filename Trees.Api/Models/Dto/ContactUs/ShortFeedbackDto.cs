using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto.ContactUs
{
    public class ShortFeedbackDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        [Phone]
        public required string Phone { get; set; }
    }
}
