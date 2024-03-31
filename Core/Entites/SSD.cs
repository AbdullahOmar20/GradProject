using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class SSD : BaseEntity
    {
        public string FormFactor { get; set; }
        public string Protocol { get; set; }
        public string Size { get; set; }
    }
}
