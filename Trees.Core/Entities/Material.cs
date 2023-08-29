using System.ComponentModel.DataAnnotations;
namespace Trees.Core.Entities
{
    public class Material
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
