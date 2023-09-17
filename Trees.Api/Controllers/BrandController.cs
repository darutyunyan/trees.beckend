using Microsoft.AspNetCore.Mvc;
using Trees.Core.Entities;
using Trees.Core.Interfaces;

namespace Trees.Api.Controllers
{
    public class BrandController : BaseController
    {
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<Brand[]>> Get()
        {
            return Ok((await _brandService.GetAllAsync()).ToArray());
        }

        private readonly IBrandService _brandService;
    }
}
