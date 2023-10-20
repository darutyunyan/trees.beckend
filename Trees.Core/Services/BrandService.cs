using Trees.Core.Entities;
using Trees.Core.Interfaces;

namespace Trees.Core.Services
{
    public class BrandService : IBrandService
    {
        public BrandService(IBrandRepository brandRepository, ITreeRepository treeRepository)
        {
            _brandRepository = brandRepository;
            _treeRepository = treeRepository;
        }

        public async Task CreateAsync(Brand brand)
        {
            bool isExist = await _brandRepository.IsExistAsync(brand.Name);

            if (isExist)
                throw new ArgumentException(); //TODO

            await _brandRepository.CreateAsync(brand);
        }

        public async Task<Brand?> GetAsync(Guid id) => await _brandRepository.GetAsync(id);

        public async Task<List<Brand>> GetAllAsync() => await _brandRepository.GetAllAsync();

        public async Task DeleteAsync(Guid id)
        {
            bool isUsed = await _treeRepository.GetByBrandIdAsync(id) != null;

            if (isUsed)
                throw new ArgumentException(); // TODO

            await _brandRepository.DeleteAsync(id);
        }

        private readonly IBrandRepository _brandRepository;
        private readonly ITreeRepository _treeRepository;
    }
}
