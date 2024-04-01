namespace Trees.Core.Models
{
    public class Tree
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public required string InfoXml { get; set; }
        public bool IsDisplay { get; set; }
        public required List<Img> Imgs { get; set; }
        public Leg? Leg { get; set; }
        public AssemblyMethod? AssemblyMethod { get; set; }
        public Material? Material { get; set; }
        public Brand? Brand { get; set; }
    }
}
