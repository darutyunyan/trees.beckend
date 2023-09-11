using Trees.Core.Entities;
using Trees.Core.Interfaces;

namespace Trees.Core.Services
{
    public class LocationService : ILocationService
    {
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task CreateOrUpdateAsync(Location location) => await _locationRepository.CreateOrUpdateAsync(location);

        public async Task<Location?> GetAsync()
        {
            Location? location = await _locationRepository.GetAsync();

            return location ?? DEFAULT_LOCATION;
        }

        private readonly Location DEFAULT_LOCATION = new()
        {
            Id = Guid.NewGuid(),
            Lat = "40.738379395637985",
            Lng = "-73.76916818829386"
        };

        private readonly ILocationRepository _locationRepository;
    }
}
