namespace Saorsa.Model;


/// <summary>
/// Represents a business result for multiple items in a paged result set.
/// </summary>
/// <typeparam name="TRequest">
/// The type of the input filter for the business operation.
/// </typeparam>
/// <typeparam name="TId">
/// The underlying type of the unique identifier of the entities being filtered.
/// </typeparam>
/// <typeparam name="TPageItem">
/// The type of the items in the result page set.
/// </typeparam>
public class BusinessPageResult<TRequest, TId, TPageItem> : BusinessResult<TRequest, IEnumerable<TPageItem>>
    where TRequest : BusinessPageRequest<TId>
{
    /// <summary>
    /// Gets or sets the maximum number of items in each result page.
    /// </summary>
    public uint? PageSize => Context?.PageSize;

    /// <summary>
    /// Gets or sets the 0-based index of the returned page.
    /// </summary>
    public uint? PageIndex => Context?.PageIndex;

    /// <summary>
    /// Gets or sets the total number of items that match the filter input request.
    /// </summary>
    public ulong? TotalCount { get; set; }

    /// <summary>
    /// Gets the total number of pages that contain items matching the filter input request.
    /// </summary>
    public uint? TotalPages =>
        TotalCount.HasValue && PageSize.HasValue ?
            PageSize.Value > 0 ? Convert.ToUInt32(
                Math.Ceiling(Convert.ToDouble(TotalCount.Value) / PageSize.Value))
                : 0u 
            : null;
}


/// <summary>
/// Represents a business result for multiple items in a paged result set.
/// </summary>
/// <typeparam name="TRequest">
/// The type of the input filter for the business operation.
/// </typeparam>
/// <typeparam name="TPageItem">
/// The type of the items in the result page set.
/// </typeparam>
public class BusinessPageResult<TRequest, TPageItem> : BusinessPageResult<TRequest, Guid, TPageItem>
    where TRequest : BusinessPageRequest<Guid>
{
}


/// <summary>
/// Represents a business result for multiple items in a paged result set.
/// </summary>
/// <typeparam name="TPageItem">
/// The type of the items in the result page set.
/// </typeparam>
public class BusinessPageResult<TPageItem> : BusinessPageResult<BusinessPageRequest, TPageItem>
{
}
