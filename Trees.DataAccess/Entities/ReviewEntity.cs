using Microsoft.EntityFrameworkCore;
using Trees.DataAccess.Configurations;

namespace Trees.DataAccess.Entities
{
    [EntityTypeConfiguration(typeof(ReviewEntityConfiguration))]
    public class ReviewEntity
    {
        public Guid Id { get; set; }
        public required string Author { get; set; }
        public required DateTime Date { get; set; }
        public required string Comment { get; set; }
    }
}
