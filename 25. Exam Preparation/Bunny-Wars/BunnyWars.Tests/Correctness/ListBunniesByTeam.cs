namespace BunnyWars.Tests.Correctness
{
    using System;
    using System.Linq;
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListBunniesByTeam : BaseTestClass
    {
        [TestCategory("Correctness")]
        [ExpectedException(typeof (IndexOutOfRangeException))]
        [TestMethod]
        public void ListBunniesByTeam_WithANegativeTeam_ShouldThrowException()
        {
            //Act
            this.BunnyWarCollection.ListBunniesByTeam(-555);
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void ListBunniesByTeam_WithAnIncorrectTeam_ShouldThrowException()
        {
            //Act
            this.BunnyWarCollection.ListBunniesByTeam(5);
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void ListBunniesByTeam_WithASingleTeam_ShouldReturnCorrectAmmounOfBunnies()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(2);
            this.BunnyWarCollection.AddBunny("Nasko",4,2);
            this.BunnyWarCollection.AddBunny("Edo", 4, 2);
            this.BunnyWarCollection.AddBunny("Royal", 4, 2);
            this.BunnyWarCollection.AddBunny("Dancho", 4, 2);
            this.BunnyWarCollection.AddBunny("Trifon", 4, 2);

            //Act
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(4);

            //Assert
            Assert.AreEqual(5,bunnies.Count(),"Incorrect amount of bunnies returned!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void ListBunniesByTeam_WithMultipleTeams_ShouldReturnCorrectAmmounOfBunnies()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(2);
            this.BunnyWarCollection.AddBunny("Nasko", 1, 2);
            this.BunnyWarCollection.AddBunny("Edo", 2, 2);
            this.BunnyWarCollection.AddBunny("Royal", 1, 2);
            this.BunnyWarCollection.AddBunny("Dancho", 4, 2);
            this.BunnyWarCollection.AddBunny("Trifon", 4, 2);

            //Act
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(1);

            //Assert
            Assert.AreEqual(2, bunnies.Count(), "Incorrect amount of bunnies returned!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void ListBunniesByTeam_ShouldReturnCorrectlySortedBunnies()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(2);
            this.BunnyWarCollection.AddRoom(-1);
            this.BunnyWarCollection.AddRoom(-7);
            this.BunnyWarCollection.AddBunny("Nasko", 4, -1);
            this.BunnyWarCollection.AddBunny("Edo", 4, 2);
            this.BunnyWarCollection.AddBunny("Royal", 4, -7);
            this.BunnyWarCollection.AddBunny("Dancho", 4, 2);
            this.BunnyWarCollection.AddBunny("Trifon", 3, -1);

            //Act
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(4);

            //Assert
            var enumerator = bunnies.GetEnumerator();
            enumerator.MoveNext();
            var current = enumerator.Current;
            Assert.AreEqual("Royal", current.Name, "Name did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Nasko", current.Name, "Name did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Edo", current.Name, "Name did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Dancho", current.Name, "Name did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void ListBunniesByTeam_WithASingleRoomWithASingleTeam_ShouldReturnCorrectBunnies()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(2);
            this.BunnyWarCollection.AddBunny("Nasko", 4, 2);
            this.BunnyWarCollection.AddBunny("Edo", 4, 2);
            this.BunnyWarCollection.AddBunny("Royal", 4, 2);
            this.BunnyWarCollection.AddBunny("Dancho", 4, 2);
            this.BunnyWarCollection.AddBunny("Trifon", 4, 2);

            //Act
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(4);

            //Assert
            var enumerator = bunnies.GetEnumerator();
            enumerator.MoveNext();
            var current = enumerator.Current;
            Assert.AreEqual("Trifon", current.Name, "Name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(4, current.Team, "Team did not match!");
            Assert.AreEqual(2, current.RoomId, "Room Id did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Royal", current.Name, "Name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(4, current.Team, "Team did not match!");
            Assert.AreEqual(2, current.RoomId, "Room Id did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Nasko", current.Name, "Name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(4, current.Team, "Team did not match!");
            Assert.AreEqual(2, current.RoomId, "Room Id did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Edo", current.Name, "Name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(4, current.Team, "Team did not match!");
            Assert.AreEqual(2, current.RoomId, "Room Id did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Dancho", current.Name, "Name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(4, current.Team, "Team did not match!");
            Assert.AreEqual(2, current.RoomId, "Room Id did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void ListBunniesByTeam_WithASingleRoomWithMultipleTeams_ShouldReturnCorrectBunnies()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(-50);
            this.BunnyWarCollection.AddBunny("Nasko", 1, -50);
            this.BunnyWarCollection.AddBunny("Edo", 2, -50);
            this.BunnyWarCollection.AddBunny("Royal", 1, -50);
            this.BunnyWarCollection.AddBunny("Dancho", 4, -50);
            this.BunnyWarCollection.AddBunny("Trifon", 4, -50);

            //Act
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(1);

            //Assert
            var enumerator = bunnies.GetEnumerator();
            enumerator.MoveNext();
            var current = enumerator.Current;
            Assert.AreEqual("Royal", current.Name, "Name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(1, current.Team, "Team did not match!");
            Assert.AreEqual(-50, current.RoomId, "Room Id did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Nasko", current.Name, "Name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(1, current.Team, "Team did not match!");
            Assert.AreEqual(-50, current.RoomId, "Room Id did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void ListBunniesByTeam_WithMultipleTeamsInMultipleRooms_ShouldReturnCorrectBunnies()
        {
            //Arrange
            this.BunnyWarCollection.AddRoom(-99);
            this.BunnyWarCollection.AddRoom(200);
            this.BunnyWarCollection.AddRoom(1337);
            this.BunnyWarCollection.AddBunny("Nasko", 3, 200);
            this.BunnyWarCollection.AddBunny("Edo", 2, 1337);
            this.BunnyWarCollection.AddBunny("Royal", 4, -99);
            this.BunnyWarCollection.AddBunny("Dancho", 1, -99);
            this.BunnyWarCollection.AddBunny("Trifon", 3, 1337);
            this.BunnyWarCollection.AddBunny("Ivo", 3, 200);
            this.BunnyWarCollection.AddBunny("Joro", 3, -99);
            //Act
            var bunnies = this.BunnyWarCollection.ListBunniesByTeam(3);

            //Assert
            var enumerator = bunnies.GetEnumerator();
            enumerator.MoveNext();
            var current = enumerator.Current;
            Assert.AreEqual("Trifon", current.Name, "Name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(3, current.Team, "Team did not match!");
            Assert.AreEqual(1337, current.RoomId, "Room Id did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Nasko", current.Name, "Name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(3, current.Team, "Team did not match!");
            Assert.AreEqual(200, current.RoomId, "Room Id did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Joro", current.Name, "Name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(3, current.Team, "Team did not match!");
            Assert.AreEqual(-99, current.RoomId, "Room Id did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Ivo", current.Name, "Name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(3, current.Team, "Team did not match!");
            Assert.AreEqual(200, current.RoomId, "Room Id did not match!");        
        }
    }
}
