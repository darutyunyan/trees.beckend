using System.ComponentModel.DataAnnotations;
namespace Trees.Core.Models
{
    public class Material
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
