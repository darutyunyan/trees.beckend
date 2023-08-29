namespace Trees.Core.Entities
{
	public class Tree
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public string? FullName { get; set; }
		public string? Description { get; set; }
		public required string Info { get; set; }
		public bool IsDisplay { get; set; }
		public Guid ImgId { get; set; }
		public required Img Img { get; set; }
		public Guid? LegId { get; set; }
		public Leg? Leg { get; set; }
		public Guid? AssemblyMethodId { get; set; }
		public AssemblyMethod? AssemblyMethod { get; set; }
		public Guid? MaterialId { get; set; }
		public Material? Material { get; set; }
		public Guid? BrandId { get; set; }
		public Brand? Brand { get; set; }
	}
}
