namespace Core.Entities;

public class Vehicle : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}