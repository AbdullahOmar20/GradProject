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
    public class MotherboardController : ControllerBase
    {
        private readonly IMotherboardService _MotherboardService;
        public MotherboardController(IMotherboardService MotherboardService)
        {
            _MotherboardService = MotherboardService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motherboard>>> GetAllMotherboards(int pageNumber = 1, int pageSize = 10)
        {
            var Motherboards = await _MotherboardService.GetAllMotherboards();
            var paginatedMotherboards = PaginatedList<Motherboard>.Create(Motherboards, pageNumber, pageSize);
            return Ok(paginatedMotherboards);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<Motherboard>>> SortMotherboards([FromQuery] string sortBy,int pageNumber = 1, int pageSize = 10)
        {
            var Motherboards = await _MotherboardService.GetAllMotherboards();
            var sortedMotherboards = _MotherboardService.SortMotherboards(Motherboards, sortBy);
            var paginatedSortedMotherboards = PaginatedList<Motherboard>.Create(sortedMotherboards, pageNumber, pageSize);
            return Ok(paginatedSortedMotherboards);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Motherboard>>> FilterMotherboards([FromQuery] string filterBy,int pageNumber = 1, int pageSize = 10)
        {
            var Motherboards = await _MotherboardService.GetAllMotherboards();
            var filteredMotherboards = _MotherboardService.FilterMotherboards(Motherboards, filterBy);
            var paginatedFilteredMotherboards = PaginatedList<Motherboard>.Create(filteredMotherboards, pageNumber, pageSize);
            return Ok(paginatedFilteredMotherboards);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Motherboard>>> SearchMotherboards([FromQuery] string searchQuery,int pageNumber = 1, int pageSize = 10)
        {
            var Motherboards = await _MotherboardService.GetAllMotherboards();
            var searchedMotherboards = _MotherboardService.SearchMotherboards(Motherboards, searchQuery);
            var paginatedSearchedMotherboards = PaginatedList<Motherboard>.Create(searchedMotherboards, pageNumber, pageSize);
            return Ok(paginatedSearchedMotherboards);
        }
    }
}

