using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto.Img
{
    public class ImgDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Data { get; set; }
    }
}
