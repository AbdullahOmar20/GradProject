using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
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
            if(context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}