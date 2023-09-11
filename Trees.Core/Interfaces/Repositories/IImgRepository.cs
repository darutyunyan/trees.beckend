using Trees.Core.Entities;

namespace Trees.Core.Interfaces
{
    public interface IImgRepository
    {
        Task CreateAsync(Img img);
        Task<Img?> GetAsync(Guid id);
        Task<List<Img>> GetAllAsync();
        Task<bool> IsExistAsync(string name);
        Task DeleteAsync(Guid id);
    }
}
