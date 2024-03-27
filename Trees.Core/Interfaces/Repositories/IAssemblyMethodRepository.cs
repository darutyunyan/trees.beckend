using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface IAssemblyMethodRepository
    {
        Task CreateAsync(AssemblyMethod brand);
        Task<AssemblyMethod?> GetAsync(Guid id);
        Task<List<AssemblyMethod>> GetAllAsync();
        Task<bool> IsExistAsync(string name);
        Task<bool> IsUsedAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
