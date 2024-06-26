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
    public class RAMService : IRAMService
    {

        private readonly SetupMasterDbContext _setupMasterDbContext;
        public RAMService(SetupMasterDbContext setupMasterDbContext)
        {
            _setupMasterDbContext = setupMasterDbContext;
        }

        public async Task<List<RAM>> GetAllRAMs()
        {
            return await _setupMasterDbContext.RAMs.ToListAsync();
        }

        public List<RAM> SortRAMs(List<RAM> RAMs, string sortBy)
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    return RAMs.OrderBy(p => p.Name).ToList();
                case "price":
                    return RAMs.OrderBy(p => p.Price).ToList();
                default:
                    return RAMs;
            }
        }

        public List<RAM> FilterRAMs(List<RAM> RAMs, string filterBy)
        {
            // switch (filterBy.ToLower())
            // {
            //     case "name":
            //         return RAMs.Where(p => p.Name == filterBy).ToList();
            //     case "price":
            //         return RAMs.Where(p => p.Price == Int32.Parse(filterBy)).ToList();
            //     case "producer":
            //         return RAMs.Where(p => p.ProducerName == filterBy).ToList();
            //     default:
            //         return RAMs;
            // }
             if(filterBy == "")
                return RAMs;
            return RAMs.Where(p => p.Price <= Int32.Parse(filterBy)).ToList();
        }

        public List<RAM> SearchRAMs(List<RAM> RAMs, string searchQuery)
        {
            // switch (searchQuery.ToLower())
            // {
            //     case "name":
            //         return RAMs.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
            //     case "price":
            //         return RAMs.Where(p => p.Price == Int32.Parse(searchQuery)).ToList();
            //     case "producer":
            //         return RAMs.Where(p => p.ProducerName.ToLower().Contains(searchQuery.ToLower())).ToList();
            //     default:
            //         return RAMs;

            // }
             if(searchQuery == "")
                return RAMs;
             return RAMs.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
        }
    }
}
