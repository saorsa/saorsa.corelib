namespace Saorsa.Model;

public class BusinessError
{
    public string RefId { get; set; } = $"Error-{Guid.NewGuid():N}";
    
    public int? ErrorCode { get; set; }
    
    public string? ErrorMessage { get; set; }
    
    public string? Description { get; set; }
    
    public string? Resolution { get; set; }
    
    public string? Uri { get; set; }

    public IDictionary<string, object> ExtendedInfo { get; } = new Dictionary<string, object>();
}
