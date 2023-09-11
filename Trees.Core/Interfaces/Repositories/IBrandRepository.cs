using Trees.Core.Entities;

namespace Trees.Core.Interfaces
{
    public interface IBrandRepository
    {
        Task CreateAsync(Brand brand);
        Task<Brand?> GetAsync(Guid id);
        Task<List<Brand>> GetAllAsync();
        Task<bool> IsExistAsync(string name);
        Task DeleteAsync(Guid id);
    }
}
