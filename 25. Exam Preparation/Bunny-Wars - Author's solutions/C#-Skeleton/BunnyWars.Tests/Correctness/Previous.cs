namespace BunnyWars.Tests.Correctness
{
    using System;
    using System.Linq;
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Previous : BaseTestClass
    {
        [TestCategory("Correctness")]
        [ExpectedException(typeof (ArgumentException))]
        [TestMethod]
        public void Previous_WithANonExistantBunny_ShouldThrowException()
        {
            //Act
            this.BunnyWarCollection.Next("Nasko");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void Previous_WithASingleRoom_ShouldStayInTheSameRoom()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(1);
            this.BunnyWarCollection.AddBunny("Nasko", 3, 1);

            //Act
            this.BunnyWarCollection.Previous("Nasko");
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(3);
            var bunny = bunnies.FirstOrDefault();

            //Assert
            Assert.AreEqual(1, bunny.RoomId, "Room Id was incorrect!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void Previous_WithMultipleRooms_ShouldMoveBunnyToNextRoom()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(1);
            this.BunnyWarCollection.AddRoom(5);
            this.BunnyWarCollection.AddBunny("Nasko", 3, 5);

            //Act
            this.BunnyWarCollection.Previous("Nasko");
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(3);
            var bunny = bunnies.FirstOrDefault();

            //Assert
            Assert.AreEqual(1, bunny.RoomId, "Room Id was incorrect!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void Previous_WithBunnyInTheLastRoom_ShouldMoveBunnyToTheFirstRoom()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(-20);
            this.BunnyWarCollection.AddRoom(1);
            this.BunnyWarCollection.AddRoom(5);
            this.BunnyWarCollection.AddRoom(20);
            this.BunnyWarCollection.AddRoom(100);
            this.BunnyWarCollection.AddRoom(666);
            this.BunnyWarCollection.AddBunny("Nasko", 2, -20);

            //Act
            this.BunnyWarCollection.Previous("Nasko");
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(2);
            var bunny = bunnies.FirstOrDefault();

            //Assert
            Assert.AreEqual(666, bunny.RoomId, "Room Id was incorrect!");
        }
    }
}
