namespace Saorsa;

public class EnvironmentVariableException : KeyException<string>
{
    public EnvironmentVariableException(string key, string? message) : base(key, message)
    {
    }

    public EnvironmentVariableException(string key, string? message, Exception? inner) : base(key, message, inner)
    {
    }
}
