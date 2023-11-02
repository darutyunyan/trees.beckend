using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface IMaterialService
    {
        Task CreateAsync(Material material);
        Task<Material?> GetAsync(Guid id);
        Task<List<Material>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
