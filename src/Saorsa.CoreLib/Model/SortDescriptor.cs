namespace Saorsa.Model;


/// <summary>
/// Represents a simple DTO for an object property and its sort direction.
/// </summary>
public class SortDescriptor
{
    /// <summary>
    /// Gets or sets the name of the property being sorted.
    /// </summary>
    public string Property { get; set; } = $"Property-{Guid.NewGuid()}";

    /// <summary>
    /// Gets or sets an indication whether sorting is ASC-ending or DESC-ending during fetch.
    /// </summary>
    public bool? IsDescending { get; set; }
}
