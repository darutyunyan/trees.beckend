using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface ITreeRepository
    {
        Task CreateAsync(Tree tree);
        Task UpdateAsync(Tree tree);
        Task<List<Tree>> GetAllAsync();
        Task DeleteAsync(Guid id);
        Task<Tree?> GetByMaterialIdAsync(Guid id);
        Task<Tree?> GetByLegIdAsync(Guid id);
        Task<Tree?> GetByBrandIdAsync(Guid id);
        Task<Tree?> GetByAssemblyMethodIdAsync(Guid id);
        Task<Tree?> GetByImgIdAsync(Guid id);
    }
}
