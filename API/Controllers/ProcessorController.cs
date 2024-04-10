using Core.Entites;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IEnumerable<Processor>>> GetAllProcessors()
        {
            var processors = await _processorService.GetAllProcessors();
            return Ok(processors);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<Processor>>> SortProcessors([FromQuery] string sortBy)
        {
            var processors =  await _processorService.GetAllProcessors();
            var sortedProcessors = _processorService.SortProcessors(processors, sortBy);
            return Ok(sortedProcessors);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Processor>>> FilterProcessors([FromQuery] string filterBy)
        {
            var processors = await _processorService.GetAllProcessors();
            var filteredProcessors = _processorService.FilterProcessors(processors, filterBy);
            return Ok(filteredProcessors);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Processor>>> SearchProcessors([FromQuery] string searchQuery)
        {
            var processors = await _processorService.GetAllProcessors();
            var searchedProcessors = _processorService.SearchProcessors(processors, searchQuery);
            return Ok(searchedProcessors);
        }
    }
}

