using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class HDD: BaseEntity
    {
        public string Size { get; set; }
        public int RPM { get; set; }
        
    }
}
