
using System.Reflection;
using System.Text.Json;

using Core.Entites;

namespace Infrastructure.Data
{
    public class SetupMasterContentSeed
    {
        public static async Task SeedAsync(SetupMasterDbContext context)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if(!context.Processors.Any())
            {
                var processorsData = File.ReadAllText(path+@"/Data/SeedData/Processor.json");
                var CPUs = JsonSerializer.Deserialize<List<Processor>>(processorsData);
                context.Processors.AddRange(CPUs);
            }
            if(!context.RAMs.Any())
            {
                var RamData = File.ReadAllText(path+@"/Data/SeedData/RAM.json");
                var RAMs = JsonSerializer.Deserialize<List<RAM>>(RamData);
                context.RAMs.AddRange(RAMs);
            }
            if(!context.GPUs.Any())
            {
                var GPuData = File.ReadAllText(path+@"/Data/SeedData/GPU.json");
                var GPUs = JsonSerializer.Deserialize<List<GPU>>(GPuData);
                context.GPUs.AddRange(GPUs);
            }
            if(!context.SSDs.Any())
            {
                var SSDData = File.ReadAllText(path+@"/Data/SeedData/SSD.json");
                var SSDs = JsonSerializer.Deserialize<List<SSD>>(SSDData);
                context.SSDs.AddRange(SSDs);
            }
            if(!context.HDDs.Any())
            {
                var HDDData = File.ReadAllText(path+@"/Data/SeedData/HDD.json");
                var HDDs = JsonSerializer.Deserialize<List<HDD>>(HDDData);
                context.HDDs.AddRange(HDDs);
            }
            if(!context.motherboards.Any())
            {
                var MotherboardData = File.ReadAllText(path+@"/Data/SeedData/MB_DATA.json");
                var MotherBoeards = JsonSerializer.Deserialize<List<Motherboard>>(MotherboardData);
                context.motherboards.AddRange(MotherBoeards);
            }
            if(!context.Cases.Any())
            {
                var casesdata = File.ReadAllText(path+@"/Data/SeedData/case.json");
                var cases = JsonSerializer.Deserialize<List<Case>>(casesdata);
                context.Cases.AddRange(cases);
            }
            if(!context.CPUCoolers.Any())
            {
                var coolerdata = File.ReadAllText(path+@"/Data/SeedData/cooler.json");
                var coolers = JsonSerializer.Deserialize<List<CPUCooler>>(coolerdata);
                context.CPUCoolers.AddRange(coolers);
            }
            if(!context.PowerSupplies.Any())
            {
                var psudata = File.ReadAllText(path+@"/Data/SeedData/psu.json");
                var psus = JsonSerializer.Deserialize<List<PowerSupply>>(psudata);
                context.PowerSupplies.AddRange(psus);
            }
            
            if(context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}