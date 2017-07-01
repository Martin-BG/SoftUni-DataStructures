namespace BunnyWars.Tests.Correctness
{
    using System;
    using System.Linq;
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Detonate : BaseTestClass
    {
        [TestCategory("Correctness")]
        [ExpectedException(typeof (ArgumentException))]
        [TestMethod]
        public void Detonate_WithANonExistantBunny_ShouldThrowException()
        {
            //Act
            this.BunnyWarCollection.Detonate("Nasko");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void Detonate_WithAValidBunny_ShouldNotHarmHimself()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(10);
            this.BunnyWarCollection.AddBunny("Nasko", 2, 10);

            //Act
            this.BunnyWarCollection.Detonate("Nasko");
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(2);

            //Assert
            foreach (var bunny in bunnies)
            {
                Assert.AreEqual(100, bunny.Health);
            }
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void Detonate_WithBunniesFromTheSameTeam_ShouldNotHarmThem()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(10);
            this.BunnyWarCollection.AddBunny("Nasko",2,10);
            this.BunnyWarCollection.AddBunny("Dancho", 2, 10);
            this.BunnyWarCollection.AddBunny("Royal", 2, 10);
            this.BunnyWarCollection.AddBunny("Edo", 2, 10);
            this.BunnyWarCollection.AddBunny("Trifon", 2, 10);

            //Act
            this.BunnyWarCollection.Detonate("Nasko");
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(2);

            //Assert
            foreach (var bunny in bunnies)
            {
                Assert.AreEqual(100,bunny.Health);
            }
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void Detonate_WithBunniesInMultipleRooms_ShouldNotHarmBunniesInOtherRooms()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(10);
            this.BunnyWarCollection.AddRoom(11);
            this.BunnyWarCollection.AddRoom(12);
            this.BunnyWarCollection.AddRoom(13);
            this.BunnyWarCollection.AddBunny("Nasko", 2, 10);
            this.BunnyWarCollection.AddBunny("Dancho", 0, 10);
            this.BunnyWarCollection.AddBunny("Royal", 2, 11);
            this.BunnyWarCollection.AddBunny("Edo", 3, 12);
            this.BunnyWarCollection.AddBunny("Trifon", 4, 13);

            //Act
            this.BunnyWarCollection.Detonate("Dancho");
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(2);
            var bunnies2 = this.BunnyWarCollection.ListBunniesByTeam(3);
            var bunnies3 = this.BunnyWarCollection.ListBunniesByTeam(4);

            //Assert
            foreach (var bunny in bunnies)
            {
                if (bunny.Name != "Nasko")
                {
                    Assert.AreEqual(100, bunny.Health);
                }
                else
                {
                    Assert.AreEqual(70, bunny.Health);
                }      
            }

            foreach (var bunny in bunnies2)
            {
                Assert.AreEqual(100, bunny.Health);
            }

            foreach (var bunny in bunnies3)
            {
                Assert.AreEqual(100, bunny.Health);
            }
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void Detonate_WithBunniesFromOtherTeamsInTheSameRoom_ShouldReduceHealthOfBunniesFromOtherTeams()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(10);
            this.BunnyWarCollection.AddBunny("Nasko", 0, 10);
            this.BunnyWarCollection.AddBunny("Dancho", 1, 10);
            this.BunnyWarCollection.AddBunny("Royal", 2, 10);
            this.BunnyWarCollection.AddBunny("Edo", 3, 10);
            this.BunnyWarCollection.AddBunny("Trifon", 4, 10);

            //Act
            this.BunnyWarCollection.Detonate("Nasko");
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(1);
            var bunnies2 = this.BunnyWarCollection.ListBunniesByTeam(2);
            var bunnies3 = this.BunnyWarCollection.ListBunniesByTeam(3);
            var bunnies4 = this.BunnyWarCollection.ListBunniesByTeam(4);

            //Assert
            foreach (var bunny in bunnies)
            {
                Assert.AreEqual(70, bunny.Health);
            }

            foreach (var bunny in bunnies2)
            {
                Assert.AreEqual(70, bunny.Health);
            }

            foreach (var bunny in bunnies3)
            {
                Assert.AreEqual(70, bunny.Health);
            }

            foreach (var bunny in bunnies4)
            {
                Assert.AreEqual(70, bunny.Health);
            }
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void Detonate_WithMultipleBunnies_WhenABunnyFallsToZeroOrLessHealth_ShouldRemoveBunny()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(10);
            this.BunnyWarCollection.AddRoom(11);
            this.BunnyWarCollection.AddRoom(7);
            this.BunnyWarCollection.AddBunny("Nasko", 0, 10);
            this.BunnyWarCollection.AddBunny("Dancho", 1, 10);
            this.BunnyWarCollection.AddBunny("Royal", 2, 10);
            this.BunnyWarCollection.AddBunny("Edo", 3, 11);
            this.BunnyWarCollection.AddBunny("Trifon", 2, 7);
            Assert.AreEqual(5, this.BunnyWarCollection.BunnyCount, "Incorrect ammount of bunnies added!");

            //Act
            this.BunnyWarCollection.Detonate("Nasko");
            this.BunnyWarCollection.Detonate("Nasko");
            this.BunnyWarCollection.Detonate("Nasko");
            this.BunnyWarCollection.Detonate("Nasko");

            //Assert
            Assert.AreEqual(3, this.BunnyWarCollection.BunnyCount, "Incorrect ammount of bunnies removed!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void Detonate_WithMultipleBunnies_WhenABunnyFallsToZeroOrLessHealth_ShouldRemoveCorrectBunny()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(10);
            this.BunnyWarCollection.AddRoom(11);
            this.BunnyWarCollection.AddRoom(7);
            this.BunnyWarCollection.AddBunny("Nasko", 0, 10);
            this.BunnyWarCollection.AddBunny("Dancho", 1, 10);
            this.BunnyWarCollection.AddBunny("Royal", 2, 10);
            this.BunnyWarCollection.AddBunny("Edo", 3, 11);
            this.BunnyWarCollection.AddBunny("Trifon", 2, 7);

            //Act
            this.BunnyWarCollection.Detonate("Nasko");
            this.BunnyWarCollection.Detonate("Nasko");
            this.BunnyWarCollection.Detonate("Nasko");
            this.BunnyWarCollection.Detonate("Nasko");
            var trifon = this.BunnyWarCollection.ListBunniesByTeam(2).FirstOrDefault();
            var edo = this.BunnyWarCollection.ListBunniesByTeam(3).FirstOrDefault();

            //Assert
            Assert.AreEqual("Trifon",trifon.Name,"Name did not match!");
            Assert.AreEqual(100, trifon.Health, "Health did not match!");
            Assert.AreEqual(0, trifon.Score, "Score did not match!");
            Assert.AreEqual(7, trifon.RoomId, "Room Id did not match!");
            Assert.AreEqual(2, trifon.Team, "Team did not match!");

            Assert.AreEqual("Edo", edo.Name, "Name did not match!");
            Assert.AreEqual(100, edo.Health, "Health did not match!");
            Assert.AreEqual(0, edo.Score, "Score did not match!");
            Assert.AreEqual(11, edo.RoomId, "Room Id did not match!");
            Assert.AreEqual(3, edo.Team, "Team did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void Detonate_WhenKillingABunny_ShouldShouldIncreaseDetonatedBunnysScore()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(10);
            this.BunnyWarCollection.AddBunny("Nasko", 0, 10);
            this.BunnyWarCollection.AddBunny("Dancho", 1, 10);
            this.BunnyWarCollection.AddBunny("Royal", 2, 10);

            //Act
            this.BunnyWarCollection.Detonate("Nasko");
            this.BunnyWarCollection.Detonate("Nasko");
            this.BunnyWarCollection.Detonate("Nasko");
            this.BunnyWarCollection.Detonate("Nasko");
            var nasko = this.BunnyWarCollection.ListBunniesByTeam(0).FirstOrDefault();

            //Assert
            Assert.AreEqual(2,nasko.Score,"Score did not match!");
        }
    }
}
