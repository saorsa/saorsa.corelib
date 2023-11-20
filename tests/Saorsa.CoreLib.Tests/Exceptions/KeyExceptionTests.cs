using System.Runtime.Serialization;
using Saorsa.Exceptions;

namespace Saorsa.CoreLib.Tests;


public class KeyExceptionTests
{
    [Test]
    public void TestConstructor()
    {
        var key = Guid.NewGuid().ToString("D");
        var message = Guid.NewGuid().ToString("D");
        var exception = new KeyException(key, message);
        
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
        var exception = new KeyException(key, message, new Exception());

        Assert.NotNull(exception.InnerException);
    }

    [Test]
    public void TestSerialization()
    {
        var key = Guid.NewGuid().ToString("D");;
        var message = Guid.NewGuid().ToString("D");
        var exception = new KeyException(key, message);
        var serializationInfo = new SerializationInfo(exception.GetType(), new FormatterConverter());
        var streamingContext = new StreamingContext();
        
        Assert.DoesNotThrow(() =>
        {
            exception.GetObjectData(serializationInfo, streamingContext);
        });

        var serializedKey = serializationInfo.GetString(nameof(SerializationKeys.KeyName));
        Assert.NotNull(serializedKey);

        Assert.That(exception.KeyName, Is.EqualTo(serializedKey));
    }
}
