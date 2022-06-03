namespace Saorsa.CoreLib.Tests.Model;

public class BusinessErrorTests
{
    [Test]
    public void TestConstructorDefaults()
    {
        var error = new BusinessError();
        
        Assert.NotNull(error.RefId);
        Assert.Null(error.ErrorMessage);
        Assert.Null(error.Resolution);
        Assert.Null(error.Description);
        Assert.Null(error.Uri);
        Assert.False(error.ErrorCode.HasValue);
        Assert.NotNull(error.ExtendedInfo);
        Assert.That(error.ExtendedInfo.Count, Is.EqualTo(0));
    }

    [Test]
    public void TestRefId()
    {
        var valueRef = Guid.NewGuid().ToString();

        var error = new BusinessError
        {
            RefId = valueRef
        };
        
        Assert.NotNull(error.RefId);
        Assert.That(valueRef, Is.EqualTo(error.RefId));
    }

    [Test]
    public void TestMessage()
    {
        var valueRef = Guid.NewGuid().ToString();

        var error = new BusinessError
        {
            ErrorMessage = valueRef
        };
        
        Assert.NotNull(error.ErrorMessage);
        Assert.That(valueRef, Is.EqualTo(error.ErrorMessage));
    }

    [Test]
    public void TestDescription()
    {
        var valueRef = Guid.NewGuid().ToString();

        var error = new BusinessError
        {
            Description = valueRef
        };
        
        Assert.NotNull(error.Description);
        Assert.That(valueRef, Is.EqualTo(error.Description));
    }

    [Test]
    public void TestResolution()
    {
        var valueRef = Guid.NewGuid().ToString();

        var error = new BusinessError
        {
            Resolution = valueRef
        };
        
        Assert.NotNull(error.Resolution);
        Assert.That(valueRef, Is.EqualTo(error.Resolution));
    }

    [Test]
    public void TestUri()
    {
        var valueRef = Guid.NewGuid().ToString();

        var error = new BusinessError
        {
            Uri = valueRef
        };
        
        Assert.NotNull(error.Uri);
        Assert.That(valueRef, Is.EqualTo(error.Uri));
    }

    [Test]
    public void TestCode()
    {
        var valueRef = new Random().Next();

        var error = new BusinessError
        {
            ErrorCode = valueRef
        };
        
        Assert.True(error.ErrorCode.HasValue);
        Assert.That(valueRef, Is.EqualTo(error.ErrorCode));
    }
}
