namespace Saorsa;

using System.Runtime.InteropServices;


/// <summary>
/// Simple utility class for OS- related ops.
/// </summary>
public static class OSUtil
{
    /// <summary>
    /// Collection of all known and supported OS platforms.
    /// </summary>
    public static readonly OSPlatform[] SupportedOSPlatforms = {
        OSPlatform.Linux,
        OSPlatform.Windows,
        OSPlatform.OSX,
        OSPlatform.FreeBSD,
    };

    /// <summary>
    /// Gets the runtime OS platform reference.
    /// </summary>
    public static OSPlatform CurrentOS { get; }

    /// <summary>
    /// Gets an indication whether the current runtime is Windows based.
    /// </summary>
    public static bool IsWindows => CurrentOS.Equals(OSPlatform.Windows);

    /// <summary>
    /// Private class initializer.
    /// </summary>
    static OSUtil()
    {
        var platform = SupportedOSPlatforms.First();
        foreach (var os in SupportedOSPlatforms)
        {
            if (RuntimeInformation.IsOSPlatform(os))
            {
                platform = os;
            }
        }
        CurrentOS = platform;
    }

    /// <summary>
    /// Gets the HOME directory of the current process user.
    /// </summary>
    /// <exception cref="Saorsa.Exceptions.EnvironmentVariableException">
    /// Thrown, if the environment variable $HOME is not registered.
    /// </exception>
    public static string HomeDirectory
    {
        get
        {
            var envVariable = IsWindows ? "%HOMEDRIVE%%HOMEPATH%" : "HOME";
            var homeFolder = EnvUtil.GetEnvironmentVariableOrThrow(envVariable);
            return homeFolder;
        }
    }
}
