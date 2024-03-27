using Trees.Core.Models;
using Trees.Core.Interfaces;
using System.Xml.Linq;

namespace Trees.Core.Services
{
    public class LegService : ILegService
    {
        public LegService(ILegRepository legRepository)
        {
            _legRepository = legRepository;
        }

        public async Task CreateAsync(Leg leg)
        {
            bool isExist = await _legRepository.IsExistAsync(leg.Name);

            if (isExist)
                throw new ArgumentException(); //TODO

            await _legRepository.CreateAsync(leg);
        }

        public async Task<Leg?> GetAsync(Guid id) => await _legRepository.GetAsync(id);

        public async Task<List<Leg>> GetAllAsync() => await _legRepository.GetAllAsync();

        public async Task DeleteAsync(Guid id)
        {
            bool isUsed = await _legRepository.IsUsedAsync(id);

            if (isUsed)
                throw new ArgumentException(); // TODO

            await _legRepository.DeleteAsync(id);
        }

        private readonly ILegRepository _legRepository;
    }
}
