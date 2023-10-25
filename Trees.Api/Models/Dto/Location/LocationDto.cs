using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto.Location
{
    public class LocationDto
    {
        [Required]
        [RegularExpression(@"^[0-9]*\.?[0-9]*$")]
        public required string Lat { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*\.?[0-9]*$")]
        public required string Lng { get; set; }
    }
}
