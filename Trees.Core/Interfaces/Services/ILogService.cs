using Trees.Core.Entities;

namespace Trees.Core.Interfaces
{
    public interface ILogService
    {
        Task AddAsync(Log log);
        Task<List<Log>> GetTopAsync(int count);
        Task ClearAsync();
    }
}
