using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Entities;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistance.Context;
using Trees.Infrastructure.Persistance.Models;

namespace Trees.Infrastructure.Persistance.Repository
{
    public class LocationRepository : ILocationRepository
    {
        public LocationRepository(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateOrUpdateAsync(Location location)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            Location? currentLocation = await GetAsync();

            var result = _mapper.Map<LocationModel>(currentLocation);

            if (result == null)
                await _context.Locations.AddAsync(result);
            else
                _context.Locations.Update(result);

            await _context.SaveChangesAsync();
        }

        public async Task<Location?> GetAsync()
        {
            LocationModel? locationModel = await _context.Locations.FirstOrDefaultAsync();

            var result = locationModel != null ? _mapper.Map<Location>(locationModel) : null;

            return result;
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
