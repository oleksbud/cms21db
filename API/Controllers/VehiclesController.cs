using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController(IVehicleRepository repo) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Vehicle>>> GetVehicles(string? brand, string? sort)
    {
        return Ok(await repo.GetVehiclesAsync(brand, sort));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Vehicle>> GetVehicle(int id)
    {
        var vehicle = await repo.GetVehicleByIdAsync(id);
        
        if (vehicle == null) return NotFound();
        
        return vehicle;
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
    {
        return Ok(await repo.GetBrandsAsync());
    }

    [HttpPost]
    public async Task<ActionResult<Vehicle>> AddVehicle(Vehicle vehicle)
    {
        repo.AddVehicle(vehicle);

        if (await repo.SaveChangesAsync())
        {
            return CreatedAtAction("AddVehicle", new {id = vehicle.Id}, vehicle);
        }
        
        return BadRequest("Unable to create vehicle");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateVehicle(int id, Vehicle vehicle)
    {
        if (id != vehicle.Id || !VehicleExists(id)) return BadRequest();
        
        repo.UpdateVehicle(vehicle);
        
        if (await repo.SaveChangesAsync())
        {
            return NoContent();
        }

        return BadRequest("Unable to update vehicle");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteVehicle(int id)
    {
        var vehicle = await repo.GetVehicleByIdAsync(id);
        
        if (vehicle == null) return NotFound();
        
        repo.DeleteVehicle(vehicle);
        
        if (await repo.SaveChangesAsync())
        {
            return NoContent();
        }
        
        return BadRequest("Unable to delete vehicle");
    }

    private bool VehicleExists(int id)
    {
        return repo.VehicleExists(id);
    }
}