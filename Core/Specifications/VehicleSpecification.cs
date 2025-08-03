using Core.Entities;

namespace Core.Specifications;

public class VehicleSpecification : BaseSpecification<Vehicle>
{
    public VehicleSpecification(string? brand, string? sort) : base(x =>
        (string.IsNullOrWhiteSpace(brand) || x.Brand == brand)
        )
    {
        switch (sort)
        {
            case "brand":
                AddOrderBy(x => x.Brand);
                break;
            case "nameDesc":
                AddOrderByDescending(x => x.Name);
                break;
            case "year":
                AddOrderBy(x => x.ProductionYear);
                break;
            case "yearDesc":
                AddOrderByDescending(x => x.ProductionYear);
                break;
            default:
                AddOrderBy(x => x.Name);
                break;
        }
    }
}