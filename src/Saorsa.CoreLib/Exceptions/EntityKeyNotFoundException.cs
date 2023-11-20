namespace Saorsa.Exceptions;


/// <summary>
/// Exception class that indicates that a given property key for an entity could not be found.
/// </summary>
public class EntityKeyNotFoundException : EntityKeyException
{
    public EntityKeyNotFoundException(
        string key,
        string? message = null,
        Exception? innerException = null)
        : base(key, message, innerException)
    {
    }
}
