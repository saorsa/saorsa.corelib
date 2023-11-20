namespace Saorsa;

using System.Runtime.InteropServices;


public static class OSUtil
{
    public static readonly OSPlatform[] SupportedOSPlatforms = {
        OSPlatform.Linux,
        OSPlatform.Windows,
        OSPlatform.OSX,
        OSPlatform.FreeBSD,
    };

    public static OSPlatform CurrentOS { get; }

    public static bool IsWindows => CurrentOS.Equals(OSPlatform.Windows);

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
