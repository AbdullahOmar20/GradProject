using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class CPUCooler : BaseEntity
    {
        public string? Rpm { get; set; }
        public string? Noise_Level { get; set; }
        public string? Color { get; set; }
        public int? Size { get; set; }
    }
}
