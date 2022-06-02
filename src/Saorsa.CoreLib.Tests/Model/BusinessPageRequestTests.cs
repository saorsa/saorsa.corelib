namespace Saorsa.CoreLib.Tests.Model;

public class BusinessPageRequestTests
{
    [Test]
    public void TestConstructorDefaults()
    {
        var request = new BusinessPageRequest();
        
        Assert.Null(request.FilterIDs);
        Assert.Null(request.ExcludeIDs);
        Assert.Null(request.SortBy);
        Assert.False(request.PageIndex.HasValue);
        Assert.False(request.PageSize.HasValue);
    }

    [Test]
    public void TestPageSize()
    {
        var valueRef = (uint) new Random().Next(0, int.MaxValue);

        var error = new BusinessPageRequest
        {
            PageSize = valueRef
        };
        
        Assert.IsTrue(error.PageSize.HasValue);
        Assert.That(valueRef, Is.EqualTo(error.PageSize));
    }

    [Test]
    public void TestPageIndex()
    {
        var valueRef = (uint) new Random().Next(0, int.MaxValue);

        var error = new BusinessPageRequest
        {
            PageIndex = valueRef
        };
        
        Assert.IsTrue(error.PageIndex.HasValue);
        Assert.That(valueRef, Is.EqualTo(error.PageIndex));
    }

    [Test]
    public void TestFilterIDs()
    {
        var error = new BusinessPageRequest
        {
            FilterIDs = new []
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.Empty
            },
        };
        
        Assert.IsNotNull(error.FilterIDs);
        Assert.IsNotEmpty(error.FilterIDs);
        Assert.That(Guid.Empty, Is.EqualTo(error.FilterIDs.Last()));
    }

    [Test]
    public void TestExcludeIDs()
    {
        var error = new BusinessPageRequest
        {
            ExcludeIDs = new []
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.Empty
            },
        };
        
        Assert.IsNotNull(error.ExcludeIDs);
        Assert.IsNotEmpty(error.ExcludeIDs);
        Assert.That(Guid.Empty, Is.EqualTo(error.ExcludeIDs.Last()));
    }

    [Test]
    public void TestSortBy()
    {
        var error = new BusinessPageRequest
        {
            SortBy = ArraySegment<SortDescriptor>.Empty
        };
        
        Assert.IsNotNull(error.SortBy);
        Assert.IsEmpty(error.SortBy);
    }
}
