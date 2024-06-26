using Trees.Core.Models;
using Trees.Core.Interfaces;

namespace Trees.Core.Services
{
    public class ImgService : IImgService
    {
        public ImgService(IImgRepository imgRepository)
        {
            _imgRepository = imgRepository;
        }

        public async Task CreateAsync(Img img)
        {
            bool isExist = await _imgRepository.IsExistAsync(img.Name);

            if (isExist)
                throw new ArgumentException(); //TODO

            await _imgRepository.CreateAsync(img);
        }

        public async Task<Img?> GetAsync(Guid id) => await _imgRepository.GetAsync(id);
        public async Task<List<Img>> GetAsync(List<Guid> ids) => await _imgRepository.GetAsync(ids);
        public async Task<List<Img>> GetAllAsync() => await _imgRepository.GetAllAsync();

        public async Task DeleteAsync(Guid id)
        {
            bool isUsed = await _imgRepository.IsUsedAsync(id);

            if (isUsed)
                throw new ArgumentException(); // TODO

            await _imgRepository.DeleteAsync(id);
        }

        private readonly IImgRepository _imgRepository;
    }
}
