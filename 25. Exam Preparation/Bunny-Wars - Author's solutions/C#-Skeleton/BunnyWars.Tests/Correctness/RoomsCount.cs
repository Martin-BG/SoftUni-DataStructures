namespace BunnyWars.Tests.Correctness
{
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RoomsCount : BaseTestClass
    {
        [TestCategory("Correctness")]
        [TestMethod]
        public void RoomsCount_WithANewCollection_ShouldBeZero()
        {
            //Assert
            Assert.AreEqual(0, this.BunnyWarCollection.RoomCount, "Collection constructed with an incorrect rooms count!");
        }
    }
}
