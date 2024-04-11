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
    public class MotherboardService : IMotherboardService
    {

        private readonly SetupMasterDbContext _setupMasterDbContext;
        public MotherboardService(SetupMasterDbContext setupMasterDbContext)
        {
            _setupMasterDbContext = setupMasterDbContext;
        }

        public async Task<List<Motherboard>> GetAllMotherboards()
        {
            return await _setupMasterDbContext.motherboards.ToListAsync();
        }

        public List<Motherboard> SortMotherboards(List<Motherboard> Motherboards, string sortBy)
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    return Motherboards.OrderBy(p => p.Name).ToList();
                case "price":
                    return Motherboards.OrderBy(p => p.Price).ToList();
                case "producer":
                    return Motherboards.OrderBy(p => p.ProducerName).ToList();
                default:
                    return Motherboards;
            }
        }

        public List<Motherboard> FilterMotherboards(List<Motherboard> Motherboards, string filterBy)
        {
            switch (filterBy.ToLower())
            {
                case "name":
                    return Motherboards.Where(p => p.Name == filterBy).ToList();
                case "price":
                    return Motherboards.Where(p => p.Price == Int32.Parse(filterBy)).ToList();
                case "producer":
                    return Motherboards.Where(p => p.ProducerName == filterBy).ToList();
                default:
                    return Motherboards;
            }
        }

        public List<Motherboard> SearchMotherboards(List<Motherboard> Motherboards, string searchQuery)
        {
            switch (searchQuery.ToLower())
            {
                case "name":
                    return Motherboards.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
                case "price":
                    return Motherboards.Where(p => p.Price == Int32.Parse(searchQuery)).ToList();
                case "producer":
                    return Motherboards.Where(p => p.ProducerName.ToLower().Contains(searchQuery.ToLower())).ToList();
                default:
                    return Motherboards;

            }
        }
    }
}
