using System.Runtime.Serialization;
using Saorsa.Exceptions;

namespace Saorsa.CoreLib.Tests.Exceptions;

public class ErrorCodeExceptionTests
{
    [Test]
    public void TestConstructor()
    {
        var code = new Random().Next();
        var message = Guid.NewGuid().ToString("D");
        var exception = new ErrorCodeException(code, message);
        
        Assert.NotNull(exception);
        Assert.That(code, Is.EqualTo(exception.ErrorCode));
        Assert.That(message, Is.EqualTo(exception.Message));
        // ReSharper disable once UseIsOperator.1
        // ReSharper disable once UseMethodIsInstanceOfType
        Assert.True(typeof(Exception).IsAssignableFrom(exception.GetType()));
    }

    [Test]
    public void TestConstructorWithInnerException()
    {
        var code = new Random().Next();
        var message = Guid.NewGuid().ToString("D");
        var exception = new ErrorCodeException(code, message, new Exception());
        
        Assert.NotNull(exception.InnerException);
    }

    [Test]
    public void TestSerialization()
    {
        var code = new Random().Next();
        var message = Guid.NewGuid().ToString("D");
        var exception = new ErrorCodeException(code, message);
        var serializationInfo = new SerializationInfo(exception.GetType(), new FormatterConverter());
        var streamingContext = new StreamingContext();
        
        Assert.DoesNotThrow(() =>
        {
            exception.GetObjectData(serializationInfo, streamingContext);
        });

        var serializedKey = serializationInfo.GetInt32(SerializationKeys.ErrorCode);
        Assert.NotNull(serializedKey);

        Assert.That(exception.ErrorCode, Is.EqualTo(serializedKey));
    }
}
