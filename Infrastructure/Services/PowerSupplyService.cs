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
    public class PowerSupplieservice : IPowerSupplieservice
    {

        private readonly SetupMasterDbContext _setupMasterDbContext;
        public PowerSupplieservice(SetupMasterDbContext setupMasterDbContext)
        {
            _setupMasterDbContext = setupMasterDbContext;
        }

        public async Task<List<PowerSupply>> GetAllPowerSupplies()
        {
            return await _setupMasterDbContext.PowerSupplies.ToListAsync();
        }

        public List<PowerSupply> SortPowerSupplies(List<PowerSupply> PowerSupplies, string sortBy)
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    return PowerSupplies.OrderBy(p => p.Name).ToList();
                case "price":
                    return PowerSupplies.OrderBy(p => p.Price).ToList();
                default:
                    return PowerSupplies;
            }
        }

        public List<PowerSupply> FilterPowerSupplies(List<PowerSupply> PowerSupplies, string filterBy)
        {
            // switch (filterBy.ToLower())
            // {
            //     case "name":
            //         return PowerSupplies.Where(p => p.Name == filterBy).ToList();
            //     case "price":
            //         return PowerSupplies.Where(p => p.Price == Int32.Parse(filterBy)).ToList();
            //     case "producer":
            //         return PowerSupplies.Where(p => p.ProducerName == filterBy).ToList();
            //     default:
            //         return PowerSupplies;
            // }
            if(filterBy == "")
                return PowerSupplies;
            return PowerSupplies.Where(p => p.Price <= Int32.Parse(filterBy)).ToList();
        }

        public List<PowerSupply> SearchPowerSupplies(List<PowerSupply> PowerSupplies, string searchQuery)
        {
            // switch (searchQuery.ToLower())
            // {
            //     case "name":
            //         return PowerSupplies.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
            //     case "price":
            //         return PowerSupplies.Where(p => p.Price == Int32.Parse(searchQuery)).ToList();
            //     case "producer":
            //         return PowerSupplies.Where(p => p.ProducerName.ToLower().Contains(searchQuery.ToLower())).ToList();
            //     default:
            //         return PowerSupplies;

            // }
            if(searchQuery == "")
                return PowerSupplies;
             return PowerSupplies.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
        }
    }
}
