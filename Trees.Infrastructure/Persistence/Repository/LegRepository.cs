using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistence.Entities;

namespace Trees.Infrastructure.Persistence.Repository
{
    public class LegRepository : ILegRepository
    {
        public LegRepository(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(Leg leg)
        {
            if (leg == null)
                throw new ArgumentNullException(nameof(leg));

            var result = _mapper.Map<LegEntity>(leg);

            await _context.Leg.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Leg?> GetAsync(Guid id)
        {
            LegEntity? legModel = await _context.Leg.FirstOrDefaultAsync(l => l.Id == id);

            var result = legModel != null ? _mapper.Map<Leg>(legModel) : null;

            return result;
        }

        public async Task<List<Leg>> GetAllAsync()
        {
            List<LegEntity> legModels = await _context.Leg.OrderBy(l => l.Name).ToListAsync();

            var result = _mapper.Map<List<Leg>>(legModels);

            return result;
        }

        public async Task<bool> IsExistAsync(string name)
        {
            LegEntity? leg = await _context.Leg.FirstOrDefaultAsync(l => l.Name == name);

            return leg != null;
        }

        public async Task DeleteAsync(Guid id)
        {
            LegEntity? leg = await _context.Leg.FirstOrDefaultAsync(l => l.Id == id);

            if (leg != null)
            {
                _context.Leg.Remove(leg);
                await _context.SaveChangesAsync();
            }
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
