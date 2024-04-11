
using Core.Entites.Benchmark;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BenchmarkDbContext : DbContext
    {
        
        public BenchmarkDbContext(DbContextOptions<BenchmarkDbContext> options) : base(options)
        {
        }
        public DbSet<CPUBenchmark> CPUsbenchmark { get; set; }
        public DbSet<GPUBenchmark> GPUsbenchmark{ get; set; }

    }
}