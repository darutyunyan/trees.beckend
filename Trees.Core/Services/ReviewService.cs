using Trees.Core.Models;
using Trees.Core.Interfaces;

namespace Trees.Core.Services
{
    public class ReviewService : IReviewService
    {
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task CreateAsync(Review review) => await _reviewRepository.CreateAsync(review);

        public async Task<List<Review>> GetAllAsync() => await _reviewRepository.GetAllAsync();

        public async Task DeleteAsync(Guid id) => await _reviewRepository.DeleteAsync(id);

        private readonly IReviewRepository _reviewRepository;
    }
}
