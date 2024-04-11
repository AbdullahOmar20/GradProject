using Core.Entites;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RAMController : ControllerBase
    {
        private readonly IRAMService _RAMService;
        public RAMController(IRAMService RAMService)
        {
            _RAMService = RAMService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RAM>>> GetAllRAMs()
        {
            var RAMs = await _RAMService.GetAllRAMs();
            return Ok(RAMs);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<RAM>>> SortRAMs([FromQuery] string sortBy)
        {
            var RAMs = await _RAMService.GetAllRAMs();
            var sortedRAMs = _RAMService.SortRAMs(RAMs, sortBy);
            return Ok(sortedRAMs);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<RAM>>> FilterRAMs([FromQuery] string filterBy)
        {
            var RAMs = await _RAMService.GetAllRAMs();
            var filteredRAMs = _RAMService.FilterRAMs(RAMs, filterBy);
            return Ok(filteredRAMs);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<RAM>>> SearchRAMs([FromQuery] string searchQuery)
        {
            var RAMs = await _RAMService.GetAllRAMs();
            var searchedRAMs = _RAMService.SearchRAMs(RAMs, searchQuery);
            return Ok(searchedRAMs);
        }
    }
}

