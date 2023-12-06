namespace Saorsa.Model;


/// <summary>
/// Represents a DTO filter input for a business operation.
/// </summary>
/// <typeparam name="TId">
/// The underlying type of the unique identifier of the entities that are filtered by the operation.
/// </typeparam>
public class BusinessRequest<TId>
{
    /// <summary>
    /// Gets or sets the unique identifier of the request.
    /// </summary>
    public string RefId { get; set; } = $"Request-{Guid.NewGuid():N}";

    /// <summary>
    /// Gets or sets a filter by the unique ID of target entities. Optional.
    /// </summary>
    public TId? FilterById { get; set; }
    
    /// <summary>
    /// Gets or sets a global search pattern for target entities. Optional.
    /// </summary>
    public string? SearchKey { get; set; }
}


/// <summary>
/// Represents a DTO filter input for a business operation.
/// </summary>
public class BusinessRequest : BusinessRequest<Guid>
{
}
