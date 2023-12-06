namespace Saorsa.Exceptions;


/// <summary>
/// Exception class that indicates that a given property key for an entity already exists.
/// </summary>
public class EntityKeyAlreadyExistsException : EntityKeyException
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
    public EntityKeyAlreadyExistsException(
        string keyName,
        string? message = null,
        Exception? innerException = null)
        : base(keyName, message, innerException)
    {
    }
}
