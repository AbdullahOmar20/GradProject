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
        public async Task<ActionResult<IEnumerable<Motherboard>>> GetAllMotherboards()
        {
            var Motherboards = await _MotherboardService.GetAllMotherboards();
            return Ok(Motherboards);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<Motherboard>>> SortMotherboards([FromQuery] string sortBy)
        {
            var Motherboards = await _MotherboardService.GetAllMotherboards();
            var sortedMotherboards = _MotherboardService.SortMotherboards(Motherboards, sortBy);
            return Ok(sortedMotherboards);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Motherboard>>> FilterMotherboards([FromQuery] string filterBy)
        {
            var Motherboards = await _MotherboardService.GetAllMotherboards();
            var filteredMotherboards = _MotherboardService.FilterMotherboards(Motherboards, filterBy);
            return Ok(filteredMotherboards);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Motherboard>>> SearchMotherboards([FromQuery] string searchQuery)
        {
            var Motherboards = await _MotherboardService.GetAllMotherboards();
            var searchedMotherboards = _MotherboardService.SearchMotherboards(Motherboards, searchQuery);
            return Ok(searchedMotherboards);
        }
    }
}

