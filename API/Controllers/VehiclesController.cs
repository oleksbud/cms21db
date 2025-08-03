using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController(IGenericRepository<Vehicle> repo) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Vehicle>>> GetVehicles(string? brand, string? sort)
    {
        var spec = new VehicleSpecification(brand, sort);

        var vehicles = await repo.GetAllWithSpec(spec);
        
        return Ok(vehicles);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Vehicle>> GetVehicle(int id)
    {
        var vehicle = await repo.GetByIdAsync(id);
        
        if (vehicle == null) return NotFound();
         
        return vehicle;
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
    {
        var spec = new BrandListSpecification();
        var brands = await repo.GetAllWithSpec(spec);
        return Ok(brands);
    }

    [HttpPost]
    public async Task<ActionResult<Vehicle>> AddVehicle(Vehicle vehicle)
    {
        repo.Add(vehicle);

        if (await repo.SaveAsync())
        {
            return CreatedAtAction("AddVehicle", new {id = vehicle.Id}, vehicle);
        }
        
        return BadRequest("Unable to create vehicle");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateVehicle(int id, Vehicle vehicle)
    {
        if (id != vehicle.Id || !VehicleExists(id)) return BadRequest();
        
        repo.Update(vehicle);
        
        if (await repo.SaveAsync())
        {
            return NoContent();
        }

        return BadRequest("Unable to update vehicle");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteVehicle(int id)
    {
        var vehicle = await repo.GetByIdAsync(id);
        
        if (vehicle == null) return NotFound();
        
        repo.Delete(vehicle);
        
        if (await repo.SaveAsync())
        {
            return NoContent();
        }
        
        return BadRequest("Unable to delete vehicle");
    }

    private bool VehicleExists(int id)
    {
        return repo.Exists(id);
    }
}