using Saorsa.Exceptions;

namespace Saorsa;


public static class EnvUtil
{
    public static string GetEnvironmentVariableOrThrow(string envVariable)
    {
        if (string.IsNullOrEmpty(envVariable))
        {
            throw new ArgumentNullException(nameof(envVariable));
        }

        return Environment.GetEnvironmentVariable(envVariable) ??
               throw new EnvironmentVariableException(
                   envVariable,
                   $"Environment variable '{envVariable}' is not set.");
    }
}
