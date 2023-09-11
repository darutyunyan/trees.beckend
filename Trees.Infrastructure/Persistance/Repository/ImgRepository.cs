using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Entities;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistance.Context;
using Trees.Infrastructure.Persistance.Models;

namespace Trees.Infrastructure.Persistance.Repository
{
    public class ImgRepository : IImgRepository
    {
        public ImgRepository(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(Img img)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));

            var result = _mapper.Map<ImgModel>(img);

            await _context.Imgs.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Img?> GetAsync(Guid id)
        {
            ImgModel? imgModel = await _context.Imgs.FirstOrDefaultAsync(i => i.Id == id);

            var result = imgModel != null ? _mapper.Map<Img>(imgModel) : null;

            return result;
        }

        public async Task<List<Img>> GetAllAsync()
        {
            List<ImgModel> imgModels = await _context.Imgs.OrderBy(m => m.Name).ToListAsync();

            var result = _mapper.Map<List<Img>>(imgModels);

            return result;
        }

        public async Task<bool> IsExistAsync(string name)
        {
            ImgModel? img = await _context.Imgs.FirstOrDefaultAsync(i => i.Name == name);

            return img != null;
        }

        public async Task DeleteAsync(Guid id)
        {
            ImgModel? img = await _context.Imgs.FirstOrDefaultAsync(i => i.Id == id);

            if (img != null)
            {
                _context.Imgs.Remove(img);
                await _context.SaveChangesAsync();
            }
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
