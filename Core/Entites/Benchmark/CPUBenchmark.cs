
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Core.Entites.Benchmark
{
    public class CPUBenchmark
    {
        
        public int Id { get; set; }
        public string? CpuName { get; set; }
        public string? Manufacturer { get; set; }
        public int? SingleScore { get; set; }
        public int? MultiScore { get; set; }
        public int? Cores { get; set; }
        public int? Threads { get; set; }
        public double? BaseClock { get; set; }
        public double? TurboClock { get; set; }
        public string? Type { get; set; }
    }
}