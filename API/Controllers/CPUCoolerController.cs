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
    public class CPUCoolerController : ControllerBase
    {
        private readonly ICPUCoolerService _CPUCoolerService;
        public CPUCoolerController(ICPUCoolerService CPUCoolerService)
        {
            _CPUCoolerService = CPUCoolerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CPUCooler>>> GetAllCPUCoolers(int pageNumber = 1, int pageSize = 10,string sortBy ="",string filterBy="",string searchQuery="")
        {
            var CPUCoolers = await _CPUCoolerService.GetAllCPUCoolers();
            CPUCoolers =_CPUCoolerService.SortCPUCoolers(CPUCoolers, sortBy);
            CPUCoolers=_CPUCoolerService.FilterCPUCoolers(CPUCoolers, filterBy);
            CPUCoolers=_CPUCoolerService.SearchCPUCoolers(CPUCoolers, searchQuery);
            var paginatedCPUCoolers = PaginatedList<CPUCooler>.Create(CPUCoolers, pageNumber, pageSize);
            return Ok(paginatedCPUCoolers);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<CPUCooler>>> SortCPUCoolers([FromQuery] string sortBy,int pageNumber = 1, int pageSize = 10)
        {
            var CPUCoolers = await _CPUCoolerService.GetAllCPUCoolers();
            var sortedCPUCoolers = _CPUCoolerService.SortCPUCoolers(CPUCoolers, sortBy);
            var paginatedSortedCPUCoolers = PaginatedList<CPUCooler>.Create(sortedCPUCoolers, pageNumber, pageSize);
            return Ok(paginatedSortedCPUCoolers);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<CPUCooler>>> FilterCPUCoolers([FromQuery] string filterBy,int pageNumber = 1, int pageSize = 10)
        {
            var CPUCoolers = await _CPUCoolerService.GetAllCPUCoolers();
            var filteredCPUCoolers = _CPUCoolerService.FilterCPUCoolers(CPUCoolers, filterBy);
            var paginatedFilteredCPUCoolers = PaginatedList<CPUCooler>.Create(filteredCPUCoolers, pageNumber, pageSize);
            return Ok(paginatedFilteredCPUCoolers);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<CPUCooler>>> SearchCPUCoolers([FromQuery] string searchQuery,int pageNumber = 1, int pageSize = 10)
        {
            var CPUCoolers = await _CPUCoolerService.GetAllCPUCoolers();
            var searchedCPUCoolers = _CPUCoolerService.SearchCPUCoolers(CPUCoolers, searchQuery);
            var paginatedSearchedCPUCoolers = PaginatedList<CPUCooler>.Create(searchedCPUCoolers, pageNumber, pageSize);
            return Ok(paginatedSearchedCPUCoolers);
        }
    }
}

