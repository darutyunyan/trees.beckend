using Trees.Core.Interfaces;
using Trees.Core.Models;

namespace Trees.Core.Services
{
    public class MaterialService : IMaterialService
    {
        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
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
            bool isUsed = await _materialRepository.IsUsedAsync(id);

            if (isUsed)
                throw new ArgumentException(); // TODO

            await _materialRepository.DeleteAsync(id);
        }

        private readonly IMaterialRepository _materialRepository;
    }
}
