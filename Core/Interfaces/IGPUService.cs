using Core.Entites;
using Core.Entites.Benchmark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGPUService
    {
        public Task<List<GPU>> GetAllGPUs();
        public List<GPU> SortGPUs(List<GPU> GPUs, string sortBy);
        public List<GPU> FilterGPUs(List<GPU> GPUs, string filterBy);
        public List<GPU> SearchGPUs(List<GPU> GPUs, string searchQuery);
        public Task<GPUBenchmark> GetGPUsById(string name);
    }
}
