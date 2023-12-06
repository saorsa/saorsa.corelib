namespace Saorsa.Model;


/// <summary>
/// Represents a DTO object carrying information about a business error.
/// </summary>
public class BusinessError
{
    /// <summary>
    /// Gets or sets the reference identifier of the error.
    /// </summary>
    public string RefId { get; set; } = $"Error-{Guid.NewGuid():N}";

    /// <summary>
    /// Gets or sets the error code, if any.
    /// </summary>
    public int? ErrorCode { get; set; }

    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Get or sets additional description for the error.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets a resolution for the error.
    /// </summary>
    public string? Resolution { get; set; }

    /// <summary>
    /// Gets or sets the unique resource identifier for this error.
    /// </summary>
    public string? Uri { get; set; }

    /// <summary>
    /// Gets a meta data container for the error.
    /// </summary>
    public IDictionary<string, object> ExtendedInfo { get; } = new Dictionary<string, object>();
}
