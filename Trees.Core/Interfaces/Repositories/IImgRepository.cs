using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface IImgRepository
    {
        Task CreateAsync(Img img);
        Task<Img?> GetAsync(Guid id);
        Task<List<Img>> GetAsync(List<Guid> ids);
        Task<List<Img>> GetAllAsync();
        Task<bool> IsExistAsync(string name);
        Task<bool> IsUsedAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
