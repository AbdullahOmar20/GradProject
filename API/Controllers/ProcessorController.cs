
using API.Helpers;
using Core.Entites;
using Core.Entites.Benchmark;
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
        public async Task<ActionResult<IEnumerable<Processor>>> GetAllProcessors(int pageNumber = 1, int pageSize = 10,string sortBy ="",string filterBy="",string searchQuery="")
        {
            var CPUs = await _processorService.GetAllProcessors();
            CPUs =_processorService.SortProcessors(CPUs, sortBy);
            CPUs=_processorService.FilterProcessors(CPUs, filterBy);
            CPUs=_processorService.SearchProcessors(CPUs, searchQuery);
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

        [HttpGet("benchmark{name}")]
        public async Task<ActionResult<CPUBenchmark>> GetProcessorById(string name)
        {
            var processor = await _processorService.GetProcessorsById(name);
            if (processor == null)
            {
                return NotFound("processor not found. Check the name");
            }
            return Ok(processor);
        }

        [HttpGet("compare{Name1},{Name2}")]
        public async Task<ActionResult<List<CPUBenchmark>>> Compareprocessors(string Name1, string Name2)
        {
            var processor1 = await _processorService.GetProcessorsById(Name1);
            var processor2 = await _processorService.GetProcessorsById(Name2);

            if (processor1 == null)
            {
                return NotFound("First processor not found. Check the name");
            }
            else if (processor2 == null)
            {
                return NotFound("Second processor not found. check the name");
            }

            var comparisonResult = new List<CPUBenchmark>()
            {
                processor1,processor2
            };
            

            return Ok(comparisonResult);
        }
    }
}

