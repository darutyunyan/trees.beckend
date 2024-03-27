using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface ITreeRepository
    {
        Task CreateAsync(Tree tree);
        Task UpdateAsync(Tree tree);
        Task<List<Tree>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
