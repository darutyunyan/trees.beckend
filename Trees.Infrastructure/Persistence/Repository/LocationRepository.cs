using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Models;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistence.Entities;

namespace Trees.Infrastructure.Persistence.Repository
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

            LocationEntity? locationModel = await _context.Location.FirstOrDefaultAsync();

            if (locationModel == null)
            {
                var result = _mapper.Map<LocationEntity>(location);
                await _context.Location.AddAsync(result);
            }
            else
            {
                locationModel.Lat = location.Lat;
                locationModel.Lng = location.Lng;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Location?> GetAsync()
        {
            LocationEntity? locationModel = await _context.Location.FirstOrDefaultAsync();

            var result = locationModel != null ? _mapper.Map<Location>(locationModel) : null;

            return result;
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
