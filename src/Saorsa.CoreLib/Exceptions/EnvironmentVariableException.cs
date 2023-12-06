namespace Saorsa.Exceptions;


/// <summary>
/// Exception class that indicates an error with a target environment variable name.
/// </summary>
public class EnvironmentVariableException : EntityKeyException
{
    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="environmentVariableName">The name of the parameter that caused the current exception.</param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter
    /// is not a null reference, the current exception is raised in a <see langword="catch" /> block
    /// that handles the inner exception.
    /// </param>
    public EnvironmentVariableException(
        string environmentVariableName,
        string? message = null,
        Exception? innerException = null) : base(environmentVariableName, message, innerException)
    {
    }
}
