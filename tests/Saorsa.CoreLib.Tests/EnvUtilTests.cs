using Saorsa.Exceptions;

namespace Saorsa.CoreLib.Tests;

public class EnvUtilTests
{
    [Test]
    public void TestGetEnvironmentVariableOrThrow()
    {
        var envVar = $"env-{Guid.NewGuid():N}";
        var envVal = Guid.NewGuid().ToString("N");
        Environment.SetEnvironmentVariable(envVar, envVal);

        var result = EnvUtil.GetEnvironmentVariableOrThrow(envVar);
        
        Assert.NotNull(result);
        Assert.That(envVal, Is.EqualTo(result));
    }
    
    [Test]
    public void TestGetEnvironmentVariableOrThrowForThrows()
    {
        var envVar = $"env-{Guid.NewGuid():N}";
        Environment.SetEnvironmentVariable(envVar, null);

        Assert.Throws<EnvironmentVariableException>(() =>
            EnvUtil.GetEnvironmentVariableOrThrow(envVar));
    }

    [Test]
    public void TestGetEnvironmentVariableOrThrowWithNullArgument()
    {
        string envVar = string.Empty;
        Assert.Throws<ArgumentNullException>(() =>
            EnvUtil.GetEnvironmentVariableOrThrow(envVar));
    }
}
