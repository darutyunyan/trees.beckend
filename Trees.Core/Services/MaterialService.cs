using Trees.Core.Entities;
using Trees.Core.Interfaces;

namespace Trees.Core.Services
{
    public class MaterialService : IMaterialService
    {
        public MaterialService(IMaterialRepository materialRepository, ITreeRepository treeRepository)
        {
            _materialRepository = materialRepository;
            _treeRepository = treeRepository;
        }

        public async Task CreateAsync(Material material)
        {
            bool isExist = await _materialRepository.IsExistAsync(material.Name);

            if (isExist)
                throw new ArgumentException(); //TODO

            await _materialRepository.CreateAsync(material);
        }

        public async Task<Material?> GetAsync(Guid id) => await _materialRepository.GetAsync(id);

        public async Task<List<Material>> GetAllAsync() => await _materialRepository.GetAllAsync();

        public async Task DeleteAsync(Guid id)
        {
            bool isUsed = await _treeRepository.GetByMaterialIdAsync(id) != null;

            if (isUsed)
                throw new ArgumentException(); // TODO

            await _materialRepository.DeleteAsync(id);
        }

        private readonly IMaterialRepository _materialRepository;
        private readonly ITreeRepository _treeRepository;
    }
}
