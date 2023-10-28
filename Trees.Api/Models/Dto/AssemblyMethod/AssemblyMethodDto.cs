using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto.AssemblyMethod
{
    public class AssemblyMethodDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
