using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface IImgService
    {
        Task CreateAsync(Img img);
        Task<Img?> GetAsync(Guid id);
        Task<List<Img>> GetAsync(List<Guid> ids);
        Task<List<Img>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
