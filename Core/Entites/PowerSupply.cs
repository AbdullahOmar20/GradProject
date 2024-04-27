using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class PowerSupply : BaseEntity
    {
        public string? Type { get; set; }
        public string? Efficiency { get; set; }
        public int? Wattage { get; set; }
        public string? Modular { get; set; }
        public string? Color { get; set; }
    }
}
