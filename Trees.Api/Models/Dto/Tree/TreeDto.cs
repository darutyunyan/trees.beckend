using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto.Tree
{
    public class TreeDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string[] Info { get; set; }

        [Required]
        public required string ImgId { get; set; }

        public string? FullName { get; set; }
        public string? Description { get; set; }
        public bool IsDisplay { get; set; }
        public string? LegId { get; set; }
        public string? AssemblyMethodId { get; set; }
        public string? MaterialId { get; set; }
        public string? BrandId { get; set; }
    }
}
