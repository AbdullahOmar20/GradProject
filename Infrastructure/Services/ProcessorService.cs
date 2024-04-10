using Core.Entites;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProcessorService: IProcessorService 
    {
       
        private readonly SetupMasterDbContext _setupMasterDbContext;
        public ProcessorService(SetupMasterDbContext setupMasterDbContext)
        {
            _setupMasterDbContext = setupMasterDbContext;
        }

        public async Task<List<Processor>> GetAllProcessors()
        {
            return await _setupMasterDbContext.Processors.ToListAsync();
        }

        public List<Processor> SortProcessors(List<Processor> Processors, string sortBy)
        {
             switch (sortBy.ToLower())
            {
                case "name":
                    return   Processors.OrderBy(p => p.Name).ToList();
                case "price":
                    return Processors.OrderBy(p => p.Price).ToList();
                case "producer":
                    return Processors.OrderBy(p => p.ProducerName).ToList();
                default:
                    return Processors;
            }
        }

        public List<Processor> FilterProcessors(List<Processor> Processors, string filterBy)
        {
            switch (filterBy.ToLower())
            {
                case "name":
                    return Processors.Where(p => p.Name==filterBy).ToList();
                case "price":
                    return Processors.Where(p => p.Price == Int32.Parse(filterBy)).ToList();
                case "producer":
                    return Processors.Where(p => p.ProducerName == filterBy).ToList();
                default:
                    return Processors;
            }
        }

        public List<Processor> SearchProcessors(List<Processor> Processors, string searchQuery)
        {
            switch (searchQuery.ToLower())
            {
                case "name":
                    return Processors.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
                case "price":
                    return Processors.Where(p => p.Price==Int32.Parse(searchQuery)).ToList();
                case "producer":
                    return Processors.Where(p => p.ProducerName.ToLower().Contains(searchQuery.ToLower())).ToList();
                default:
                    return Processors;

            }
        }
    }
}
