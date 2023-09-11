using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Entities;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistance.Context;
using Trees.Infrastructure.Persistance.Models;

namespace Trees.Infrastructure.Persistance.Repository
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

            var result = _mapper.Map<LegModel>(leg);

            await _context.Legs.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Leg?> GetAsync(Guid id)
        {
            LegModel? legModel = await _context.Legs.FirstOrDefaultAsync(l => l.Id == id);

            var result = legModel != null ? _mapper.Map<Leg>(legModel) : null;

            return result;
        }

        public async Task<List<Leg>> GetAllAsync()
        {
            List<LegModel> legModels = await _context.Legs.OrderBy(l => l.Name).ToListAsync();

            var result = _mapper.Map<List<Leg>>(legModels);

            return result;
        }

        public async Task<bool> IsExistAsync(string name)
        {
            LegModel? leg = await _context.Legs.FirstOrDefaultAsync(l => l.Name == name);

            return leg != null;
        }

        public async Task DeleteAsync(Guid id)
        {
            LegModel? leg = await _context.Legs.FirstOrDefaultAsync(l => l.Id == id);

            if (leg != null)
            {
                _context.Legs.Remove(leg);
                await _context.SaveChangesAsync();
            }
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
