using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISSDService
    {
        public Task<List<SSD>> GetAllSSDs();
        public List<SSD> SortSSDs(List<SSD> SSDs, string sortBy);
        public List<SSD> FilterSSDs(List<SSD> SSDs, string filterBy);
        public List<SSD> SearchSSDs(List<SSD> SSDs, string searchQuery);
    }
}
