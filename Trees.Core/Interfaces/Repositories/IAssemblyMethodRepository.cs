using Trees.Core.Entities;

namespace Trees.Core.Interfaces
{
    public interface IAssemblyMethodRepository
    {
        Task CreateAsync(AssemblyMethod brand);
        Task<AssemblyMethod?> GetAsync(Guid id);
        Task<List<AssemblyMethod>> GetAllAsync();
        Task<bool> IsExistAsync(string name);
        Task DeleteAsync(Guid id);
    }
}
