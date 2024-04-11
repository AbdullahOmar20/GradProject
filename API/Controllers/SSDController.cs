using Core.Entites;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SSDController : ControllerBase
    {
        private readonly ISSDService _SSDService;
        public SSDController(ISSDService SSDService)
        {
            _SSDService = SSDService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SSD>>> GetAllSSDs()
        {
            var SSDs = await _SSDService.GetAllSSDs();
            return Ok(SSDs);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<SSD>>> SortSSDs([FromQuery] string sortBy)
        {
            var SSDs = await _SSDService.GetAllSSDs();
            var sortedSSDs = _SSDService.SortSSDs(SSDs, sortBy);
            return Ok(sortedSSDs);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<SSD>>> FilterSSDs([FromQuery] string filterBy)
        {
            var SSDs = await _SSDService.GetAllSSDs();
            var filteredSSDs = _SSDService.FilterSSDs(SSDs, filterBy);
            return Ok(filteredSSDs);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SSD>>> SearchSSDs([FromQuery] string searchQuery)
        {
            var SSDs = await _SSDService.GetAllSSDs();
            var searchedSSDs = _SSDService.SearchSSDs(SSDs, searchQuery);
            return Ok(searchedSSDs);
        }
    }
}

