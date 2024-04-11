using Core.Entites;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HDDController : ControllerBase
    {
        private readonly IHDDService _HDDService;
        public HDDController(IHDDService HDDService)
        {
            _HDDService = HDDService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HDD>>> GetAllHDDs()
        {
            var HDDs = await _HDDService.GetAllHDDs();
            return Ok(HDDs);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<HDD>>> SortHDDs([FromQuery] string sortBy)
        {
            var HDDs = await _HDDService.GetAllHDDs();
            var sortedHDDs = _HDDService.SortHDDs(HDDs, sortBy);
            return Ok(sortedHDDs);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<HDD>>> FilterHDDs([FromQuery] string filterBy)
        {
            var HDDs = await _HDDService.GetAllHDDs();
            var filteredHDDs = _HDDService.FilterHDDs(HDDs, filterBy);
            return Ok(filteredHDDs);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<HDD>>> SearchHDDs([FromQuery] string searchQuery)
        {
            var HDDs = await _HDDService.GetAllHDDs();
            var searchedHDDs = _HDDService.SearchHDDs(HDDs, searchQuery);
            return Ok(searchedHDDs);
        }
    }
}

