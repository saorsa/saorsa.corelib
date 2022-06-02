using System.Runtime.Serialization;

namespace Saorsa;

public class EnvironmentVariableException : Exception
{
    public string EnvironmentVariableKey { get; }

    public EnvironmentVariableException(string envVariableKey, string? message) : base(message)
    {
        EnvironmentVariableKey = envVariableKey;
    }

    public EnvironmentVariableException(string envVariableKey, string? message, Exception? inner) : base(message, inner)
    {
        EnvironmentVariableKey = envVariableKey;
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);

        info.AddValue(nameof(EnvironmentVariableKey), EnvironmentVariableKey, typeof(string));
    }
}
