using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface IMaterialRepository
    {
        Task CreateAsync(Material material);
        Task<Material?> GetAsync(Guid id);
        Task<List<Material>> GetAllAsync();
        Task<bool> IsExistAsync(string name);
        Task<bool> IsUsedAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
