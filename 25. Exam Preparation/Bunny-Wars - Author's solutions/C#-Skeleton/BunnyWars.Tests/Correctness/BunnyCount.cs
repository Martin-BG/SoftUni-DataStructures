namespace BunnyWars.Tests.Correctness
{
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BunnyCount : BaseTestClass
    {
        [TestCategory("Correctness")]
        [TestMethod]
        public void BunnyCount_WithANewCollection_ShouldBeZero()
        {
            //Assert
            Assert.AreEqual(0,this.BunnyWarCollection.BunnyCount,"Collection constructed with an incorrect bunny count!");
        }
    }
}
