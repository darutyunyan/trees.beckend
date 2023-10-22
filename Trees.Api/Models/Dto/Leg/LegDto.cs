using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto.Leg
{
    public class LegDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
