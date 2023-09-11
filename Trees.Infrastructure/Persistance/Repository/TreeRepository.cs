using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Entities;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistance.Context;
using Trees.Infrastructure.Persistance.Models;

namespace Trees.Infrastructure.Persistance.Repository
{
    public class TreeRepository : ITreeRepository
    {
        public TreeRepository(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(Tree tree)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree));

            var result = _mapper.Map<TreeModel>(tree);

            await _context.Trees.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tree tree)
        {
            var result = _mapper.Map<TreeModel>(tree);

            _context.Trees.Update(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tree>> GetAllAsync()
        {
            var resultModels = await _context.Trees
                .Include(t => t.Img).Include(t => t.Leg).Include(t => t.Material)
                .Include(t => t.Brand).Include(t => t.AssemblyMethod)
                .OrderBy(n => n.Name)
                .ToListAsync();

            return _mapper.Map<List<Tree>>(resultModels);
        }

        public async Task DeleteAsync(Guid id)
        {
            TreeModel? treeModel = await _context.Trees.FirstOrDefaultAsync(b => b.Id == id);

            if (treeModel != null)
            {
                _context.Trees.Remove(treeModel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Tree?> GetByMaterialIdAsync(Guid id)
        {
            TreeModel? result = await _context.Trees.FirstOrDefaultAsync(p => p.ImgId == id);

            return result != null ? _mapper.Map<Tree>(result) : null;
        }

        public async Task<Tree?> GetByLegIdAsync(Guid id)
        {

            TreeModel? result = await _context.Trees.FirstOrDefaultAsync(p => p.LegId == id);

            return result != null ? _mapper.Map<Tree>(result) : null;
        }

        public async Task<Tree?> GetByBrandIdAsync(Guid id)
        {
            TreeModel? result = await _context.Trees.FirstOrDefaultAsync(p => p.BrandId == id);

            return result != null ? _mapper.Map<Tree>(result) : null;
        }

        public async Task<Tree?> GetByAssemblyMethodIdAsync(Guid id)
        {
            TreeModel? result = await _context.Trees.FirstOrDefaultAsync(p => p.AssemblyMethodId == id);

            return result != null ? _mapper.Map<Tree>(result) : null;
        }

        public async Task<Tree?> GetByImgIdAsync(Guid id)
        {
            TreeModel? result = await _context.Trees.FirstOrDefaultAsync(p => p.ImgId == id);

            return result != null ? _mapper.Map<Tree>(result) : null;
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
