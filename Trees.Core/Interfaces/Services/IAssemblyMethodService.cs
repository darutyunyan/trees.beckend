using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface IAssemblyMethodService
    {
        Task CreateAsync(AssemblyMethod assemblyMethod);
        Task<AssemblyMethod?> GetAsync(Guid id);
        Task<List<AssemblyMethod>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
