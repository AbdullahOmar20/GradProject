using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        //[ForeignKey(nameof(Producer))]
        public int ProducerId { get; set; }
        public string? ProducerName { get; set; }
        [AllowNull]
        public string? ProductPage { get; set; }
    }
}