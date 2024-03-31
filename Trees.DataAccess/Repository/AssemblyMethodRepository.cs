using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;
using Trees.Core.Interfaces;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Repository
{
    public class AssemblyMethodRepository : IAssemblyMethodRepository
    {
        public AssemblyMethodRepository(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(AssemblyMethod assemblyMethod)
        {
            if (assemblyMethod == null)
                throw new ArgumentNullException(nameof(assemblyMethod));

            var result = _mapper.Map<AssemblyMethodEntity>(assemblyMethod);

            await _context.AssemblyMethod.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<AssemblyMethod?> GetAsync(Guid id)
        {
            AssemblyMethodEntity? assemblyMethod = await _context.AssemblyMethod.FirstOrDefaultAsync(i => i.Id == id);

            var result = assemblyMethod != null ? _mapper.Map<AssemblyMethod>(assemblyMethod) : null;

            return result;
        }

        public async Task<List<AssemblyMethod>> GetAllAsync()
        {
            List<AssemblyMethodEntity> assemblyMethods = await _context.AssemblyMethod.OrderBy(m => m.Name).ToListAsync();

            var result = _mapper.Map<List<AssemblyMethod>>(assemblyMethods);

            return result;
        }

        public async Task<bool> IsExistAsync(string name)
            => await _context.AssemblyMethod.AnyAsync(am => am.Name == name);

        public async Task<bool> IsUsedAsync(Guid id)
            => await _context.Tree.AnyAsync(t => t.AssemblyMethodId == id);

        public async Task DeleteAsync(Guid id)
        {
            AssemblyMethodEntity? assembly = await _context.AssemblyMethod.FirstOrDefaultAsync(m => m.Id == id);

            if (assembly != null)
            {
                _context.AssemblyMethod.Remove(assembly);
                await _context.SaveChangesAsync();
            }
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
