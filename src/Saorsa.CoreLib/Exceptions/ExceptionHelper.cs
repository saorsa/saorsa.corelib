namespace Saorsa.Exceptions;


/// <summary>
/// Utility class for conditional throw of exceptions.
/// </summary>
public static class ExceptionHelper
{
    /// <summary>
    /// Checks if the target object is NULL and throws ArgumentNullException accordingly.
    /// </summary>
    /// <param name="target">The target object to be validated.</param>
    /// <param name="parameterName">The parameter name associated with the target, optional.</param>
    /// <param name="message">Customized exception message string, optional.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown, if the target argument is NULL.
    /// </exception>
    public static void ThrowIfNull(
        object target,
        string? parameterName = null,
        string? message = null)
    {
        if (target == null)
        {
            throw new ArgumentNullException(
                parameterName,
                message ?? "A required parameter is NULL.");
        }
    }
}
