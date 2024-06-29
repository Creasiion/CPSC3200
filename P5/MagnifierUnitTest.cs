namespace MagnifierUnitTest;
using MagnifierClass;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ValidInitializingTest()
    {   //Three initializations; negative values, no input, positive interger (expected) values
        Magnifier negVals = new Magnifier(-47, -83, -925);
        Magnifier noVals = new Magnifier();
        Magnifier posVals = new Magnifier(608, 10, 5);
        Assert.AreEqual(1,negVals.scaledSize());
        Assert.AreEqual(1,noVals.scaledSize());
        Assert.AreEqual(6080,posVals.scaledSize());
    }

    [Test]
    public void CheckIsAlive()
    {
        Magnifier posVals = new Magnifier(608, 10, 5);
        posVals.scaledSize();
        posVals.scaledSize();
        posVals.scaledSize();
        posVals.scaledSize();
        posVals.scaledSize();
        Assert.AreEqual(0,posVals.scaledSize());
        Assert.AreEqual(false,posVals.getIsAlive());
    }

    [Test]
    public void checkReset()
    {
        Magnifier posVals = new Magnifier(608, 10, 5);
        posVals.scaledSize();
        posVals.scaledSize();
        posVals.scaledSize();
        posVals.scaledSize();
        posVals.scaledSize();
        Assert.AreEqual(0,posVals.scaledSize());
        Assert.AreEqual(false,posVals.getIsAlive());
        posVals.reset();
        Assert.AreEqual(true,posVals.getIsAlive());
    }

    [Test]
    public void DeadAndReset()
    {
        Magnifier Obj = new Magnifier();
        Obj.scaledSize();
        Obj.scaledSize();
        Obj.scaledSize();
        Obj.scaledSize();
        Obj.scaledSize();
        Assert.AreEqual(0,Obj.scaledSize());
        Assert.AreEqual(false,Obj.getIsAlive());
        Obj.reset();
        Assert.AreEqual(true,Obj.getIsAlive());
        Assert.AreEqual(1,Obj.scaledSize());
        Assert.AreEqual(1,Obj.scaledSize());
        Assert.AreEqual(1,Obj.scaledSize());
        Assert.AreEqual(1,Obj.scaledSize());
        Assert.AreEqual(1,Obj.scaledSize());
        Assert.AreEqual(0,Obj.scaledSize());
    }
}