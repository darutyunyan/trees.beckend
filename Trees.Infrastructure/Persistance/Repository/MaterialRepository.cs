using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Entities;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistance.Context;
using Trees.Infrastructure.Persistance.Models;

namespace Trees.Infrastructure.Persistance.Repository
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

            var result = _mapper.Map<MaterialModel>(material);

            await _context.Materials.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Material?> GetAsync(Guid id)
        {
            MaterialModel? materialModel = await _context.Materials.FirstOrDefaultAsync(m => m.Id == id);

            var result = materialModel != null ? _mapper.Map<Material>(materialModel) : null;

            return result;
        }

        public async Task<List<Material>> GetAllAsync()
        {
            List<MaterialModel> materialModels = await _context.Materials.OrderBy(m => m.Name).ToListAsync();

            var result = _mapper.Map<List<Material>>(materialModels);

            return result;
        }

        public async Task<bool> IsExistAsync(string name)
        {
            MaterialModel? material = await _context.Materials.FirstOrDefaultAsync(m => m.Name == name);

            return material != null;
        }

        public async Task DeleteAsync(Guid id)
        {
            MaterialModel? material = await _context.Materials.FirstOrDefaultAsync(l => l.Id == id);

            if (material != null)
            {
                _context.Materials.Remove(material);
                await _context.SaveChangesAsync();
            }
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
