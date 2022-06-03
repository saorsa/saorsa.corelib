namespace Saorsa.Security;

[Flags]
public enum AclMask: byte
{
    None =    0,
    Read =    4,
    Write =   2,
    Execute = 1,
        
    ReadWrite = Read | Write,
    ReadExecute = Read | Execute,
    WriteExecute = Write | Execute,
    Full = Read | Write | Execute,
}
