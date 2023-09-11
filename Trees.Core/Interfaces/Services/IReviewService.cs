using Trees.Core.Entities;

namespace Trees.Core.Interfaces
{
    public interface IReviewService
	{
        Task CreateAsync(Review review);
        Task<List<Review>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
