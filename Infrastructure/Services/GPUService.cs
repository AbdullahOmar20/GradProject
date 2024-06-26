using Core.Entites;
using Core.Entites.Benchmark;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Services
{
    public class GPUService : IGPUService
    {
       
        private readonly SetupMasterDbContext _setupMasterDbContext;
        private readonly BenchmarkDbContext _benchmarkDbContext;
        public GPUService(SetupMasterDbContext setupMasterDbContext, BenchmarkDbContext benchmarkDbContext)
        {
            _setupMasterDbContext = setupMasterDbContext;
            _benchmarkDbContext = benchmarkDbContext;
        }

        public async Task<List<GPU>> GetAllGPUs()
        {
            return await _setupMasterDbContext.GPUs.ToListAsync();
        }

        public List<GPU> SortGPUs(List<GPU> GPUs, string sortBy)
        {
            if(sortBy == "")
                return GPUs;
             switch (sortBy.ToLower())
            {
                case "name":
                    return   GPUs.OrderBy(p => p.Name).ToList();
                case "price":
                    return GPUs.OrderBy(p => p.Price).ToList();
                default:
                    return GPUs;
            }
            
            
        }

        public List<GPU> FilterGPUs(List<GPU> GPUs, string filterBy)
        {
            /*switch (filterBy.ToLower())
            {
                case "name":
                    return GPUs.Where(p => p.Name==filterBy).ToList();
                case "price":
                    return GPUs.Where(p => p.Price == Int32.Parse(filterBy)).ToList();
                case "producer":
                    return GPUs.Where(p => p.ProducerName == filterBy).ToList();
                default:
                    return GPUs;
            }*/
            if(filterBy == "")
                return GPUs;
            return GPUs.Where(p => p.Price <= Int32.Parse(filterBy)).ToList();
        }

        public List<GPU> SearchGPUs(List<GPU> GPUs, string searchQuery)
        {
            /*switch (searchQuery.ToLower())
            {
                case "name":
                    return GPUs.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
                case "price":
                    return GPUs.Where(p => p.Price==Int32.Parse(searchQuery)).ToList();
                case "producer":
                    return GPUs.Where(p => p.ProducerName.ToLower().Contains(searchQuery.ToLower())).ToList();
                default:
                    return GPUs;

            }*/
            if(searchQuery == "")
                return GPUs;
             return GPUs.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
        }

        public async Task<GPUBenchmark> GetGPUsById(string name)
        {
            return await _benchmarkDbContext.GPUsbenchmark.Where(p => p.GpuName.Contains(name)).FirstAsync();
        }
    }
}
