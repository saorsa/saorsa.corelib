using System.Runtime.Serialization;

namespace Saorsa.Exceptions;

/// <summary>
/// Exception class that indicates a problem with a given entity property key.
/// </summary>
public class EntityKeyException : Exception
{
    /// <summary>
    /// Gets the object key-name triggering this exception.
    /// </summary>
    public string KeyName { get; }

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
    public EntityKeyException(
        string keyName,
        string? message = null,
        Exception? innerException = null) : base(message, innerException)
    {
        KeyName = keyName;
    }

    /// <summary>
    /// Initializes a new instance of the exception class
    /// using serialization context from the AppDomain.
    /// </summary>
    /// <param name="info">The serialization data object, provided by the runtime.</param>
    /// <param name="context">The streaming context, provided by the runtime.</param>
    protected EntityKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        this.KeyName = info.GetString(SerializationKeys.KeyName) ?? string.Empty;
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(SerializationKeys.KeyName, KeyName, typeof(string));
    }
}
