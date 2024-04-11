using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRAMService
    {
        public Task<List<RAM>> GetAllRAMs();
        public List<RAM> SortRAMs(List<RAM> RAMs, string sortBy);
        public List<RAM> FilterRAMs(List<RAM> RAMs, string filterBy);
        public List<RAM> SearchRAMs(List<RAM> RAMs, string searchQuery);
    }
}
