using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto
{
    public class ShortFeedbackRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
