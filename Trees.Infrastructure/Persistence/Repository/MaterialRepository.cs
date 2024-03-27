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
            MaterialEntity? materialEntity = await _context.Material.FirstOrDefaultAsync(m => m.Id == id);

            var result = materialEntity != null ? _mapper.Map<Material>(materialEntity) : null;

            return result;
        }

        public async Task<List<Material>> GetAllAsync()
        {
            List<MaterialEntity> materials = await _context.Material.OrderBy(m => m.Name).ToListAsync();

            var result = _mapper.Map<List<Material>>(materials);

            return result;
        }

        public async Task<bool> IsExistAsync(string name) => await _context.Material.AnyAsync(m => m.Name == name);

        public async Task<bool> IsUsedAsync(Guid id) => await _context.Tree.AnyAsync(t => t.MaterialId == id);

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
