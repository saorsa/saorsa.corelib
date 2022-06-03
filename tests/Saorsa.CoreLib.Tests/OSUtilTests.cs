namespace Saorsa.CoreLib.Tests;

public class OSUtilTests
{
    [Test]
    public void TestCurrentOS()
    {
        var os = OSUtil.CurrentOS;
        Assert.IsNotNull(os);
    }

    [Test]
    public void TestIsWindows()
    {
        var isWindows = OSUtil.IsWindows;
        var knownWindowsPlatformIDs = new[]
        {
            PlatformID.Win32S,
            PlatformID.Win32Windows,
            PlatformID.Win32NT,
            PlatformID.WinCE
        };
        
        Assert.That(
            knownWindowsPlatformIDs.Contains(Environment.OSVersion.Platform),
            Is.EqualTo(isWindows));
    }

    [Test]
    public void TestHomeDirectory()
    {
        var os = OSUtil.HomeDirectory;
        Assert.IsNotNull(os);
    }
}
