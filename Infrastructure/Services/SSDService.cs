using Core.Entites;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services
{
    public class SSDService : ISSDService
    {

        private readonly SetupMasterDbContext _setupMasterDbContext;
        public SSDService(SetupMasterDbContext setupMasterDbContext)
        {
            _setupMasterDbContext = setupMasterDbContext;
        }

        public async Task<List<SSD>> GetAllSSDs()
        {
            return await _setupMasterDbContext.SSDs.ToListAsync();
        }

        public List<SSD> SortSSDs(List<SSD> SSDs, string sortBy)
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    return SSDs.OrderBy(p => p.Name).ToList();
                case "price":
                    return SSDs.OrderBy(p => p.Price).ToList();
                case "producer":
                    return SSDs.OrderBy(p => p.ProducerName).ToList();
                default:
                    return SSDs;
            }
        }

        public List<SSD> FilterSSDs(List<SSD> SSDs, string filterBy)
        {
            switch (filterBy.ToLower())
            {
                case "name":
                    return SSDs.Where(p => p.Name == filterBy).ToList();
                case "price":
                    return SSDs.Where(p => p.Price == Int32.Parse(filterBy)).ToList();
                case "producer":
                    return SSDs.Where(p => p.ProducerName == filterBy).ToList();
                default:
                    return SSDs;
            }
        }

        public List<SSD> SearchSSDs(List<SSD> SSDs, string searchQuery)
        {
            switch (searchQuery.ToLower())
            {
                case "name":
                    return SSDs.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
                case "price":
                    return SSDs.Where(p => p.Price == Int32.Parse(searchQuery)).ToList();
                case "producer":
                    return SSDs.Where(p => p.ProducerName.ToLower().Contains(searchQuery.ToLower())).ToList();
                default:
                    return SSDs;

            }
        }
    }
}
