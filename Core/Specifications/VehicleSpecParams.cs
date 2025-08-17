namespace Core.Specifications;

public class VehicleSpecParams
{
    public int  PageSize { get; set; }
    public int PageIndex { get; set; }
    
    private List<string> _brands = [];
    public List<string> Brands
    {
        get => _brands;
        set => _brands = value.SelectMany(x => x.Split(',',
            StringSplitOptions.RemoveEmptyEntries)).ToList();
    }

    public string? Sort { get; set; }

    private string? _search;
    public string? Search
    {
        get => _search ?? string.Empty;
        set => _search = value?.ToLower();
    }
}