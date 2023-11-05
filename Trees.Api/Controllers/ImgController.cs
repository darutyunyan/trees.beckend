using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trees.Api.Models.Dto.Img;
using Trees.Api.Services.FileManagement;
using Trees.Core.Interfaces;
using Trees.Core.Models;

namespace Trees.Api.Controllers
{
    public class ImgController : BaseController
    {
        public ImgController(IMapper mapper, IImgService imgService, IFileManagementService fileManagementService)
        {
            _mapper = mapper;
            _imgService = imgService;
            _fileManagementService = fileManagementService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(ImgDto dto)
        {
            string path = await _fileManagementService.Create(dto.Name, dto.Data, FileType.Img);

            var result = _mapper.Map<Img>(dto, opt =>
            {
                opt.AfterMap((src, dest) => dest.Path = path);
            });

            await _imgService.CreateAsync(result);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ImgResultDto[]>> Get()
        {
            var imgs = await _imgService.GetAllAsync();

            var result = _mapper.Map<List<ImgResultDto>>(imgs);

            return Ok(result.ToArray());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            Guid idImg = Guid.Parse(id);

            Img? currentImg = await _imgService.GetAsync(idImg);

            if (currentImg == null)
                throw new ArgumentException(nameof(currentImg)); // TODO

            _fileManagementService.Delete(currentImg.Name, FileType.Img);

            await _imgService.DeleteAsync(idImg);

            return Ok();
        }

        private readonly IMapper _mapper;
        private readonly IImgService _imgService;
        private readonly IFileManagementService _fileManagementService;
    }
}
