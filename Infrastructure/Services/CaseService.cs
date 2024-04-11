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
    public class CaseService : ICaseService
    {

        private readonly SetupMasterDbContext _setupMasterDbContext;
        public CaseService(SetupMasterDbContext setupMasterDbContext)
        {
            _setupMasterDbContext = setupMasterDbContext;
        }

        public async Task<List<Case>> GetAllCases()
        {
            return await _setupMasterDbContext.Cases.ToListAsync();
        }

        public List<Case> SortCases(List<Case> Cases, string sortBy)
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    return Cases.OrderBy(p => p.Name).ToList();
                case "price":
                    return Cases.OrderBy(p => p.Price).ToList();
                case "producer":
                    return Cases.OrderBy(p => p.ProducerName).ToList();
                default:
                    return Cases;
            }
        }

        public List<Case> FilterCases(List<Case> Cases, string filterBy)
        {
            switch (filterBy.ToLower())
            {
                case "name":
                    return Cases.Where(p => p.Name == filterBy).ToList();
                case "price":
                    return Cases.Where(p => p.Price == Int32.Parse(filterBy)).ToList();
                case "producer":
                    return Cases.Where(p => p.ProducerName == filterBy).ToList();
                default:
                    return Cases;
            }
        }

        public List<Case> SearchCases(List<Case> Cases, string searchQuery)
        {
            switch (searchQuery.ToLower())
            {
                case "name":
                    return Cases.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
                case "price":
                    return Cases.Where(p => p.Price == Int32.Parse(searchQuery)).ToList();
                case "producer":
                    return Cases.Where(p => p.ProducerName.ToLower().Contains(searchQuery.ToLower())).ToList();
                default:
                    return Cases;

            }
        }
    }
}
