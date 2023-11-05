using System.ComponentModel.DataAnnotations;

namespace Trees.Api.Models.Dto.Img
{
    public class ImgResultDto
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public required string Path { get; set; }
    }
}
