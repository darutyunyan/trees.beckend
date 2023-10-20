using Trees.Core.Entities;
using Trees.Core.Interfaces;

namespace Trees.Core.Services
{
    public class AssemblyMethodService : IAssemblyMethodService
    {
        public AssemblyMethodService(IAssemblyMethodRepository assemblyMethodRepository, ITreeRepository treeRepository)
        {
            _assemblyMethodRepository = assemblyMethodRepository;
            _treeRepository = treeRepository;
        }

        public async Task CreateAsync(AssemblyMethod assemblyMethod)
        {
            bool isExist = await _assemblyMethodRepository.IsExistAsync(assemblyMethod.Name);

            if (isExist)
                throw new ArgumentException(); //TODO

            await _assemblyMethodRepository.CreateAsync(assemblyMethod);
        }

        public async Task<AssemblyMethod?> GetAsync(Guid id) => await _assemblyMethodRepository.GetAsync(id);

        public async Task<List<AssemblyMethod>> GetAllAsync() => await _assemblyMethodRepository.GetAllAsync();

        public async Task DeleteAsync(Guid id)
        {
            bool isUsed = await _treeRepository.GetByAssemblyMethodIdAsync(id) != null;

            if (isUsed)
                throw new ArgumentException(); // TODO

            await _assemblyMethodRepository.GetAsync(id);
        }

        private readonly IAssemblyMethodRepository _assemblyMethodRepository;
        private readonly ITreeRepository _treeRepository;
    }
}
