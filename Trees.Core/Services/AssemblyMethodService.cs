using Trees.Core.Models;
using Trees.Core.Interfaces;
using System.Xml.Linq;

namespace Trees.Core.Services
{
    public class AssemblyMethodService : IAssemblyMethodService
    {
        public AssemblyMethodService(IAssemblyMethodRepository assemblyMethodRepository)
        {
            _assemblyMethodRepository = assemblyMethodRepository;
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
            bool isUsed = await _assemblyMethodRepository.IsUsedAsync(id);

            if (isUsed)
                throw new ArgumentException(); // TODO

            await _assemblyMethodRepository.DeleteAsync(id);
        }

        private readonly IAssemblyMethodRepository _assemblyMethodRepository;
    }
}
