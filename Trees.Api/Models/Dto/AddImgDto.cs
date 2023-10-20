using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto
{
    public class AddImgDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Data { get; set; }
    }
}
