using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistence.Entities;

namespace Trees.Infrastructure.Persistence.Repository
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
            BrandEntity? brandModel = await _context.Brand.FirstOrDefaultAsync(i => i.Id == id);

            var result = brandModel != null ? _mapper.Map<Brand>(brandModel) : null;

            return result;
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            List<BrandEntity> brandModels = await _context.Brand.OrderBy(m => m.Name).ToListAsync();

            var result = _mapper.Map<List<Brand>>(brandModels);

            return result;
        }

        public async Task<bool> IsExistAsync(string name)
        {
            BrandEntity? brand = await _context.Brand.FirstOrDefaultAsync(b => b.Name == name);

            return brand != null;
        }

        public async Task DeleteAsync(Guid id)
        {
            BrandEntity? brandModel = await _context.Brand.FirstOrDefaultAsync(b => b.Id == id);

            if (brandModel != null)
            {
                _context.Brand.Remove(brandModel);
                await _context.SaveChangesAsync();
            }
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
