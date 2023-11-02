using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistence.Entities;

namespace Trees.Infrastructure.Persistence.Repository
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
            AssemblyMethodEntity? assemblyMethodModel = await _context.AssemblyMethod.FirstOrDefaultAsync(i => i.Id == id);

            var result = assemblyMethodModel != null ? _mapper.Map<AssemblyMethod>(assemblyMethodModel) : null;

            return result;
        }

        public async Task<List<AssemblyMethod>> GetAllAsync()
        {
            List<AssemblyMethodEntity> assemblyMethodModels = await _context.AssemblyMethod.OrderBy(m => m.Name).ToListAsync();

            var result = _mapper.Map<List<AssemblyMethod>>(assemblyMethodModels);

            return result;
        }

        public async Task<bool> IsExistAsync(string name)
        {
            AssemblyMethodEntity? assemblyMethod = await _context.AssemblyMethod.FirstOrDefaultAsync(m => m.Name == name);

            return assemblyMethod != null;
        }

        public async Task DeleteAsync(Guid id)
        {
            AssemblyMethodEntity? assemblyMethod = await _context.AssemblyMethod.FirstOrDefaultAsync(m => m.Id == id);

            if (assemblyMethod != null)
            {
                _context.AssemblyMethod.Remove(assemblyMethod);
                await _context.SaveChangesAsync();
            }
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
