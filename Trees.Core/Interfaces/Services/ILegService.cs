using Trees.Core.Entities;

namespace Trees.Core.Interfaces
{
    public interface ILegService
    {
        Task CreateAsync(Leg leg);
        Task<Leg?> GetAsync(Guid id);
        Task<List<Leg>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
