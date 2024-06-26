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
    public class HDDController : ControllerBase
    {
        private readonly IHDDService _HDDService;
        public HDDController(IHDDService HDDService)
        {
            _HDDService = HDDService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HDD>>> GetAllHDDs(int pageNumber = 1, int pageSize = 10,string sortBy ="",string filterBy="",string searchQuery="")
        {
            var HDDs = await _HDDService.GetAllHDDs();
            HDDs =_HDDService.SortHDDs(HDDs, sortBy);
            HDDs=_HDDService.FilterHDDs(HDDs, filterBy);
            HDDs=_HDDService.SearchHDDs(HDDs, searchQuery);
            var paginatedHDDs = PaginatedList<HDD>.Create(HDDs, pageNumber, pageSize);
            return Ok(paginatedHDDs);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<HDD>>> SortHDDs([FromQuery] string sortBy,int pageNumber = 1, int pageSize = 10)
        {
            var HDDs = await _HDDService.GetAllHDDs();
            var sortedHDDs = _HDDService.SortHDDs(HDDs, sortBy);
            var paginatedSortedHDDs = PaginatedList<HDD>.Create(sortedHDDs, pageNumber, pageSize);
            return Ok(paginatedSortedHDDs);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<HDD>>> FilterHDDs([FromQuery] string filterBy,int pageNumber = 1, int pageSize = 10)
        {
            var HDDs = await _HDDService.GetAllHDDs();
            var filteredHDDs = _HDDService.FilterHDDs(HDDs, filterBy);
            var paginatedFilteredHDDs = PaginatedList<HDD>.Create(filteredHDDs, pageNumber, pageSize);
            return Ok(paginatedFilteredHDDs);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<HDD>>> SearchHDDs([FromQuery] string searchQuery,int pageNumber = 1, int pageSize = 10)
        {
            var HDDs = await _HDDService.GetAllHDDs();
            var searchedHDDs = _HDDService.SearchHDDs(HDDs, searchQuery);
            var paginatedSearchedHDDs = PaginatedList<HDD>.Create(searchedHDDs, pageNumber, pageSize);
            return Ok(paginatedSearchedHDDs);
        }
    }
}

