using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistence.Entities;

namespace Trees.Infrastructure.Persistence.Repository
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

            var result = _mapper.Map<ImgEntity>(img);

            await _context.Img.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Img?> GetAsync(Guid id)
        {
            ImgEntity? imgModel = await _context.Img.FirstOrDefaultAsync(i => i.Id == id);

            var result = imgModel != null ? _mapper.Map<Img>(imgModel) : null;

            return result;
        }

        public async Task<List<Img>> GetAllAsync()
        {
            List<ImgEntity> imgModels = await _context.Img.OrderBy(m => m.Name).ToListAsync();

            var result = _mapper.Map<List<Img>>(imgModels);

            return result;
        }

        public async Task<bool> IsExistAsync(string name)
        {
            ImgEntity? img = await _context.Img.FirstOrDefaultAsync(i => i.Name == name);

            return img != null;
        }

        public async Task DeleteAsync(Guid id)
        {
            ImgEntity? img = await _context.Img.FirstOrDefaultAsync(i => i.Id == id);

            if (img != null)
            {
                _context.Img.Remove(img);
                await _context.SaveChangesAsync();
            }
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
