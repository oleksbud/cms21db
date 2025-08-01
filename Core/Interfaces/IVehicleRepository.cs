using Core.Entities;

namespace Core.Interfaces;

public interface IVehicleRepository
{
    Task<IReadOnlyList<Vehicle>> GetVehiclesAsync(string? brand, string? sort);
    Task<Vehicle?> GetVehicleByIdAsync(int id);
    Task<IReadOnlyList<string>> GetBrandsAsync();
    void AddVehicle(Vehicle vehicle);
    void UpdateVehicle(Vehicle vehicle);
    void DeleteVehicle(Vehicle vehicle);
    bool VehicleExists(int id);
    Task<bool> SaveChangesAsync();
}