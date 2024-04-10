using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class RAM : BaseEntity
    {
        
        public int ID { get; set; }
        public string? RamType { get; set; }
        public string? Size { get; set; }
        public int Clock { get; set; }
        public int Sticks { get; set; }
    }
}
