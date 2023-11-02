using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistence.Entities;

namespace Trees.Infrastructure.Persistence.Repository
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

            var result = _mapper.Map<TreeEntity>(tree);

            await _context.Tree.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tree tree)
        {
            var result = _mapper.Map<TreeEntity>(tree);

            _context.Tree.Update(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tree>> GetAllAsync()
        {
            var resultModels = await _context.Tree
                .Include(t => t.Img).Include(t => t.Leg).Include(t => t.Material)
                .Include(t => t.Brand).Include(t => t.AssemblyMethod)
                .OrderBy(n => n.Name)
                .ToListAsync();

            return _mapper.Map<List<Tree>>(resultModels);
        }

        public async Task DeleteAsync(Guid id)
        {
            TreeEntity? treeModel = await _context.Tree.FirstOrDefaultAsync(b => b.Id == id);

            if (treeModel != null)
            {
                _context.Tree.Remove(treeModel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Tree?> GetByMaterialIdAsync(Guid id)
        {
            TreeEntity? result = await _context.Tree.FirstOrDefaultAsync(p => p.ImgId == id);

            return result != null ? _mapper.Map<Tree>(result) : null;
        }

        public async Task<Tree?> GetByLegIdAsync(Guid id)
        {
            TreeEntity? result = await _context.Tree.FirstOrDefaultAsync(p => p.LegId == id);

            return result != null ? _mapper.Map<Tree>(result) : null;
        }

        public async Task<Tree?> GetByBrandIdAsync(Guid id)
        {
            TreeEntity? result = await _context.Tree.FirstOrDefaultAsync(p => p.BrandId == id);

            return result != null ? _mapper.Map<Tree>(result) : null;
        }

        public async Task<Tree?> GetByAssemblyMethodIdAsync(Guid id)
        {
            TreeEntity? result = await _context.Tree.FirstOrDefaultAsync(p => p.AssemblyMethodId == id);

            return result != null ? _mapper.Map<Tree>(result) : null;
        }

        public async Task<Tree?> GetByImgIdAsync(Guid id)
        {
            TreeEntity? result = await _context.Tree.FirstOrDefaultAsync(p => p.ImgId == id);

            return result != null ? _mapper.Map<Tree>(result) : null;
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
