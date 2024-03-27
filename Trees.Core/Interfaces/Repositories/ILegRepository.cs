using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface ILegRepository
    {
        Task CreateAsync(Leg leg);
        Task<Leg?> GetAsync(Guid id);
        Task<List<Leg>> GetAllAsync();
        Task<bool> IsExistAsync(string name);
        Task<bool> IsUsedAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
