using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class Case : BaseEntity
    {
        public string? Type { get; set; }
        public string? Color { get; set; }
        public string? Side_Panel { get; set; }

    }
}
