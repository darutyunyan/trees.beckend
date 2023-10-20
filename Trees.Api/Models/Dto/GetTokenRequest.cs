using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto
{
    public class GetTokenRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
