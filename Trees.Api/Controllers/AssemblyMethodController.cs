using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trees.Api.Models.Dto.AssemblyMethod;
using Trees.Core.Models;
using Trees.Core.Interfaces;

namespace Trees.Api.Controllers
{
    public class AssemblyMethodController : BaseController
    {
        public AssemblyMethodController(IMapper mapper, IAssemblyMethodService assemblyMethodService)
        {
            _mapper = mapper;
            _assemblyMethodService = assemblyMethodService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(AssemblyMethodDto dto)
        {
            var result = _mapper.Map<AssemblyMethod>(dto);

            await _assemblyMethodService.CreateAsync(result);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<AssemblyMethodResultDto[]>> Get()
        {
            var assemblyMethods = await _assemblyMethodService.GetAllAsync();

            var result = _mapper.Map<List<AssemblyMethodResultDto>>(assemblyMethods);

            return Ok(result.ToArray());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _assemblyMethodService.DeleteAsync(Guid.Parse(id));

            return Ok();
        }

        private readonly IMapper _mapper;
        private readonly IAssemblyMethodService _assemblyMethodService;
    }
}
