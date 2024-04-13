using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entites.Benchmark
{
    public class GPUBenchmark
    {
        public int Id { get; set; }
        public string? GpuName { get; set; }
        public int? G3DMark { get; set; } // Graphics 3d Mark
        public int? G2DMark { get; set; } // Graphics 2D Mark
        public double? GpuValue { get; set; }
        public double? TDP { get; set; }
        public double? PowerPerformance { get; set; }
        public int? TestDate { get; set; }
        public string? Category { get; set; }
    }
}