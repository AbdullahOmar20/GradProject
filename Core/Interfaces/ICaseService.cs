using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICaseService
    {
        public Task<List<Case>> GetAllCases();
        public List<Case> SortCases(List<Case> Cases, string sortBy);
        public List<Case> FilterCases(List<Case> Cases, string filterBy);
        public List<Case> SearchCases(List<Case> Cases, string searchQuery);
    }
}
