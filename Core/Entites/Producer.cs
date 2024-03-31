using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }   
        public string ProducerName { get; set; }
    }
}