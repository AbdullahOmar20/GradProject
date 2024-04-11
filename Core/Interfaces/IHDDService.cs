using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IHDDService
    {
        public Task<List<HDD>> GetAllHDDs();
        public List<HDD> SortHDDs(List<HDD> HDDs, string sortBy);
        public List<HDD> FilterHDDs(List<HDD> HDDs, string filterBy);
        public List<HDD> SearchHDDs(List<HDD> HDDs, string searchQuery);
    }
}
