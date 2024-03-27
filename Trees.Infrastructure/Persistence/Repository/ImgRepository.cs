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
            ImgEntity? img = await _context.Img.FirstOrDefaultAsync(i => i.Id == id);

            var result = img != null ? _mapper.Map<Img>(img) : null;

            return result;
        }

        public async Task<List<Img>> GetAllAsync()
        {
            List<ImgEntity> imgs = await _context.Img.OrderBy(m => m.Name).ToListAsync();

            var result = _mapper.Map<List<Img>>(imgs);

            return result;
        }

        public async Task<bool> IsExistAsync(string name) => await _context.Img.AnyAsync(i => i.Name == name);

        public async Task<bool> IsUsedAsync(Guid id) => await _context.Tree.AnyAsync(t => t.ImgId == id);

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
