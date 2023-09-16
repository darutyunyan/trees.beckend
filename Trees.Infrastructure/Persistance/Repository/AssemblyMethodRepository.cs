using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Entities;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistance.Context;
using Trees.Infrastructure.Persistance.Models;

namespace Trees.Infrastructure.Persistance.Repository
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

            var result = _mapper.Map<AssemblyMethodModel>(assemblyMethod);

            await _context.AssemblyMethod.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<AssemblyMethod?> GetAsync(Guid id)
        {
            AssemblyMethodModel? assemblyMethodModel = await _context.AssemblyMethod.FirstOrDefaultAsync(i => i.Id == id);

            var result = assemblyMethodModel != null ? _mapper.Map<AssemblyMethod>(assemblyMethodModel) : null;

            return result;
        }

        public async Task<List<AssemblyMethod>> GetAllAsync()
        {
            List<AssemblyMethodModel> assemblyMethodModels = await _context.AssemblyMethod.OrderBy(m => m.Name).ToListAsync();

            var result = _mapper.Map<List<AssemblyMethod>>(assemblyMethodModels);

            return result;
        }

        public async Task<bool> IsExistAsync(string name)
        {
            AssemblyMethodModel? assemblyMethod = await _context.AssemblyMethod.FirstOrDefaultAsync(m => m.Name == name);

            return assemblyMethod != null;
        }

        public async Task DeleteAsync(Guid id)
        {
            AssemblyMethodModel? assemblyMethod = await _context.AssemblyMethod.FirstOrDefaultAsync(m => m.Id == id);

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
