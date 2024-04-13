

using System.Reflection;
using System.Text.Json;
using Core.Entites.Benchmark;

namespace Infrastructure.Data
{
    public class BenchmarkContentSeed
    {
        public static async Task SeedAsync(BenchmarkDbContext context)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if(!context.CPUsbenchmark.Any())
            {
                var CPUData = File.ReadAllText(path + @"/Data/SeedData/CPUBenchmark.json");
                var CPUs = JsonSerializer.Deserialize<List<CPUBenchmark>>(CPUData);
                context.CPUsbenchmark.AddRange(CPUs);
            }
            if(!context.GPUsbenchmark.Any())
            {
                var GPUData = File.ReadAllText(path + @"/Data/SeedData/GPUBenchmark.json");
                var GPUs = JsonSerializer.Deserialize<List<GPUBenchmark>>(GPUData);
                context.GPUsbenchmark.AddRange(GPUs);
            }
            if(context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
        
    }
}