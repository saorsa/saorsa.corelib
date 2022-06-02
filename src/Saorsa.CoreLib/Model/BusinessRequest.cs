namespace Saorsa.Model;

public class BusinessRequest<TId>
{
    public string RefId { get; set; } = $"Request-{Guid.NewGuid():N}";
    
    public string? SearchKey { get; set; }
}

public class BusinessRequest : BusinessRequest<Guid>
{
}
