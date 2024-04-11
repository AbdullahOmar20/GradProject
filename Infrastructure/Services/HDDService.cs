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
    public class HDDService : IHDDService
    {

        private readonly SetupMasterDbContext _setupMasterDbContext;
        public HDDService(SetupMasterDbContext setupMasterDbContext)
        {
            _setupMasterDbContext = setupMasterDbContext;
        }

        public async Task<List<HDD>> GetAllHDDs()
        {
            return await _setupMasterDbContext.HDDs.ToListAsync();
        }

        public List<HDD> SortHDDs(List<HDD> HDDs, string sortBy)
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    return HDDs.OrderBy(p => p.Name).ToList();
                case "price":
                    return HDDs.OrderBy(p => p.Price).ToList();
                case "producer":
                    return HDDs.OrderBy(p => p.ProducerName).ToList();
                default:
                    return HDDs;
            }
        }

        public List<HDD> FilterHDDs(List<HDD> HDDs, string filterBy)
        {
            switch (filterBy.ToLower())
            {
                case "name":
                    return HDDs.Where(p => p.Name == filterBy).ToList();
                case "price":
                    return HDDs.Where(p => p.Price == Int32.Parse(filterBy)).ToList();
                case "producer":
                    return HDDs.Where(p => p.ProducerName == filterBy).ToList();
                default:
                    return HDDs;
            }
        }

        public List<HDD> SearchHDDs(List<HDD> HDDs, string searchQuery)
        {
            switch (searchQuery.ToLower())
            {
                case "name":
                    return HDDs.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
                case "price":
                    return HDDs.Where(p => p.Price == Int32.Parse(searchQuery)).ToList();
                case "producer":
                    return HDDs.Where(p => p.ProducerName.ToLower().Contains(searchQuery.ToLower())).ToList();
                default:
                    return HDDs;

            }
        }
    }
}
