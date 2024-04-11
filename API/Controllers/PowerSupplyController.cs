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
        public async Task<ActionResult<IEnumerable<PowerSupply>>> GetAllPowerSupplies()
        {
            var PowerSupplies = await _PowerSupplieservice.GetAllPowerSupplies();
            return Ok(PowerSupplies);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<PowerSupply>>> SortPowerSupplies([FromQuery] string sortBy)
        {
            var PowerSupplies = await _PowerSupplieservice.GetAllPowerSupplies();
            var sortedPowerSupplies = _PowerSupplieservice.SortPowerSupplies(PowerSupplies, sortBy);
            return Ok(sortedPowerSupplies);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<PowerSupply>>> FilterPowerSupplies([FromQuery] string filterBy)
        {
            var PowerSupplies = await _PowerSupplieservice.GetAllPowerSupplies();
            var filteredPowerSupplies = _PowerSupplieservice.FilterPowerSupplies(PowerSupplies, filterBy);
            return Ok(filteredPowerSupplies);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PowerSupply>>> SearchPowerSupplies([FromQuery] string searchQuery)
        {
            var PowerSupplies = await _PowerSupplieservice.GetAllPowerSupplies();
            var searchedPowerSupplies = _PowerSupplieservice.SearchPowerSupplies(PowerSupplies, searchQuery);
            return Ok(searchedPowerSupplies);
        }
    }
}

