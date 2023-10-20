namespace Trees.Api.Models.Dto
{
    public class FullTreeItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        //public TreeInfo[] Info { get; set; }
        public bool IsDisplay { get; set; }
       // public Img Img { get; set; }
       // public Leg Leg { get; set; }
       // public AssemblyMethod AssemblyMethod { get; set; }
       // public Material Material { get; set; }
        //public Brand Brand { get; set; }
    }
}
