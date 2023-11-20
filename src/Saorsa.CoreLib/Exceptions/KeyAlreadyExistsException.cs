namespace Saorsa.Exceptions;


/// <summary>
/// Exception class that indicates that a given property key for an entity already exists.
/// </summary>
public class KeyAlreadyExistsException : KeyException
{
    public KeyAlreadyExistsException(
        string keyName,
        string? message = null,
        Exception? innerException = null)
        : base(keyName, message, innerException)
    {
    }
}
