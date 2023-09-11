using Trees.Core.Entities;

namespace Trees.Core.Interfaces
{
    public interface IMaterialRepository
    {
        Task CreateAsync(Material material);
        Task<Material?> GetAsync(Guid id);
        Task<List<Material>> GetAllAsync();
        Task<bool> IsExistAsync(string name);
        Task DeleteAsync(Guid id);
    }
}
