using Trees.Core.Entities;

namespace RestApi.Models.Repository
{
	public interface IReviewRepository
    {
        Task CreateAsync(Review review);
        Task<List<Review>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
