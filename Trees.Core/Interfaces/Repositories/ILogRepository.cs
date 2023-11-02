using Trees.Core.Models;

namespace Trees.Core.Interfaces
{
    public interface ILogRepository
    {
        Task AddAsync(Log log);
        Task<List<Log>> GetTopAsync(int count);
        Task ClearAsync();
    }
}
