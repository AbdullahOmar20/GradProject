using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICPUCoolerService
    {
        public Task<List<CPUCooler>> GetAllCPUCoolers();
        public List<CPUCooler> SortCPUCoolers(List<CPUCooler> CPUCoolers, string sortBy);
        public List<CPUCooler> FilterCPUCoolers(List<CPUCooler> CPUCoolers, string filterBy);
        public List<CPUCooler> SearchCPUCoolers(List<CPUCooler> CPUCoolers, string searchQuery);

    }
}
