
using API.Helpers;
using Core.Entites;
using Core.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessorController : ControllerBase
    {
        private readonly IProcessorService _processorService;
        public ProcessorController(IProcessorService processorService)
        {
            _processorService= processorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Processor>>> GetAllProcessors(int pageNumber = 1, int pageSize = 10)
        {
            var CPUs = await _processorService.GetAllProcessors();
            var paginatedCPUs = PaginatedList<Processor>.Create(CPUs, pageNumber, pageSize);
            return Ok(paginatedCPUs);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<Processor>>> SortProcessors([FromQuery] string sortBy,int pageNumber = 1, int pageSize = 10)
        {
            var CPUs = await _processorService.GetAllProcessors();
            var sortedCPUs = _processorService.SortProcessors(CPUs, sortBy);
            var paginatedSortedCPUs = PaginatedList<Processor>.Create(sortedCPUs, pageNumber, pageSize);
            return Ok(paginatedSortedCPUs);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Processor>>> FilterProcessors([FromQuery] string filterBy,int pageNumber = 1, int pageSize = 10)
        {
            var CPUs = await _processorService.GetAllProcessors();
            var filteredCPUs = _processorService.FilterProcessors(CPUs, filterBy);
            var paginatedFilteredCPUs = PaginatedList<Processor>.Create(filteredCPUs, pageNumber, pageSize);
            return Ok(paginatedFilteredCPUs);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Processor>>> SearchProcessors([FromQuery] string searchQuery,int pageNumber = 1, int pageSize = 10)
        {
            var CPUs = await _processorService.GetAllProcessors();
            var searchedCPUs = _processorService.SearchProcessors(CPUs, searchQuery);
            var paginatedSearchedCPUs = PaginatedList<Processor>.Create(searchedCPUs, pageNumber, pageSize);
            return Ok(paginatedSearchedCPUs);
        }
    }
}

