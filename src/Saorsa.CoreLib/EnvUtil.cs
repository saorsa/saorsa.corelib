using Saorsa.Exceptions;

namespace Saorsa;


/// <summary>
/// A simple environment variables utility class.
/// </summary>
public static class EnvUtil
{
    /// <summary>
    /// Gets the value of the environment variable or throws an exception.
    /// </summary>
    /// <param name="envVariable">The name of the env variable. Required.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown, if the environment variable key is NULL.
    /// </exception>
    /// <exception cref="EnvironmentVariableException">
    /// Thrown, if the environment variable specified by the envVariable parameter is not registered.
    /// </exception>
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
