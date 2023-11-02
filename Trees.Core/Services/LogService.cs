using Trees.Core.Models;
using Trees.Core.Interfaces;

namespace Trees.Core.Services
{
    public class LogService : ILogService
    {
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task AddAsync(Log log) => await _logRepository.AddAsync(log);

        public async Task<List<Log>> GetTopAsync(int count) => await _logRepository.GetTopAsync(count);

        public async Task ClearAsync() => await _logRepository.ClearAsync();

        private readonly ILogRepository _logRepository;
    }
}
