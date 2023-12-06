namespace Saorsa.Security;


/// <summary>
/// Represents a simple ACL mask, mimicking permission masks in GNU bash.
/// </summary>
[Flags]
public enum AclMask: byte
{
    /// <summary>
    /// No permissions.
    /// </summary>
    None =    0,

    /// <summary>
    /// Read permissions.
    /// </summary>
    Read =    4,

    /// <summary>
    /// Write permissions.
    /// </summary>
    Write =   2,

    /// <summary>
    /// Execute permissions.
    /// </summary>
    Execute = 1,

    /// <summary>
    /// Utility mask for R+W
    /// </summary>
    ReadWrite = Read | Write,

    /// <summary>
    /// Utility mask for R+E
    /// </summary>
    ReadExecute = Read | Execute,

    /// <summary>
    /// Utility mask for W+E
    /// </summary>
    WriteExecute = Write | Execute,

    /// <summary>
    /// Utility mask for R+W+E
    /// </summary>
    Full = Read | Write | Execute,
}
