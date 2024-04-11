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
    public class GPUService : IGPUService
    {
       
        private readonly SetupMasterDbContext _setupMasterDbContext;
        public GPUService(SetupMasterDbContext setupMasterDbContext)
        {
            _setupMasterDbContext = setupMasterDbContext;
        }

        public async Task<List<GPU>> GetAllGPUs()
        {
            return await _setupMasterDbContext.GPUs.ToListAsync();
        }

        public List<GPU> SortGPUs(List<GPU> GPUs, string sortBy)
        {
             switch (sortBy.ToLower())
            {
                case "name":
                    return   GPUs.OrderBy(p => p.Name).ToList();
                case "price":
                    return GPUs.OrderBy(p => p.Price).ToList();
                case "producer":
                    return GPUs.OrderBy(p => p.ProducerName).ToList();
                default:
                    return GPUs;
            }
        }

        public List<GPU> FilterGPUs(List<GPU> GPUs, string filterBy)
        {
            switch (filterBy.ToLower())
            {
                case "name":
                    return GPUs.Where(p => p.Name==filterBy).ToList();
                case "price":
                    return GPUs.Where(p => p.Price == Int32.Parse(filterBy)).ToList();
                case "producer":
                    return GPUs.Where(p => p.ProducerName == filterBy).ToList();
                default:
                    return GPUs;
            }
        }

        public List<GPU> SearchGPUs(List<GPU> GPUs, string searchQuery)
        {
            switch (searchQuery.ToLower())
            {
                case "name":
                    return GPUs.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
                case "price":
                    return GPUs.Where(p => p.Price==Int32.Parse(searchQuery)).ToList();
                case "producer":
                    return GPUs.Where(p => p.ProducerName.ToLower().Contains(searchQuery.ToLower())).ToList();
                default:
                    return GPUs;

            }
        }
    }
}
