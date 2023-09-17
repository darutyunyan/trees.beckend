using Microsoft.AspNetCore.Mvc;

namespace Trees.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [HttpGet]
        [Route("status")]
        public string Status()
        {
            return "Service works!";
        }
    }
}
