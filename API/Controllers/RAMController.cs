using API.Helpers;
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
        public async Task<ActionResult<IEnumerable<RAM>>> GetAllRAMs(int pageNumber = 1, int pageSize = 10)
        {
            var RAMs = await _RAMService.GetAllRAMs();
            var paginatedRAMs = PaginatedList<RAM>.Create(RAMs, pageNumber, pageSize);
            return Ok(paginatedRAMs);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<RAM>>> SortRAMs([FromQuery] string sortBy, int  pageNumber = 1, int pageSize = 10)
        {
            var RAMs = await _RAMService.GetAllRAMs();
            var sortedRAMs = _RAMService.SortRAMs(RAMs, sortBy);
            var paginatedSortedRAMs = PaginatedList<RAM>.Create(sortedRAMs, pageNumber, pageSize);
            return Ok(paginatedSortedRAMs);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<RAM>>> FilterRAMs([FromQuery] string filterBy,int pageNumber = 1, int pageSize = 10)
        {
            var RAMs = await _RAMService.GetAllRAMs();
            var filteredRAMs = _RAMService.FilterRAMs(RAMs, filterBy);
            var paginatedFilteredRAMs = PaginatedList<RAM>.Create(filteredRAMs, pageNumber, pageSize);
            return Ok(paginatedFilteredRAMs);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<RAM>>> SearchRAMs([FromQuery] string searchQuery,int pageNumber = 1, int pageSize = 10)
        {
            var RAMs = await _RAMService.GetAllRAMs();
            var searchedRAMs = _RAMService.SearchRAMs(RAMs, searchQuery);
            var paginatedSearchedRAMs = PaginatedList<RAM>.Create(searchedRAMs, pageNumber, pageSize);
            return Ok(paginatedSearchedRAMs);
        }
    }
}

