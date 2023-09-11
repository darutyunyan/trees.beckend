using Trees.Core.Entities;

namespace Trees.Core.Interfaces
{
    public interface ILocationService
    {
        Task CreateOrUpdateAsync(Location location);
        Task<Location?> GetAsync();
    }
}
