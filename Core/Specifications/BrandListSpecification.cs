using Core.Entities;

namespace Core.Specifications;

public class BrandListSpecification : BaseSpecification<Vehicle, string>
{
    public BrandListSpecification()
    {
        AddSelect(x => x.Brand);
        ApplyDistinct();
    }
}