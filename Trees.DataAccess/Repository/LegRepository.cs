using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;
using Trees.Core.Interfaces;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Repository
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
            LegEntity? leg = await _context.Leg.FirstOrDefaultAsync(l => l.Id == id);

            var result = leg != null ? _mapper.Map<Leg>(leg) : null;

            return result;
        }

        public async Task<List<Leg>> GetAllAsync()
        {
            List<LegEntity> legs = await _context.Leg.OrderBy(l => l.Name).ToListAsync();

            var result = _mapper.Map<List<Leg>>(legs);

            return result;
        }

        public async Task<bool> IsExistAsync(string name) => await _context.Leg.AnyAsync(l => l.Name == name);

        public async Task<bool> IsUsedAsync(Guid id) => await _context.Tree.AnyAsync(t => t.LegId == id);

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
