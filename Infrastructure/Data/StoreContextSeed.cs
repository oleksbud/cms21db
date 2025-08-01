using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public static class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext storeContext)
    {
        if (!storeContext.Vehicles.Any())
        {
            var vehicleData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/vehicles.json");
            var vehicles = JsonSerializer.Deserialize<List<Vehicle>>(vehicleData);

            if (vehicles == null) return;
            
            storeContext.Vehicles.AddRange(vehicles);
            await storeContext.SaveChangesAsync();
        }
    }
}