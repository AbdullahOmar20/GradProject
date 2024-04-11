using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPowerSupplieservice
    {
        public Task<List<PowerSupply>> GetAllPowerSupplies();
        public List<PowerSupply> SortPowerSupplies(List<PowerSupply> PowerSupplies, string sortBy);
        public List<PowerSupply> FilterPowerSupplies(List<PowerSupply> PowerSupplies, string filterBy);
        public List<PowerSupply> SearchPowerSupplies(List<PowerSupply> PowerSupplies, string searchQuery);
    }
}
