using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class Motherboard : BaseEntity
    {
       public string Socket { get; set; }
       public string ChipSet { get; set; }
       public string FormFactor { get; set; }
       public string MemoryType { get; set; }
       public string MemoryCapacity { get; set; }
       public int RamSlot { get; set; }
       public string Wifi { get; set; }
    }
}
