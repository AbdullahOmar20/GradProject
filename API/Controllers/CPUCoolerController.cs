using Core.Entites;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPUCoolerController : ControllerBase
    {
        private readonly ICPUCoolerService _CPUCoolerService;
        public CPUCoolerController(ICPUCoolerService CPUCoolerService)
        {
            _CPUCoolerService = CPUCoolerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CPUCooler>>> GetAllCPUCoolers()
        {
            var CPUCoolers = await _CPUCoolerService.GetAllCPUCoolers();
            return Ok(CPUCoolers);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<CPUCooler>>> SortCPUCoolers([FromQuery] string sortBy)
        {
            var CPUCoolers = await _CPUCoolerService.GetAllCPUCoolers();
            var sortedCPUCoolers = _CPUCoolerService.SortCPUCoolers(CPUCoolers, sortBy);
            return Ok(sortedCPUCoolers);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<CPUCooler>>> FilterCPUCoolers([FromQuery] string filterBy)
        {
            var CPUCoolers = await _CPUCoolerService.GetAllCPUCoolers();
            var filteredCPUCoolers = _CPUCoolerService.FilterCPUCoolers(CPUCoolers, filterBy);
            return Ok(filteredCPUCoolers);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<CPUCooler>>> SearchCPUCoolers([FromQuery] string searchQuery)
        {
            var CPUCoolers = await _CPUCoolerService.GetAllCPUCoolers();
            var searchedCPUCoolers = _CPUCoolerService.SearchCPUCoolers(CPUCoolers, searchQuery);
            return Ok(searchedCPUCoolers);
        }
    }
}

