using Microsoft.EntityFrameworkCore;
using Trees.DataAccess.Configurations;

namespace Trees.DataAccess.Entities
{
    [EntityTypeConfiguration(typeof(TreeEntityConfiguration))]
    public class TreeEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public required string Info { get; set; }
        public bool IsDisplay { get; set; }
        public required List<ImgEntity> Imgs { get; set; }
        public Guid? LegId { get; set; }
        public LegEntity? Leg { get; set; }
        public Guid? AssemblyMethodId { get; set; }
        public AssemblyMethodEntity? AssemblyMethod { get; set; }
        public Guid? MaterialId { get; set; }
        public MaterialEntity? Material { get; set; }
        public Guid? BrandId { get; set; }
        public BrandEntity? Brand { get; set; }
    }
}
