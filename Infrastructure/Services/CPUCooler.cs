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
    public class CPUCoolerService : ICPUCoolerService
    {

        private readonly SetupMasterDbContext _setupMasterDbContext;
        public CPUCoolerService(SetupMasterDbContext setupMasterDbContext)
        {
            _setupMasterDbContext = setupMasterDbContext;
        }

        public async Task<List<CPUCooler>> GetAllCPUCoolers()
        {
            return await _setupMasterDbContext.CPUCoolers.ToListAsync();
        }

        public List<CPUCooler> SortCPUCoolers(List<CPUCooler> CPUCoolers, string sortBy)
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    return CPUCoolers.OrderBy(p => p.Name).ToList();
                case "price":
                    return CPUCoolers.OrderBy(p => p.Price).ToList();
                case "producer":
                    return CPUCoolers.OrderBy(p => p.ProducerName).ToList();
                default:
                    return CPUCoolers;
            }
        }

        public List<CPUCooler> FilterCPUCoolers(List<CPUCooler> CPUCoolers, string filterBy)
        {
            switch (filterBy.ToLower())
            {
                case "name":
                    return CPUCoolers.Where(p => p.Name == filterBy).ToList();
                case "price":
                    return CPUCoolers.Where(p => p.Price == Int32.Parse(filterBy)).ToList();
                case "producer":
                    return CPUCoolers.Where(p => p.ProducerName == filterBy).ToList();
                default:
                    return CPUCoolers;
            }
        }

        public List<CPUCooler> SearchCPUCoolers(List<CPUCooler> CPUCoolers, string searchQuery)
        {
            switch (searchQuery.ToLower())
            {
                case "name":
                    return CPUCoolers.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
                case "price":
                    return CPUCoolers.Where(p => p.Price == Int32.Parse(searchQuery)).ToList();
                case "producer":
                    return CPUCoolers.Where(p => p.ProducerName.ToLower().Contains(searchQuery.ToLower())).ToList();
                default:
                    return CPUCoolers;

            }
        }
    }
}
