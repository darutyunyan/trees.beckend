using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trees.Api.Models.Dto.Log;
using Trees.Core.Interfaces;

namespace Trees.Api.Controllers
{
    public class LogController : BaseController
    {
        public LogController(IMapper mapper, ILogService logService)
        {
            _mapper = mapper;
            _logService = logService;
        }

        [HttpPost]
        [Route("GetLogs")]
        public async Task<ActionResult<LogResultDto[]>> GetLogs(LogDto dto)
        {
            var logs = await _logService.GetTopAsync(dto.Count);

            var result = _mapper.Map<List<LogResultDto>>(logs);

            return Ok(result.ToArray());
        }

        private readonly IMapper _mapper;
        private readonly ILogService _logService;
    }
}
