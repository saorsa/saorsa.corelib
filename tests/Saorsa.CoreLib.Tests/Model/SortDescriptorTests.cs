namespace Saorsa.CoreLib.Tests.Model;

public class SortDescriptorTests
{
    [Test]
    public void TestDefaultConstructor()
    {
        var result = new SortDescriptor();
        
        Assert.IsNotNull(result.Property);
        Assert.IsNull(result.IsDescending);
    }
    
    [Test]
    public void TestProperty()
    {
        var valueRef = Guid.NewGuid().ToString("D");
        var result = new SortDescriptor()
        {
            Property = valueRef,
        };
        
        Assert.That(valueRef, Is.EqualTo(result.Property));
    }
    
    [Test]
    public void TestDescending()
    {
        var result = new SortDescriptor()
        {
            IsDescending = true,
        };
        
        Assert.IsNotNull(result.IsDescending);
        Assert.True(result.IsDescending);
    }
}
