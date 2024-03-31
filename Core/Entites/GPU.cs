using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class GPU : BaseEntity
    {
        public string BoostClock { get; set; }
        public string VRam { get; set; }
        public string MemoryClock { get; set; }
        public string TDP { get; set; }

    }
}
