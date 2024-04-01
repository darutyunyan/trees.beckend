using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;
using Trees.Core.Interfaces;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Repository
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
            List<TreeEntity> results = await _context.Tree
                //.Include(t => t.Img)
                .Include(t => t.Leg)
                .Include(t => t.Material)
                .Include(t => t.Brand)
                .Include(t => t.AssemblyMethod)
                .OrderBy(n => n.Name)
                .ToListAsync();

            return _mapper.Map<List<Tree>>(results);
        }

        public async Task DeleteAsync(Guid id)
        {
            TreeEntity? tree = await _context.Tree.FirstOrDefaultAsync(b => b.Id == id);

            if (tree != null)
            {
                _context.Tree.Remove(tree);
                await _context.SaveChangesAsync();
            }
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
