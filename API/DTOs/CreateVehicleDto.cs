using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateVehicleDto
{
    [Required]
    public string Brand { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? Design { get; set; }
    [Required]
    public string ProductionYear { get; set; } = string.Empty;
    public string? Dlc { get; set; }
}