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
    public class CaseController : ControllerBase
    {
        private readonly ICaseService _CaseService;
        public CaseController(ICaseService CaseService)
        {
            _CaseService = CaseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Case>>> GetAllCases(int pageNumber = 1, int pageSize = 10,string sortBy ="",string filterBy="",string searchQuery="")
        {
            var Cases = await _CaseService.GetAllCases();
            Cases =_CaseService.SortCases(Cases, sortBy);
            Cases=_CaseService.FilterCases(Cases, filterBy);
            Cases=_CaseService.SearchCases(Cases, searchQuery);
            var paginatedCases = PaginatedList<Case>.Create(Cases, pageNumber, pageSize);
            return Ok(paginatedCases);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<Case>>> SortCases([FromQuery] string sortBy,int pageNumber = 1, int pageSize = 10)
        {
            var Cases = await _CaseService.GetAllCases();
            var sortedCases = _CaseService.SortCases(Cases, sortBy);
            var paginatedSortedCases = PaginatedList<Case>.Create(sortedCases, pageNumber, pageSize);
            return Ok(paginatedSortedCases);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Case>>> FilterCases([FromQuery] string filterBy,int pageNumber = 1, int pageSize = 10)
        {
            var Cases = await _CaseService.GetAllCases();
            var filteredCases = _CaseService.FilterCases(Cases, filterBy);
            var paginatedFilteredCases = PaginatedList<Case>.Create(filteredCases, pageNumber, pageSize);
            return Ok(paginatedFilteredCases);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Case>>> SearchCases([FromQuery] string searchQuery,int pageNumber = 1, int pageSize = 10)
        {
            var Cases = await _CaseService.GetAllCases();
            var searchedCases = _CaseService.SearchCases(Cases, searchQuery);
            var paginatedSearchedCases = PaginatedList<Case>.Create(searchedCases, pageNumber, pageSize);
            return Ok(paginatedSearchedCases);
        }
    }
}

