namespace Trees.Core.Models
{
    public class TreeDetails
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public required string[] Info { get; set; }
        public bool IsDisplay { get; set; }
        public required List<Guid> Imgs { get; set; }
        public Guid? LegId { get; set; }
        public Guid? AssemblyMethodId { get; set; }
        public Guid? MaterialId { get; set; }
        public Guid? BrandId { get; set; }
    }
}
