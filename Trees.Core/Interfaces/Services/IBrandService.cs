using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface IBrandService
    {
        Task CreateAsync(Brand brand);
        Task<Brand?> GetAsync(Guid id);
        Task<List<Brand>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
