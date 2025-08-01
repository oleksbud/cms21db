namespace Core.Entities;

public class Vehicle : BaseEntity
{
    public required string Brand { get; set; }
    public required string Name { get; set; }
    public string? Design { get; set; }
    public required string ProductionYear { get; set; }
    public string? Dlc { get; set; }
}