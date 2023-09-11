using Trees.Core.Entities;

namespace Trees.Core.Interfaces
{
    public interface ILegRepository
    {
        Task CreateAsync(Leg leg);
        Task<Leg?> GetAsync(Guid id);
        Task<List<Leg>> GetAllAsync();
        Task<bool> IsExistAsync(string name);
        Task DeleteAsync(Guid id);
    }
}
