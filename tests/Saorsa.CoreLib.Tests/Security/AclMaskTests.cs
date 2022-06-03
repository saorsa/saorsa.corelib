namespace Saorsa.CoreLib.Tests.Security;

public class AclMaskTests
{
    [TestCase(AclMask.Read | AclMask.Write, AclMask.ReadWrite)]
    [TestCase(AclMask.Read | AclMask.Execute, AclMask.ReadExecute)]
    [TestCase(AclMask.Read | AclMask.Execute | AclMask.Write, AclMask.Full)]
    [TestCase(AclMask.Write | AclMask.Execute, AclMask.WriteExecute)]
    public void TestAclEquality(AclMask left, AclMask right)
    {
        Assert.That(right, Is.EqualTo(left));
    }
    
    [TestCase(AclMask.None, 0)]
    [TestCase(AclMask.Read, 4)]
    [TestCase(AclMask.Write, 2)]
    [TestCase(AclMask.Execute, 1)]
    [TestCase(AclMask.ReadWrite, 4 + 2)]
    [TestCase(AclMask.ReadExecute,  4 + 1)]
    [TestCase(AclMask.WriteExecute,  2 + 1)]
    [TestCase(AclMask.Full,  4 + 2 + 1)]
    public void TestAclEqualityIntegers(AclMask left, int right)
    {
        Assert.That(right, Is.EqualTo((int) left));
    }
    
    [TestCase(AclMask.None, false)]
    [TestCase(AclMask.Read, true)]
    [TestCase(AclMask.Write, false)]
    [TestCase(AclMask.Execute, false)]
    [TestCase(AclMask.ReadWrite, true)]
    [TestCase(AclMask.ReadExecute, true)]
    [TestCase(AclMask.WriteExecute, false)]
    [TestCase(AclMask.Full, true)]
    public void TestReadPermissions(AclMask mask, bool canRead)
    {
        Assert.That(mask & AclMask.Read, canRead 
            ? Is.EqualTo(AclMask.Read) 
            : Is.Not.EqualTo(AclMask.Read));
    }
    
    [TestCase(AclMask.None, false)]
    [TestCase(AclMask.Read, false)]
    [TestCase(AclMask.Write, true)]
    [TestCase(AclMask.Execute, false)]
    [TestCase(AclMask.ReadWrite, true)]
    [TestCase(AclMask.ReadExecute, false)]
    [TestCase(AclMask.WriteExecute, true)]
    [TestCase(AclMask.Full, true)]
    public void TestWritePermissions(AclMask mask, bool canWrite)
    {
        Assert.That(mask & AclMask.Write, canWrite 
            ? Is.EqualTo(AclMask.Write) 
            : Is.Not.EqualTo(AclMask.Write));
    }
    
    [TestCase(AclMask.None, false)]
    [TestCase(AclMask.Read, false)]
    [TestCase(AclMask.Write, false)]
    [TestCase(AclMask.Execute, true)]
    [TestCase(AclMask.ReadWrite, false)]
    [TestCase(AclMask.ReadExecute, true)]
    [TestCase(AclMask.WriteExecute, true)]
    [TestCase(AclMask.Full, true)]
    public void TestExecutePermissions(AclMask mask, bool canWrite)
    {
        Assert.That(mask & AclMask.Execute, canWrite 
            ? Is.EqualTo(AclMask.Execute) 
            : Is.Not.EqualTo(AclMask.Execute));
    }
}
