namespace Saorsa.CoreLib.Tests.Security;

public class AclTests
{
    [Test]
    public void TestConstructor()
    {
        var acl = new Acl();
        
        Assert.NotNull(acl.User);
        Assert.That(acl.User, Is.EqualTo(string.Empty));
        Assert.NotNull(acl.Group);
        Assert.That(acl.Group, Is.EqualTo(string.Empty));
        Assert.NotNull(acl.ExtendedAttributes);
     
        Assert.That(acl.UserPermissions, Is.EqualTo(AclMask.None));
        Assert.That(acl.GroupPermissions, Is.EqualTo(AclMask.None));
        Assert.That(acl.OtherPermissions, Is.EqualTo(AclMask.None));   
    }
    
    [Test]
    public void TestConstructorForUserAndGroup()
    {
        var user = Guid.NewGuid().ToString("N");
        var group = Guid.NewGuid().ToString("N");
        var acl = new Acl
        {
            User = user,
            Group = group,
        };
        
        Assert.NotNull(acl.User);
        Assert.That(acl.User, Is.EqualTo(user));
        Assert.NotNull(acl.Group);
        Assert.That(acl.Group, Is.EqualTo(group));
        Assert.NotNull(acl.ExtendedAttributes);
     
        Assert.That(acl.UserPermissions, Is.EqualTo(AclMask.None));
        Assert.That(acl.GroupPermissions, Is.EqualTo(AclMask.None));
        Assert.That(acl.OtherPermissions, Is.EqualTo(AclMask.None));   
    }

    [TestCase(AclMask.Full, AclMask.ReadExecute, AclMask.None)]
    [TestCase(AclMask.None, AclMask.None, AclMask.None)]
    [TestCase(AclMask.Full, AclMask.Full, AclMask.Read)]
    public void TestConstructorForPermissions(AclMask user, AclMask group, AclMask other)
    {
        var acl = new Acl
        {
            UserPermissions = user,
            GroupPermissions = group,
            OtherPermissions = other
        };
        
        Assert.That(acl.UserPermissions, Is.EqualTo(user));
        Assert.That(acl.GroupPermissions, Is.EqualTo(group));
        Assert.That(acl.OtherPermissions, Is.EqualTo(other));
    }
}
