using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface ITreeService
    {
        Task CreateAsync(TreeDetails treeDetails);
        Task UpdateAsync(TreeDetails treeDetails);
        Task<List<Tree>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
