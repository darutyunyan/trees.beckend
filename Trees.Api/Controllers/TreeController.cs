using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trees.Api.Models.Dto.Tree;
using Trees.Core.Interfaces;
using Trees.Core.Models;

namespace Trees.Api.Controllers
{
    public class TreeController : BaseController
    {
        public TreeController(IMapper mapper, ITreeService treeService)
        {
            _mapper = mapper;
            _treeService = treeService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(TreeDto dto)
        {
            var result = _mapper.Map<Tree>(dto);

            await _treeService.CreateAsync(result);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute]Guid id, TreeDto dto)
        {
            var result = _mapper.Map<Tree>(dto, opt =>
            {
                opt.AfterMap((src, dest) => dest.Id = id);
            });

            await _treeService.UpdateAsync(result);

            return Ok();
        }

        private readonly IMapper _mapper;
        private readonly ITreeService _treeService;
    }
}
