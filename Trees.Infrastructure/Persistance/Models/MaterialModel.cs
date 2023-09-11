using System.ComponentModel.DataAnnotations;
namespace Trees.Infrastructure.Persistance.Models
{
    public class MaterialModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
