using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto
{
    public class AddReviewDto
    {
        public string Author { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
