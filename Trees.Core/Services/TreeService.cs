using Trees.Core.Models;
using Trees.Core.Interfaces;

namespace Trees.Core.Services
{
    public class TreeService : ITreeService
    {
        public TreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository;
        }

        public async Task CreateAsync(Tree tree) { }

        public async Task UpdateAsync(Tree tree) { }

        public async Task<List<Tree>> GetAllAsync() => await _treeRepository.GetAllAsync();

        public async Task DeleteAsync(Guid id) => await _treeRepository.DeleteAsync(id);

        private readonly ITreeRepository _treeRepository;
    }
}
