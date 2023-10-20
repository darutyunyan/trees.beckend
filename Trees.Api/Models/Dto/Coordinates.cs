using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto
{
    public class Coordinates
    {
        [Required]
        [RegularExpression(@"^[0-9]*\.?[0-9]*$")]
        public string Lat { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*\.?[0-9]*$")]
        public string Lng { get; set; }
    }
}
