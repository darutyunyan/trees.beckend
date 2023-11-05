using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trees.Api.Models.Dto.Location;
using Trees.Core.Models;
using Trees.Core.Interfaces;

namespace Trees.Api.Controllers
{
    public class LocationController : BaseController
    {
        public LocationController(IMapper mapper, ILocationService locationService)
        {
            _mapper = mapper;
            _locationService = locationService;
        }

        [HttpPost]
        public async Task<ActionResult> CreatOrUpdate(LocationDto dto)
        {
            var result = _mapper.Map<Location>(dto);

            await _locationService.CreateOrUpdateAsync(result);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<LocationResultDto>> Get()
        {
            var location = await _locationService.GetAsync();

            var result = _mapper.Map<LocationResultDto>(location);

            return Ok(result);
        }

        private readonly IMapper _mapper;
        private readonly ILocationService _locationService;
    }
}
