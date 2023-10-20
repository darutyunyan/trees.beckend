using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trees.Api.Models.Dto;
using Trees.Core.Entities;
using Trees.Core.Interfaces;

namespace Trees.Api.Controllers
{
    public class BrandController : BaseController
    {
        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _mapper = mapper;
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(AddSimpleDto dto)
        {
            var result = _mapper.Map<Brand>(dto);

            await _brandService.CreateAsync(result);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<Brand[]>> Get()
        {
            var brands = await _brandService.GetAllAsync();

            var result = _mapper.Map<List<SimpleItem>>(brands);

            return Ok(result.ToArray());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _brandService.DeleteAsync(Guid.Parse(id)); // exception

            return Ok();
        }

        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;
    }
}
