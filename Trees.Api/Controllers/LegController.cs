using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trees.Api.Models.Dto.Leg;
using Trees.Core.Entities;
using Trees.Core.Interfaces;

namespace Trees.Api.Controllers
{
    public class LegController : BaseController
    {
        public LegController(ILegService legService, IMapper mapper)
        {
            _mapper = mapper;
            _legService = legService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(LegDto dto)
        {
            var result = _mapper.Map<Leg>(dto);

            await _legService.CreateAsync(result);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<LegResultDto[]>> Get()
        {
            var legs = await _legService.GetAllAsync();

            var result = _mapper.Map<List<LegResultDto>>(legs);

            return Ok(result.ToArray());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _legService.DeleteAsync(Guid.Parse(id));

            return Ok();
        }

        private readonly IMapper _mapper;
        private readonly ILegService _legService;
    }
}
