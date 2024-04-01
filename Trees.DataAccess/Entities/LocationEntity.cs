using Microsoft.EntityFrameworkCore;
using Trees.DataAccess.Configurations;

namespace Trees.DataAccess.Entities
{
    [EntityTypeConfiguration(typeof(LocationEntityConfiguration))]
    public class LocationEntity
    {
        public Guid Id { get; set; }
        public required string Lat { get; set; }
        public required string Lng { get; set; }
    }
}
