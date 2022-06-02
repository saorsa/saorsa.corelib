namespace Saorsa.Model;

public class BusinessPageResult<TRequest, TId, TPageItem> : BusinessResult<TRequest, IEnumerable<TPageItem>>
    where TRequest : BusinessPageRequest<TId>
{
    public uint? PageSize => Context?.PageSize;

    public uint? PageIndex => Context?.PageIndex;
    
    public ulong? TotalCount { get; set; }

    public uint? TotalPages =>
        TotalCount.HasValue && PageSize.HasValue ?
            PageSize.Value > 0 ? Convert.ToUInt32(
                Math.Ceiling(Convert.ToDouble(TotalCount.Value) / PageSize.Value))
                : 0u 
            : null;
}

public class BusinessPageResult<TRequest, TPageItem> : BusinessPageResult<TRequest, Guid, TPageItem>
    where TRequest : BusinessPageRequest<Guid>
{
}

public class BusinessPageResult<TPageItem> : BusinessPageResult<BusinessPageRequest, TPageItem>
{
}
