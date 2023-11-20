namespace Saorsa.CoreLib.Tests.Security;

public class AclMaskTests
{
    [TestCase((byte)(AclMask.Read | AclMask.Write), (byte)AclMask.ReadWrite)]
    [TestCase((byte)(AclMask.Read | AclMask.Execute), (byte)AclMask.ReadExecute)]
    [TestCase((byte)(AclMask.Read | AclMask.Execute | AclMask.Write), (byte)AclMask.Full)]
    [TestCase((byte)(AclMask.Write | AclMask.Execute), (byte)AclMask.WriteExecute)]
    public void TestAclEquality(AclMask left, AclMask right)
    {
        Assert.That(right, Is.EqualTo(left));
    }
    
    [TestCase((byte)AclMask.None, 0)]
    [TestCase((byte)AclMask.Read, 4)]
    [TestCase((byte)AclMask.Write, 2)]
    [TestCase((byte)AclMask.Execute, 1)]
    [TestCase((byte)AclMask.ReadWrite, 4 + 2)]
    [TestCase((byte)AclMask.ReadExecute,  4 + 1)]
    [TestCase((byte)AclMask.WriteExecute,  2 + 1)]
    [TestCase((byte)AclMask.Full,  4 + 2 + 1)]
    public void TestAclEqualityIntegers(AclMask left, int right)
    {
        Assert.That(right, Is.EqualTo((int) left));
    }
    
    [TestCase((byte)AclMask.None, false)]
    [TestCase((byte)AclMask.Read, true)]
    [TestCase((byte)AclMask.Write, false)]
    [TestCase((byte)AclMask.Execute, false)]
    [TestCase((byte)AclMask.ReadWrite, true)]
    [TestCase((byte)AclMask.ReadExecute, true)]
    [TestCase((byte)AclMask.WriteExecute, false)]
    [TestCase((byte)AclMask.Full, true)]
    public void TestReadPermissions(AclMask mask, bool canRead)
    {
        Assert.That(mask & AclMask.Read, canRead 
            ? Is.EqualTo(AclMask.Read) 
            : Is.Not.EqualTo(AclMask.Read));
    }
    
    [TestCase((byte)AclMask.None, false)]
    [TestCase((byte)AclMask.Read, false)]
    [TestCase((byte)AclMask.Write, true)]
    [TestCase((byte)AclMask.Execute, false)]
    [TestCase((byte)AclMask.ReadWrite, true)]
    [TestCase((byte)AclMask.ReadExecute, false)]
    [TestCase((byte)AclMask.WriteExecute, true)]
    [TestCase((byte)AclMask.Full, true)]
    public void TestWritePermissions(AclMask mask, bool canWrite)
    {
        Assert.That(mask & AclMask.Write, canWrite 
            ? Is.EqualTo(AclMask.Write) 
            : Is.Not.EqualTo(AclMask.Write));
    }
    
    [TestCase((byte)AclMask.None, false)]
    [TestCase((byte)AclMask.Read, false)]
    [TestCase((byte)AclMask.Write, false)]
    [TestCase((byte)AclMask.Execute, true)]
    [TestCase((byte)AclMask.ReadWrite, false)]
    [TestCase((byte)AclMask.ReadExecute, true)]
    [TestCase((byte)AclMask.WriteExecute, true)]
    [TestCase((byte)AclMask.Full, true)]
    public void TestExecutePermissions(AclMask mask, bool canWrite)
    {
        Assert.That(mask & AclMask.Execute, canWrite 
            ? Is.EqualTo(AclMask.Execute) 
            : Is.Not.EqualTo(AclMask.Execute));
    }
}
