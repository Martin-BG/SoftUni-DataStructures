namespace BunnyWars.Tests.Correctness
{
    using System;
    using System.Linq;
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddRoom : BaseTestClass
    {
        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddRoom_WithAnExistingNumber_ShouldThrowException()
        {
            //Arrange
            var roomId = 15;

            //Act
            this.BunnyWarCollection.AddRoom(roomId);
            this.BunnyWarCollection.AddRoom(roomId);
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void AddRoom_WithNoRooms_ShouldAddRoomOnce()
        {
            //Arrange
            var roomId = 15;

            //Act
            this.BunnyWarCollection.AddRoom(roomId);
            
            //Assert
            Assert.AreEqual(1, this.BunnyWarCollection.RoomCount,"Incorrect amount of rooms added!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void AddRoom_WithNegativeId_ShouldAddRoom()
        {
            //Arrange
            var roomId = -10;

            //Act
            this.BunnyWarCollection.AddRoom(roomId);

            //Assert
            Assert.AreEqual(1, this.BunnyWarCollection.RoomCount, "Incorrect amount of rooms added!");
        }
    }
}
