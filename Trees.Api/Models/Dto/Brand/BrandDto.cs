using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto.Brand
{
    public class BrandDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
