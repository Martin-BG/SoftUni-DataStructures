namespace BunnyWars.Tests.Correctness
{
    using System;
    using System.Linq;
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddBunny : BaseTestClass
    {
        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddBunny_ToANonExistingRoom_ShouldThrowException()
        {
            //Act
            this.BunnyWarCollection.AddBunny("Ivo", 0, 15);
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddBunny_WithAnExistingName_ShouldThrowException()
        {
            //Arrange
            var roomId = 15;
            this.BunnyWarCollection.AddRoom(roomId);
            this.BunnyWarCollection.AddBunny("Nasko", 0, 15);

            //Act
            this.BunnyWarCollection.AddBunny("Nasko", 0, 15);
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void AddBunny_WithANegativeTeamId_ShouldThrowException()
        {
            //Arrange
            var roomId = 15;
            this.BunnyWarCollection.AddRoom(roomId);

            //Act
            this.BunnyWarCollection.AddBunny("Zuek1", -1, 15);
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void AddBunny_WithAnIncorrectTeamId_ShouldThrowException()
        {
            //Arrange
            var roomId = 15;
            this.BunnyWarCollection.AddRoom(roomId);

            //Act
            this.BunnyWarCollection.AddBunny("Zuek1", 5, 15);
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void AddBunny_WithNoBunnies_ShouldIncreaseBunnyCountByOnce()
        {
            //Arrange
            var roomId = 15;
            this.BunnyWarCollection.AddRoom(roomId);
            Assert.AreEqual(0,this.BunnyWarCollection.BunnyCount,"Collection created with an incorrect amount of bunnies!");

            //Act
            this.BunnyWarCollection.AddBunny("Nasko", 0, 15);
            
            //Assert
            Assert.AreEqual(1,this.BunnyWarCollection.BunnyCount,"Incorrect amount of bunnies added!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void AddBunny_WithExistingBunnies_ShouldIncreaseBunnyCountByOne()
        {
            //Arrange
            var roomId = 15;
            this.BunnyWarCollection.AddRoom(roomId);
            this.BunnyWarCollection.AddBunny("Nasko", 0, 15);
            this.BunnyWarCollection.AddBunny("Dancho", 1, 15);
            this.BunnyWarCollection.AddBunny("Ivo", 2, 15);
            this.BunnyWarCollection.AddBunny("Edo", 3, 15);
            this.BunnyWarCollection.AddBunny("Royal", 4, 15);
            this.BunnyWarCollection.AddBunny("Trifon", 0, 15);
            Assert.AreEqual(6,this.BunnyWarCollection.BunnyCount,"Incorrect amount of bunnies!");

            //Act
            this.BunnyWarCollection.AddBunny("Nakov", 1, 15);

            //Assert
            Assert.AreEqual(7, this.BunnyWarCollection.BunnyCount, "Incorrect amount of bunnies added!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void AddBunny_WithNoBunnies_ShouldAddBunnyWithCorrectParameters()
        {
            //Arrange
            var roomId = 15;
            this.BunnyWarCollection.AddRoom(roomId);
            
            //Act
            this.BunnyWarCollection.AddBunny("Nasko", 3, 15);
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(3);
            var bunny = bunnies.FirstOrDefault();

            //Assert
            Assert.AreEqual("Nasko", bunny.Name, "Name did not match!");
            Assert.AreEqual(3, bunny.Team, "Team did not match!");
            Assert.AreEqual(15, bunny.RoomId, "Room Id did not match!");
            Assert.AreEqual(100, bunny.Health, "Health did not match!");
            Assert.AreEqual(0, bunny.Score, "Score did not match!");
        }
    }
}
