namespace Trees.Infrastructure.Persistance.Models
{
	public class TreeModel
    {
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public string? FullName { get; set; }
		public string? Description { get; set; }
		public required string Info { get; set; }
		public bool IsDisplay { get; set; }
		public Guid ImgId { get; set; }
		public required ImgModel Img { get; set; }
		public Guid? LegId { get; set; }
		public LegModel? Leg { get; set; }
		public Guid? AssemblyMethodId { get; set; }
		public AssemblyMethodModel? AssemblyMethod { get; set; }
		public Guid? MaterialId { get; set; }
		public MaterialModel? Material { get; set; }
		public Guid? BrandId { get; set; }
		public BrandModel? Brand { get; set; }
	}
}
