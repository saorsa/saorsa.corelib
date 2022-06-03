namespace Saorsa.CoreLib.Tests.Model;

public class BusinessRequestTests
{
    [Test]
    public void TestConstructorDefaults()
    {
        var request = new BusinessRequest();
        
        Assert.NotNull(request.RefId);
        Assert.Null(request.SearchKey);
    }

    [Test]
    public void TestRefId()
    {
        var valueRef = Guid.NewGuid().ToString();

        var error = new BusinessRequest
        {
            RefId = valueRef
        };
        
        Assert.NotNull(error.RefId);
        Assert.That(valueRef, Is.EqualTo(error.RefId));
    }

    [Test]
    public void TestSearchKey()
    {
        var valueRef = Guid.NewGuid().ToString();

        var error = new BusinessRequest
        {
            SearchKey = valueRef
        };
        
        Assert.NotNull(error.SearchKey);
        Assert.That(valueRef, Is.EqualTo(error.SearchKey));
    }
}
