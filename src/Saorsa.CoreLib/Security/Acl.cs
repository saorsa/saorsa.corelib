namespace Saorsa.Security;


/// <summary>
/// Represents a simple ACL container, mimicking behaviour from GNU bash.
/// </summary>
public class Acl
{
    /// <summary>
    /// Gets or sets the name or ID of the user.
    /// </summary>
    public string User { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the name or ID of the user group.
    /// </summary>
    public string Group { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's permissions mask.
    /// </summary>
    public AclMask UserPermissions { get; init; }

    /// <summary>
    /// Gets or sets the group's permissions mask.
    /// </summary>
    public AclMask GroupPermissions { get; init; }

    /// <summary>
    /// Gets or sets the others' permissions mask.
    /// </summary>
    public AclMask OtherPermissions { get; init; }

    /// <summary>
    /// Gets the extended attributes of the ACL container.
    /// </summary>
    public IDictionary<string, object> ExtendedAttributes { get; } = new Dictionary<string, object>();
}
