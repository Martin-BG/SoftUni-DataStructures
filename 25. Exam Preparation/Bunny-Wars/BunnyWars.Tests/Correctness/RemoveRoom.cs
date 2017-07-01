namespace BunnyWars.Tests.Correctness
{
    using System;
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveRoom : BaseTestClass
    {
        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void RemoveRoom_WithNonExistantRoom_ShouldThrowException()
        {
            //Arrange
            var roomId = 1;

            //Act
            this.BunnyWarCollection.Remove(roomId);
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void RemoveRoom_WithASingleRoom_ShouldReduceRoomsCountByOne()
        {
            //Arrange
            var roomId = 1;
            this.BunnyWarCollection.AddRoom(roomId);
            Assert.AreEqual(1, this.BunnyWarCollection.RoomCount, "Incorrect amount of rooms added!");

            //Act
            this.BunnyWarCollection.Remove(roomId);

            //Assert
            Assert.AreEqual(0, this.BunnyWarCollection.RoomCount, "Incorrect ammount of rooms removed!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void RemoveRoom_WithAMultipleRooms_ShouldReduceRoomsCountByOne()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(-1);
            this.BunnyWarCollection.AddRoom(0);
            this.BunnyWarCollection.AddRoom(1);
            this.BunnyWarCollection.AddRoom(2);
            Assert.AreEqual(4, this.BunnyWarCollection.RoomCount, "Incorrect amount of rooms added!");

            //Act
            this.BunnyWarCollection.Remove(1);

            //Assert
            Assert.AreEqual(3, this.BunnyWarCollection.RoomCount, "Incorrect ammount of rooms removed!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void RemoveRoom_WithASingleRoomWithNoBunniesInside_ShouldNotChangeBunniesCount()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(-10);
            Assert.AreEqual(0, this.BunnyWarCollection.BunnyCount, "Structure is constructed with incorrect amount of bunnies!");

            //Act
            this.BunnyWarCollection.Remove(-10);

            //Assert
            Assert.AreEqual(0, this.BunnyWarCollection.BunnyCount, "Incorrect ammount of bunnies after removal!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void RemoveRoom_WithASingleRoomWithOneBunny_ShouldReduceBunniesCountByOne()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(5);
            this.BunnyWarCollection.AddBunny("Nasko",1,5);
            Assert.AreEqual(1, this.BunnyWarCollection.BunnyCount, "Incorrect ammount of bunnies added!");

            //Act
            this.BunnyWarCollection.Remove(5);

            //Assert
            Assert.AreEqual(0, this.BunnyWarCollection.BunnyCount, "Incorrect ammount of bunnies removed!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void RemoveRoom_WithASingleRoomWithMultipleBunnies_ShouldReduceBunniesCountCorrectly()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(5);
            this.BunnyWarCollection.AddBunny("Nasko", 0, 5);
            this.BunnyWarCollection.AddBunny("Dancho", 1, 5);
            this.BunnyWarCollection.AddBunny("Trifon", 2, 5);
            this.BunnyWarCollection.AddBunny("Royal", 3, 5);
            this.BunnyWarCollection.AddBunny("Edo", 4, 5);
            Assert.AreEqual(5, this.BunnyWarCollection.BunnyCount, "Incorrect ammount of bunnies added!");

            //Act
            this.BunnyWarCollection.Remove(5);

            //Assert
            Assert.AreEqual(0, this.BunnyWarCollection.BunnyCount, "Incorrect ammount of bunnies removed!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void RemoveRoom_WithMultipleRoomsWithMultipleBunnies_ShouldReduceBunniesCountCorrectly()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(5);
            this.BunnyWarCollection.AddRoom(100);
            this.BunnyWarCollection.AddRoom(-1000);
            this.BunnyWarCollection.AddRoom(257444);
            this.BunnyWarCollection.AddBunny("Nasko", 0, 257444);
            this.BunnyWarCollection.AddBunny("Dancho", 1, -1000);
            this.BunnyWarCollection.AddBunny("Trifon", 2, 5);
            this.BunnyWarCollection.AddBunny("Royal", 3, 100);
            this.BunnyWarCollection.AddBunny("Ivo", 4, 257444);
            this.BunnyWarCollection.AddBunny("Nakov", 0, 5);
            this.BunnyWarCollection.AddBunny("Angel", 1, 100);
            this.BunnyWarCollection.AddBunny("Joro", 2, -1000);
            this.BunnyWarCollection.AddBunny("Alex", 3, 257444);
            this.BunnyWarCollection.AddBunny("Ivan", 4, 5);
            Assert.AreEqual(10, this.BunnyWarCollection.BunnyCount, "Incorrect ammount of bunnies added!");

            //Act
            this.BunnyWarCollection.Remove(257444);

            //Assert
            Assert.AreEqual(7, this.BunnyWarCollection.BunnyCount, "Incorrect ammount of bunnies removed!");
        }
    }
}
