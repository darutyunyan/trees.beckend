using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto.Material
{
    public class MaterialDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
