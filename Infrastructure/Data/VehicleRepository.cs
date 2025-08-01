using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class VehicleRepository(StoreContext context) : IVehicleRepository
{
    public async Task<IReadOnlyList<Vehicle>> GetVehiclesAsync(string? brand, string? sort)
    {
        var query = context.Vehicles.AsQueryable();
        if (!string.IsNullOrWhiteSpace(brand))
        {
            query = query.Where(x => x.Brand == brand);
        }


        query = sort switch
        {
            "brand" => query.OrderBy(x => x.Brand),
            "nameDesc" => query.OrderByDescending(x => x.Name),
            "year" => query.OrderBy(x => x.ProductionYear),
            "yearDesc" => query.OrderByDescending(x => x.ProductionYear),
            _ => query.OrderBy(x => x.Name)
        };
        
        return await query.ToListAsync();
    }

    public async Task<Vehicle?> GetVehicleByIdAsync(int id)
    {
        return await context.Vehicles.FindAsync(id);
    }

    public async Task<IReadOnlyList<string>> GetBrandsAsync()
    {
        return await context.Vehicles.Select(x => x.Brand)
            .Distinct()
            .OrderBy(x => x)
            .ToListAsync();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        context.Vehicles.Add(vehicle);
    }

    public void UpdateVehicle(Vehicle vehicle)
    {
        context.Entry(vehicle).State = EntityState.Modified;
    }

    public void DeleteVehicle(Vehicle vehicle)
    {
        context.Vehicles.Remove(vehicle);
    }

    public bool VehicleExists(int id)
    {
        return context.Vehicles.Any(e => e.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
       return await context.SaveChangesAsync() > 0;
    }
}