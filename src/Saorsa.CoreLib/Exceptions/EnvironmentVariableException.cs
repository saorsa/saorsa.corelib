namespace Saorsa.Exceptions;

public class EnvironmentVariableException : EntityKeyException
{
    public EnvironmentVariableException(
        string key,
        string? message = null,
        Exception? inner = null) : base(key, message, inner)
    {
    }
}
