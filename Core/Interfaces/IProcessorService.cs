using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;

namespace Core.Interfaces
{
    public interface IProcessorService
    {
        public  Task<List<Processor>> GetAllProcessors();
        public List<Processor> SortProcessors(List<Processor> Processors, string sortBy);
        public List<Processor> FilterProcessors(List<Processor> Processors, string filterBy);
        public List<Processor> SearchProcessors(List<Processor> Processors, string searchQuery);
    }
}