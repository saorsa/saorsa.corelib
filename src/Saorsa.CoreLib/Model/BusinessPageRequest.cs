namespace Saorsa.Model;


/// <summary>
/// Represents a DTO filter input for a business operation that returns multiple results in paged result sets.
/// </summary>
/// <typeparam name="TId">
/// The underlying type of the unique identifier of the entities that are filtered by the operation.
/// </typeparam>
public class BusinessPageRequest<TId> : BusinessRequest<TId>
{
    /// <summary>
    /// Gets or sets a filter from a range of available unique IDs.
    /// </summary>
    public IEnumerable<TId>? FilterByIdInRange { get; set; }

    /// <summary>
    /// Gets or sets a a list of unique IDs that will be excluded from the result set.
    /// </summary>
    public IEnumerable<TId>? ExcludeIdInRange { get; set; }

    /// <summary>
    /// Gets or sets the number of records returned per page.
    /// </summary>
    public uint? PageSize { get; set; }
    
    /// <summary>
    /// Gets or sets the 0-based index of the page to be filtered out.
    /// </summary>
    public uint? PageIndex { get; set; }
    
    /// <summary>
    /// Gets or sets the property descriptors that will be used for sorting the result set into pages.
    /// </summary>
    public IEnumerable<SortDescriptor>? SortBy { get; set; }
}


/// <summary>
/// Represents a DTO filter input for a business operation that returns multiple results in paged result sets.
/// </summary>
public class BusinessPageRequest : BusinessPageRequest<Guid>
{
}
