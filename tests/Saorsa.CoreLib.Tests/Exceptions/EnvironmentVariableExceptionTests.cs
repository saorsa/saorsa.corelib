using System.Runtime.Serialization;
using Saorsa.Exceptions;

namespace Saorsa.CoreLib.Tests;

public class EnvironmentVariableExceptionTests
{
    [Test]
    public void TestConstructor()
    {
        var key = Guid.NewGuid().ToString("D");
        var message = Guid.NewGuid().ToString("D");
        var exception = new EnvironmentVariableException(key, message);
        
        Assert.NotNull(exception);
        Assert.That(key, Is.EqualTo(exception.KeyName));
        Assert.That(message, Is.EqualTo(exception.Message));
        // ReSharper disable once UseIsOperator.1
        // ReSharper disable once UseMethodIsInstanceOfType
        Assert.True(typeof(Exception).IsAssignableFrom(exception.GetType()));
    }
    
    [Test]
    public void TestConstructorWithInnerException()
    {
        var key = Guid.NewGuid().ToString("D");
        var message = Guid.NewGuid().ToString("D");
        var exception = new EnvironmentVariableException(key, message, new Exception());
        
        Assert.NotNull(exception.InnerException);
    }
}
