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
    public class SSDController : ControllerBase
    {
        private readonly ISSDService _SSDService;
        public SSDController(ISSDService SSDService)
        {
            _SSDService = SSDService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SSD>>> GetAllSSDs(int pageNumber = 1, int pageSize = 10)
        {
            var SSDs = await _SSDService.GetAllSSDs();
            var paginatedSSDs = PaginatedList<SSD>.Create(SSDs, pageNumber, pageSize);
            return Ok(paginatedSSDs);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<SSD>>> SortSSDs([FromQuery] string sortBy,int pageNumber = 1, int pageSize = 10)
        {
            var SSDs = await _SSDService.GetAllSSDs();
            var sortedSSDs = _SSDService.SortSSDs(SSDs, sortBy);
            var paginatedSortedSSDs = PaginatedList<SSD>.Create(sortedSSDs, pageNumber, pageSize);
            return Ok(paginatedSortedSSDs);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<SSD>>> FilterSSDs([FromQuery] string filterBy,int pageNumber = 1, int pageSize = 10)
        {
            var SSDs = await _SSDService.GetAllSSDs();
            var filteredSSDs = _SSDService.FilterSSDs(SSDs, filterBy);
            var paginatedFilteredSSDs = PaginatedList<SSD>.Create(filteredSSDs, pageNumber, pageSize);
            return Ok(paginatedFilteredSSDs);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SSD>>> SearchSSDs([FromQuery] string searchQuery,int pageNumber = 1, int pageSize = 10)
        {
            var SSDs = await _SSDService.GetAllSSDs();
            var searchedSSDs = _SSDService.SearchSSDs(SSDs, searchQuery);
            var paginatedSearchedSSDs = PaginatedList<SSD>.Create(searchedSSDs, pageNumber, pageSize);
            return Ok(paginatedSearchedSSDs);
        }
    }
}

