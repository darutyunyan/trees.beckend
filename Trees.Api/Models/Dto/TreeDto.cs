using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto
{
    public class TreeDto
    {
        [Required]
        public string Name { get; set; }

        public string FullName { get; set; }

        [Required]
        public string[] Info { get; set; }

        [Required]
        public string ImgId { get; set; }

        public string Description { get; set; }
        public bool IsDisplay { get; set; }
        public string LegId { get; set; }
        public string AssemblyMethodId { get; set; }
        public string MaterialId { get; set; }
        public string BrandId { get; set; }
    }
}
