using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface ITreeService
    {
        Task CreateAsync(Tree tree);
        Task UpdateAsync(Tree tree);
        Task<List<Tree>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
