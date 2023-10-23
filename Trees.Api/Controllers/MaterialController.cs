using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trees.Api.Models.Dto.Material;
using Trees.Core.Entities;
using Trees.Core.Interfaces;

namespace Trees.Api.Controllers
{
    public class MaterialController : BaseController
    {
        public MaterialController(IMaterialService materialService, IMapper mapper)
        {
            _mapper = mapper;
            _materialService = materialService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(MaterialDto dto)
        {
            var result = _mapper.Map<Material>(dto);

            await _materialService.CreateAsync(result);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<MaterialResultDto[]>> Get()
        {
            var materials = await _materialService.GetAllAsync();

            var result = _mapper.Map<List<MaterialResultDto>>(materials);

            return Ok(result.ToArray());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _materialService.DeleteAsync(Guid.Parse(id));

            return Ok();
        }

        private readonly IMapper _mapper;
        private readonly IMaterialService _materialService;
    }
}
