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
        public async Task<ActionResult<IEnumerable<Case>>> GetAllCases()
        {
            var Cases = await _CaseService.GetAllCases();
            return Ok(Cases);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<Case>>> SortCases([FromQuery] string sortBy)
        {
            var Cases = await _CaseService.GetAllCases();
            var sortedCases = _CaseService.SortCases(Cases, sortBy);
            return Ok(sortedCases);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Case>>> FilterCases([FromQuery] string filterBy)
        {
            var Cases = await _CaseService.GetAllCases();
            var filteredCases = _CaseService.FilterCases(Cases, filterBy);
            return Ok(filteredCases);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Case>>> SearchCases([FromQuery] string searchQuery)
        {
            var Cases = await _CaseService.GetAllCases();
            var searchedCases = _CaseService.SearchCases(Cases, searchQuery);
            return Ok(searchedCases);
        }
    }
}

