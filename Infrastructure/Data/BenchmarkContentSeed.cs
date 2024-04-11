

using System.Text.Json;
using Core.Entites.Benchmark;

namespace Infrastructure.Data
{
    public class BenchmarkContentSeed
    {
        public static async Task SeedAsync(BenchmarkDbContext context)
        {
            if(!context.CPUsbenchmark.Any())
            {
                var CPUData = File.ReadAllText("../Infrastructure/Data/SeedData/CPUBenchmark.json");
                var CPUs = JsonSerializer.Deserialize<List<CPUBenchmark>>(CPUData);
                context.CPUsbenchmark.AddRange(CPUs);
            }
            if(!context.GPUsbenchmark.Any())
            {
                var GPUData = File.ReadAllText("../Infrastructure/Data/SeedData/GPUBenchmark.json");
                var GPUs = JsonSerializer.Deserialize<List<CPUBenchmark>>(GPUData);
                context.CPUsbenchmark.AddRange(GPUs);
            }
            if(context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
        
    }
}