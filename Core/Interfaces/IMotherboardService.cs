using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMotherboardService
    {
        public Task<List<Motherboard>> GetAllMotherboards();
        public List<Motherboard> SortMotherboards(List<Motherboard> Motherboards, string sortBy);
        public List<Motherboard> FilterMotherboards(List<Motherboard> Motherboards, string filterBy);
        public List<Motherboard> SearchMotherboards(List<Motherboard> Motherboards, string searchQuery);
    }
}
