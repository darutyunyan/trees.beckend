using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;
using Trees.Core.Interfaces;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Repository
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

            LocationEntity? locationEntity = await _context.Location.FirstOrDefaultAsync();

            if (locationEntity == null)
            {
                var result = _mapper.Map<LocationEntity>(location);
                await _context.Location.AddAsync(result);
            }
            else
            {
                locationEntity.Lat = location.Lat;
                locationEntity.Lng = location.Lng;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Location?> GetAsync()
        {
            LocationEntity? location = await _context.Location.FirstOrDefaultAsync();

            var result = location != null ? _mapper.Map<Location>(location) : null;

            return result;
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
