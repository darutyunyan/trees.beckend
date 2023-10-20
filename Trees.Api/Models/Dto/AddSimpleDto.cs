using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto
{
    public class AddSimpleDto
    {
        [Required]
        public string Name { get; set; }
    }
}
