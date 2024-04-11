
using System.Text.Json;

using Core.Entites;

namespace Infrastructure.Data
{
    public class SetupMasterContentSeed
    {
        public static async Task SeedAsync(SetupMasterDbContext context)
        {
            if(!context.Processors.Any())
            {
                var processorsData = File.ReadAllText("../Infrastructure/Data/SeedData/Processor.json");
                var CPUs = JsonSerializer.Deserialize<List<Processor>>(processorsData);
                context.Processors.AddRange(CPUs);
            }
            if(!context.RAMs.Any())
            {
                var RamData = File.ReadAllText("../Infrastructure/Data/SeedData/RAM.json");
                var RAMs = JsonSerializer.Deserialize<List<RAM>>(RamData);
                context.RAMs.AddRange(RAMs);
            }
            if(!context.GPUs.Any())
            {
                var GPuData = File.ReadAllText("../Infrastructure/Data/SeedData/GPU.json");
                var GPUs = JsonSerializer.Deserialize<List<GPU>>(GPuData);
                context.GPUs.AddRange(GPUs);
            }
            if(!context.SSDs.Any())
            {
                var SSDData = File.ReadAllText("../Infrastructure/Data/SeedData/SSD.json");
                var SSDs = JsonSerializer.Deserialize<List<SSD>>(SSDData);
                context.SSDs.AddRange(SSDs);
            }
            if(!context.HDDs.Any())
            {
                var HDDData = File.ReadAllText("../Infrastructure/Data/SeedData/HDD.json");
                var HDDs = JsonSerializer.Deserialize<List<HDD>>(HDDData);
                context.HDDs.AddRange(HDDs);
            }
            if(!context.motherboards.Any())
            {
                var MotherboardData = File.ReadAllText("../Infrastructure/Data/SeedData/MB_DATA.json");
                var MotherBoeards = JsonSerializer.Deserialize<List<Motherboard>>(MotherboardData);
                context.motherboards.AddRange(MotherBoeards);
            }
            if(context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}