using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trees.Core.Entities;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistance.Context;
using Trees.Infrastructure.Persistance.Models;

namespace Trees.Infrastructure.Persistance.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        public ReviewRepository(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(Review review)
        {
            if (review == null)
                throw new ArgumentNullException(nameof(review));

            var result = _mapper.Map<ReviewModel>(review);

            await _context.Review.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Review>> GetAllAsync()
        {
            List<ReviewModel> reviewModels = await _context.Review.OrderByDescending(r => r.Date).ToListAsync();

            var result = _mapper.Map<List<Review>>(reviewModels);

            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            ReviewModel? review = await _context.Review.FirstOrDefaultAsync(r => r.Id == id);

            if (review != null)
            {
                _context.Review.Remove(review);
                await _context.SaveChangesAsync();
            }
        }

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
    }
}
