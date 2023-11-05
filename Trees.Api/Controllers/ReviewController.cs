using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trees.Api.Models.Dto.Review;
using Trees.Core.Models;
using Trees.Core.Interfaces;

namespace Trees.Api.Controllers
{
    public class ReviewController : BaseController
    {
        public ReviewController(IMapper mapper, IReviewService reviewService)
        {
            _mapper = mapper;
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(ReviewDto dto)
        {
            var result = _mapper.Map<Review>(dto);

            await _reviewService.CreateAsync(result);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ReviewResultDto[]>> Get()
        {
            var reviews = await _reviewService.GetAllAsync();

            var result = _mapper.Map<List<ReviewResultDto>>(reviews);

            return Ok(result.ToArray());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _reviewService.DeleteAsync(Guid.Parse(id));

            return Ok();
        }

        private readonly IMapper _mapper;
        private readonly IReviewService _reviewService;
    }
}
