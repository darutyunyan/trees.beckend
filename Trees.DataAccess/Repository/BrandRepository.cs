using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;
using Trees.Core.Interfaces;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Repository
{
    public class BrandRepository : IBrandRepository
    {
        public BrandRepository(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(Brand brand)
        {
            if (brand == null)
                throw new ArgumentNullException(nameof(brand));

            var result = _mapper.Map<BrandEntity>(brand);

            await _context.Brand.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Brand?> GetAsync(Guid id)
        {
            BrandEntity? brand = await _context.Brand.FirstOrDefaultAsync(i => i.Id == id);

            var result = brand != null ? _mapper.Map<Brand>(brand) : null;

            return result;
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            List<BrandEntity> brands = await _context.Brand.OrderBy(m => m.Name).ToListAsync();

            var result = _mapper.Map<List<Brand>>(brands);

            return result;
        }

        public async Task<bool> IsExistAsync(string name) => await _context.Brand.AnyAsync(b => b.Name == name);

        public async Task<bool> IsUsedAsync(Guid id) => await _context.Tree.AnyAsync(t => t.BrandId == id);

        public async Task DeleteAsync(Guid id)
        {
            BrandEntity? brand = await _context.Brand.FirstOrDefaultAsync(b => b.Id == id);

            if (brand != null)
            {
                _context.Brand.Remove(brand);
                await _context.SaveChangesAsync();
            }
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
