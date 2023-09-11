using Trees.Core.Entities;

namespace Trees.Core.Interfaces
{
    public interface ILogRepository
    {
        Task AddAsync(Log log);
        Task<List<Log>> GetTopAsync(int count);
        Task ClearAsync();
    }
}
