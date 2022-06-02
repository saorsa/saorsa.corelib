namespace Saorsa.CoreLib.Tests.Model;

public class BusinessResultTests
{
    [Test]
    public void TestDefaultConstructor()
    {
        var result = new BusinessResult<int>();
        
        Assert.IsNotNull(result.RefId);
        Assert.IsFalse(result.IsError);
        Assert.IsFalse(result.IsNull);
        Assert.IsNull(result.Context);
        Assert.IsNotNull(result.ExtendedInfo);
        Assert.That(result.ExtendedInfo.Count, Is.EqualTo(0));
        Assert.NotNull(result.Messages);
        Assert.IsEmpty(result.Messages);
    }
    
    [Test]
    public void TestRefId()
    {
        var valueRef = Guid.NewGuid().ToString("N");

        var result = new BusinessResult<int>
        {
            RefId = valueRef
        };
        
        Assert.IsNotNull(result.Result);
        Assert.That(valueRef, Is.EqualTo(result.RefId));
    }
    
    [Test]
    public void TestContext()
    {
        var valueRef = Guid.NewGuid().ToString("N");

        var result = new BusinessResult<int>
        {
            Context = valueRef
        };
        
        Assert.IsNotNull(result.Result);
        Assert.That(valueRef, Is.EqualTo(result.Context));
    }
    
    [Test]
    public void TestIntegerResult()
    {
        var valueRef = new Random().Next();

        var result = new BusinessResult<int>
        {
            Result = valueRef
        };
        
        Assert.IsNotNull(result.Result);
        Assert.That(valueRef, Is.EqualTo(result.Result));
    }
    
    [Test]
    public void TestStringResult()
    {
        var valueRef = Guid.NewGuid().ToString("N");

        var result = new BusinessResult<string>
        {
            Result = valueRef
        };
        
        Assert.IsNotNull(result.Result);
        Assert.That(valueRef, Is.EqualTo(result.Result));
    }
    
    [Test]
    public void TestErrorWithoutResult()
    {
        var result = new BusinessResult<object>
        {
            Error = new BusinessError()
        };
        
        Assert.IsNull(result.Result);
        Assert.True(result.IsNull);
        Assert.IsNotNull(result.Error);
        Assert.True(result.IsError);
    }
    
    [Test]
    public void TestErrorWithResult()
    {
        var valueRef = Guid.NewGuid().ToString("N");

        var result = new BusinessResult<string>
        {
            Result = valueRef,
            Error = new BusinessError()
        };
        
        Assert.IsNotNull(result.Result);
        Assert.That(valueRef, Is.EqualTo(result.Result));
        Assert.IsFalse(result.IsNull);
        Assert.IsNotNull(result.Error);
        Assert.True(result.IsError);
    }

    [Test]
    public void TestSuccessResultNoContext()
    {
        var random = new Random();
        var resultValue = random.Next();
        var result = BusinessResult<object, int>.Success(resultValue);
        
        Assert.NotNull(result);
        Assert.False(result.IsError);
        Assert.False(result.IsNull);
        Assert.Null(result.Context);
        Assert.That(resultValue, Is.EqualTo(result.Result));
    }

    [Test]
    public void TestSuccessResult()
    {
        var random = new Random();
        var contextValue = Guid.NewGuid();
        var result = BusinessResult<Guid?, int>.Success(random.Next(), contextValue);
        
        Assert.NotNull(result);
        Assert.False(result.IsError);
        Assert.NotNull(result.Context);
        Assert.That(contextValue, Is.EqualTo(result.Context));
    }

    [Test]
    public void TestErrorResultNoContext()
    {
        var result = BusinessResult<object, int?>.Fail(new BusinessError());
        
        Assert.NotNull(result);
        Assert.True(result.IsError);
        Assert.True(result.IsNull);
        Assert.Null(result.Context);
        Assert.NotNull(result.Error);
    }

    [Test]
    public void TestErrorResult()
    {
        var contextValue = Guid.NewGuid();
        var result = BusinessResult<Guid?, int?>.Fail(new BusinessError(), contextValue);
        
        Assert.NotNull(result);
        Assert.True(result.IsError);
        Assert.True(result.IsNull);
        Assert.NotNull(result.Error);
        Assert.NotNull(result.Context);
        Assert.That(contextValue, Is.EqualTo(result.Context));
    }
}
