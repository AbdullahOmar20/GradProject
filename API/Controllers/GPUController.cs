using API.Helpers;
using Core.Entites;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPUController : ControllerBase
    {
        private readonly IGPUService _GPUService;
        public GPUController(IGPUService GPUService)
        {
            _GPUService = GPUService ?? throw new ArgumentNullException(nameof(GPUService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GPU>>> GetAllGPUs(int pageNumber = 1, int pageSize = 10)
        {
            var GPUs = await _GPUService.GetAllGPUs();
            var paginatedGPUs = PaginatedList<GPU>.Create(GPUs, pageNumber, pageSize);
            return Ok(paginatedGPUs);
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<GPU>>> SortGPUs([FromQuery] string sortBy, int pageNumber = 1, int pageSize = 10)
        {
            var GPUs = await _GPUService.GetAllGPUs();
            var sortedGPUs = _GPUService.SortGPUs(GPUs, sortBy);
            var paginatedSortedGPUs = PaginatedList<GPU>.Create(sortedGPUs, pageNumber, pageSize);
            return Ok(paginatedSortedGPUs);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<GPU>>> FilterGPUs([FromQuery] string filterBy, int pageNumber = 1, int pageSize = 10)
        {
            var GPUs = await _GPUService.GetAllGPUs();
            var filteredGPUs = _GPUService.FilterGPUs(GPUs, filterBy);
            var paginatedFilteredGPUs = PaginatedList<GPU>.Create(filteredGPUs, pageNumber, pageSize);
            return Ok(paginatedFilteredGPUs);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<GPU>>> SearchGPUs([FromQuery] string searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            var GPUs = await _GPUService.GetAllGPUs();
            var searchedGPUs = _GPUService.SearchGPUs(GPUs, searchQuery);
            var paginatedSearchedGPUs = PaginatedList<GPU>.Create(searchedGPUs, pageNumber, pageSize);
            return Ok(paginatedSearchedGPUs);
        }
    }
}
