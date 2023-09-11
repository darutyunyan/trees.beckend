namespace Trees.Infrastructure.Persistance.Models
{
	public class ImgModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Path { get; set; }
    }
}
