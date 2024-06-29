namespace TestTMagnifier;
using TMagnifierClass;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ValidInitializingTest()
    {
        //five initializations; negative values, no input, transformer, accelerate, viral
        TMagnifier negVals = new TMagnifier(-1,-1,-1,-1,-1);
        TMagnifier defaultVals = new TMagnifier();
        TMagnifier transObj = new TMagnifier(1,108,10,5,2048);
        TMagnifier accelObj = new TMagnifier(2,108,10,5,2048);
        TMagnifier viralObj = new TMagnifier(3,108,10,5,2048);
        Assert.AreEqual(true,negVals.getIsActive());
        Assert.AreEqual(true,defaultVals.getIsActive());
        Assert.AreEqual(true,transObj.getIsActive());
        Assert.AreEqual(true,accelObj.getIsActive());
        Assert.AreEqual(true,viralObj.getIsActive());
    }

    [Test]
    public void testingOutputValueFxn()
    {
        TMagnifier transObj = new TMagnifier(1,108,10,5,2048);
        Assert.AreEqual(2053,transObj.outputValue(5));
        Assert.AreEqual(2043,transObj.outputValue(5));
        TMagnifier accelObj = new TMagnifier(2,108,10,5,2048);
        Assert.AreEqual(2049,accelObj.outputValue(5));
        Assert.AreEqual(2050,accelObj.outputValue(5));
        TMagnifier viralObj = new TMagnifier(3,108,10,5,2048);
        Assert.AreEqual(10240,viralObj.outputValue(5));
        Assert.AreEqual(3,viralObj.outputValue(5));
    }

    [Test]
    public void testingProcessGuessFxn()
    {
        TMagnifier transObj = new TMagnifier(1,108,10,5,2048);
        Assert.AreEqual(0,transObj.outputValue(2047));
        Assert.AreEqual(2,transObj.outputValue(2049));
        Assert.AreEqual(1,transObj.outputValue(2048));
        Assert.AreEqual(false, transObj.getIsActive());
    }
    
    [Test]
    public void testingGetScaledSizeFxn()
    {
        TMagnifier transObj = new TMagnifier(1,108,10,5,2048);
        Assert.AreEqual(1080,transObj.getScaledSize());
        Assert.AreEqual(1080,transObj.getScaledSize());
        Assert.AreEqual(1080,transObj.getScaledSize());
        Assert.AreEqual(1080,transObj.getScaledSize());
        Assert.AreEqual(1080,transObj.getScaledSize());
        Assert.AreEqual(0,transObj.getScaledSize());
        Assert.AreEqual(false, transObj.getIsActive());
    }

    [Test]
    public void testingResetFxn()
    {
        TMagnifier transObj = new TMagnifier(1,108,10,5,2048);
        Assert.AreEqual(1080,transObj.getScaledSize());
        Assert.AreEqual(1080,transObj.getScaledSize());
        Assert.AreEqual(1080,transObj.getScaledSize());
        Assert.AreEqual(1080,transObj.getScaledSize());
        Assert.AreEqual(1080,transObj.getScaledSize());
        Assert.AreEqual(0,transObj.getScaledSize());
        Assert.AreEqual(false, transObj.getIsActive());
        transObj.reset();
        Assert.AreEqual(true, transObj.getIsActive());
        Assert.AreEqual(1080,transObj.getScaledSize());
    }
}