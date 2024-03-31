namespace Trees.DataAccess.Entities
{
    public class ImgEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Path { get; set; }
    }
}
