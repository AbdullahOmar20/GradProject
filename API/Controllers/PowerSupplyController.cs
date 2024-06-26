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
    public class PowerSupplyController : ControllerBase
    {
        private readonly IPowerSupplieservice _PowerSupplieservice;
        public PowerSupplyController(IPowerSupplieservice PowerSupplieservice)
        {
            _PowerSupplieservice = PowerSupplieservice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PowerSupply>>> GetAllPowerSupplies(int pageNumber = 1, int pageSize = 10,string sortBy ="",string filterBy="",string searchQuery="")
        {
            var PowerSupplies = await _PowerSupplieservice.GetAllPowerSupplies();
            PowerSupplies =_PowerSupplieservice.SortPowerSupplies(PowerSupplies, sortBy);
            PowerSupplies=_PowerSupplieservice.FilterPowerSupplies(PowerSupplies, filterBy);
            PowerSupplies=_PowerSupplieservice.SearchPowerSupplies(PowerSupplies, searchQuery);
            var paginatedPowerSupplies = PaginatedList<PowerSupply>.Create(PowerSupplies, pageNumber, pageSize);
            return Ok(paginatedPowerSupplies);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<PowerSupply>>> SortPowerSupplies([FromQuery] string sortBy,int pageNumber = 1, int pageSize = 10)
        {
            var PowerSupplies = await _PowerSupplieservice.GetAllPowerSupplies();
            var sortedPowerSupplies = _PowerSupplieservice.SortPowerSupplies(PowerSupplies, sortBy);
            var paginatedSortedPowerSupplies = PaginatedList<PowerSupply>.Create(sortedPowerSupplies, pageNumber, pageSize);
            return Ok(paginatedSortedPowerSupplies);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<PowerSupply>>> FilterPowerSupplies([FromQuery] string filterBy,int pageNumber = 1, int pageSize = 10)
        {
            var PowerSupplies = await _PowerSupplieservice.GetAllPowerSupplies();
            var filteredPowerSupplies = _PowerSupplieservice.FilterPowerSupplies(PowerSupplies, filterBy);
            var paginatedFilteredPowerSupplies = PaginatedList<PowerSupply>.Create(filteredPowerSupplies, pageNumber, pageSize);
            return Ok(paginatedFilteredPowerSupplies);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PowerSupply>>> SearchPowerSupplies([FromQuery] string searchQuery,int pageNumber = 1, int pageSize = 10)
        {
            var PowerSupplies = await _PowerSupplieservice.GetAllPowerSupplies();
            var searchedPowerSupplies = _PowerSupplieservice.SearchPowerSupplies(PowerSupplies, searchQuery);
            var paginatedSearchedPowerSupplies = PaginatedList<PowerSupply>.Create(searchedPowerSupplies, pageNumber, pageSize);
            return Ok(paginatedSearchedPowerSupplies);
        }
    }
}

