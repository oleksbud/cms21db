using Core.Entities;

namespace Core.Specifications;

public class VehicleSpecification : BaseSpecification<Vehicle>
{
    public VehicleSpecification(VehicleSpecParams specParams) : base(x =>
        (string.IsNullOrWhiteSpace(specParams.Search) || x.Name.Contains(specParams.Search.ToLower())) &&
        (specParams.Brands.Count == 0 || specParams.Brands.Contains(x.Brand))
        )
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        
        switch (specParams.Sort)
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