using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class Processor : BaseEntity
    {
        [AllowNull]
        public string? BaseClock { get; set; }
        [AllowNull]
        public string? TurboClock { get; set; }
        [AllowNull]
        public int Cores { get; set; }
        [AllowNull]
        public int Threads { get; set; }
        [AllowNull]
        public string? TDP { get; set; }
        [AllowNull]
        public string? Socket { get; set; }
        [AllowNull]
        public string? IntegeratedGPU { get; set; }

    }
}
