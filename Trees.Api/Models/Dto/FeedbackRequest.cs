using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto
{
    public class FeedbackRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
