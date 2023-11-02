using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistence.Entities;

namespace Trees.Infrastructure.Persistence.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        public MaterialRepository(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(Material material)
        {
            if (material == null)
                throw new ArgumentNullException(nameof(material));

            var result = _mapper.Map<MaterialEntity>(material);

            await _context.Material.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Material?> GetAsync(Guid id)
        {
            MaterialEntity? materialModel = await _context.Material.FirstOrDefaultAsync(m => m.Id == id);

            var result = materialModel != null ? _mapper.Map<Material>(materialModel) : null;

            return result;
        }

        public async Task<List<Material>> GetAllAsync()
        {
            List<MaterialEntity> materialModels = await _context.Material.OrderBy(m => m.Name).ToListAsync();

            var result = _mapper.Map<List<Material>>(materialModels);

            return result;
        }

        public async Task<bool> IsExistAsync(string name)
        {
            MaterialEntity? material = await _context.Material.FirstOrDefaultAsync(m => m.Name == name);

            return material != null;
        }

        public async Task DeleteAsync(Guid id)
        {
            MaterialEntity? material = await _context.Material.FirstOrDefaultAsync(l => l.Id == id);

            if (material != null)
            {
                _context.Material.Remove(material);
                await _context.SaveChangesAsync();
            }
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
