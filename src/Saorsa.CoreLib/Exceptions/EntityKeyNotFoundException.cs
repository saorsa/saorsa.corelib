namespace Saorsa.Exceptions;


/// <summary>
/// Exception class that indicates that a given property key for an entity could not be found.
/// </summary>
public class EntityKeyNotFoundException : EntityKeyException
{
    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="keyName">The name of the parameter that caused the current exception.</param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter
    /// is not a null reference, the current exception is raised in a <see langword="catch" /> block
    /// that handles the inner exception.
    /// </param>
    public EntityKeyNotFoundException(
        string keyName,
        string? message = null,
        Exception? innerException = null)
        : base(keyName, message, innerException)
    {
    }
}
