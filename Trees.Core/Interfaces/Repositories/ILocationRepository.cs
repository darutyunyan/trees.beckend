using Trees.Core.Entities;

namespace Trees.Core.Interfaces
{
    public interface ILocationRepository
    {
        Task CreateOrUpdateAsync(Location location);
        Task<Location?> GetAsync();
    }
}
