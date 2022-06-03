using System.Runtime.Serialization;

namespace Saorsa.CoreLib.Tests;

public class KeyExistsExceptionTests
{
    [Test]
    public void TestConstructor()
    {
        var key = Guid.NewGuid();
        var message = Guid.NewGuid().ToString("D");
        var exception = new KeyExistsException(key, message);
        
        Assert.NotNull(exception);
        Assert.That(key, Is.EqualTo(exception.Key));
        Assert.That(message, Is.EqualTo(exception.Message));
        // ReSharper disable once UseIsOperator.1
        // ReSharper disable once UseMethodIsInstanceOfType
        Assert.True(typeof(Exception).IsAssignableFrom(exception.GetType()));
    }

    [Test]
    public void TestConstructorWithInnerException()
    {
        var key = Guid.NewGuid();
        var message = Guid.NewGuid().ToString("D");
        var exception = new KeyExistsException(key, message, new Exception());
        
        Assert.NotNull(exception.InnerException);
    }

    [Test]
    public void TestSerialization()
    {
        var key = Guid.NewGuid();
        var message = Guid.NewGuid().ToString("D");
        var exception = new KeyExistsException(key, message);
        var serializationInfo = new SerializationInfo(exception.GetType(), new FormatterConverter());
        var streamingContext = new StreamingContext();
        
        Assert.DoesNotThrow(() =>
        {
            exception.GetObjectData(serializationInfo, streamingContext);
        });

        var serializedKey = serializationInfo.GetString(nameof(exception.Key));
        Assert.NotNull(serializedKey);

        var parsed = Guid.Parse(serializedKey!);
        Assert.That(exception.Key, Is.EqualTo(parsed));
        Assert.That(key, Is.EqualTo(parsed));
    }
}
