namespace Saorsa.CoreLib.Tests.Model;

public class BusinessPageResultTests
{
    [Test]
    public void TestConstructorDefaults()
    {
        var result = new BusinessPageResult<int>();
        
        Assert.IsFalse(result.PageIndex.HasValue);
        Assert.IsFalse(result.PageSize.HasValue);
        Assert.IsFalse(result.TotalCount.HasValue);
        Assert.IsFalse(result.TotalPages.HasValue);
    }
    
    [Test]
    public void TestPageRequestContext()
    {
        var random = new Random();
        var pageIndex = (uint) random.Next(0, 100);
        var pageSize = (uint) random.Next(10, 500);
        var result = new BusinessPageResult<int>()
        {
            Context = new BusinessPageRequest
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            }
        };
        
        Assert.IsTrue(result.PageIndex.HasValue);
        Assert.That(pageIndex, Is.EqualTo(result.PageIndex));
        Assert.IsTrue(result.PageSize.HasValue);
        Assert.That(pageSize, Is.EqualTo(result.PageSize));
        Assert.IsFalse(result.TotalCount.HasValue);
        Assert.IsFalse(result.TotalPages.HasValue);
    }

    [Test]
    public void TestTotalCountOnly()
    {
        var random = new Random();
        var totalCount = (uint) random.Next(100, 1000);
        var result = new BusinessPageResult<int>
        {
            TotalCount = totalCount
        };
        
        Assert.True(result.TotalCount.HasValue);
        Assert.False(result.TotalPages.HasValue);
    }

    [TestCase(10u, 10u, 1u)]
    [TestCase(10u, 11u, 2u)]
    [TestCase(10u, 19u, 2u)]
    [TestCase(10u, 20u, 2u)]
    [TestCase(10u, 21u, 3u)]
    public void TestTotalPagesCalculation(uint pageSize, ulong totalCount, uint expectedTotalPages)
    {
        var result = new BusinessPageResult<object>()
        {
            Context = new BusinessPageRequest
            {
                PageSize = pageSize,
            },
            TotalCount = totalCount,
        };
        
        Assert.True(result.TotalPages.HasValue);
        Assert.That(expectedTotalPages, Is.EqualTo(result.TotalPages));
    }
}
