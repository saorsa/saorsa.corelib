namespace Saorsa.Security;

public class Acl
{
    public string User { get; init; } = string.Empty;

    public string Group { get; init; } = string.Empty;
    
    public AclMask UserPermissions { get; init; } 
    
    public AclMask GroupPermissions { get; init; }
    
    public AclMask OtherPermissions { get; init; }

    public IDictionary<string, object> ExtendedAttributes { get; } = new Dictionary<string, object>();
}
