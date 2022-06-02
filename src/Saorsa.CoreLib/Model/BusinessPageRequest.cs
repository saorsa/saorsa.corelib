namespace Saorsa.Model;

public class BusinessPageRequest<TId> : BusinessRequest<TId>
{
    public IEnumerable<TId>? FilterIDs { get; set; }
    
    public IEnumerable<TId>? ExcludeIDs { get; set; }

    public uint? PageSize { get; set; }
    
    public uint? PageIndex { get; set; }
    
    public IEnumerable<SortDescriptor>? SortBy { get; set; }
}

public class BusinessPageRequest : BusinessPageRequest<Guid>
{
}
