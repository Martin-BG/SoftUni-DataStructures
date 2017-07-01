namespace BunnyWars.Tests.Correctness
{
    using System.Linq;
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListBunniesBySuffix : BaseTestClass
    {
        [TestCategory("Correctness")]
        [TestMethod]
        public void ListBunniesBySuffix_WithEmptyString_ShouldReturnAllBunnies()
        {
            //Arange
            this.BunnyWarCollection.AddRoom(88);
            this.BunnyWarCollection.AddBunny("b",0,88);
            this.BunnyWarCollection.AddBunny("e", 0, 88);
            this.BunnyWarCollection.AddBunny("a", 0, 88);
            this.BunnyWarCollection.AddBunny("c", 0, 88);
            this.BunnyWarCollection.AddBunny("d", 0, 88);
            this.BunnyWarCollection.AddBunny("Nasko", 0, 88);

            //Act
            var bunnies = this.BunnyWarCollection.ListBunniesBySuffix("");

            //Assert
            Assert.AreEqual(6,bunnies.Count(),"Incorrect amount of bunnies returned!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void ListBunniesBySuffix_WithMultipleBunniesInMultipleRoomsAndTeamsWithAValidSuffix_ShouldReturnCorrectAmountOfBunnies()
        {
            //Arange
            this.BunnyWarCollection.AddRoom(20);
            this.BunnyWarCollection.AddRoom(21);
            this.BunnyWarCollection.AddRoom(22);
            this.BunnyWarCollection.AddBunny("Nasko", 1, 22);
            this.BunnyWarCollection.AddBunny("Dancho", 3, 20);
            this.BunnyWarCollection.AddBunny("Royal", 1, 21);
            this.BunnyWarCollection.AddBunny("Edo", 4, 22);
            this.BunnyWarCollection.AddBunny("Vitkurz", 4, 22);
            this.BunnyWarCollection.AddBunny("Trifon", 2, 21);
            this.BunnyWarCollection.AddBunny("Ivo", 3, 21);

            //Act
            var bunnies = this.BunnyWarCollection.ListBunniesBySuffix("o");

            //Assert
            Assert.AreEqual(4, bunnies.Count(), "Incorrect amount of bunnies returned!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void ListBunniesBySuffix_WithNoBunnies_ShouldReturnAnEmptyCollection()
        {
            //Act
            var bunnies = this.BunnyWarCollection.ListBunniesBySuffix("");

            //Assert
            Assert.AreEqual(0, bunnies.Count(), "Incorrect amount of bunnies returned!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void ListBunniesBySuffix_WithMultipleBunniesWithoutGivenSuffix_ShouldReturnAnEmptyCollection()
        {
            //Arange
            this.BunnyWarCollection.AddRoom(88);
            this.BunnyWarCollection.AddRoom(89);
            this.BunnyWarCollection.AddRoom(90);
            this.BunnyWarCollection.AddBunny("Nasko", 0, 89);
            this.BunnyWarCollection.AddBunny("Edo", 1, 89);
            this.BunnyWarCollection.AddBunny("Dancho", 1, 88);
            this.BunnyWarCollection.AddBunny("Zaik1", 0, 90);
            this.BunnyWarCollection.AddBunny("Nasklo", 1, 89);
            this.BunnyWarCollection.AddBunny("Edu", 0, 88);
            this.BunnyWarCollection.AddBunny("RoYaL", 1, 90);

            //Act
            var bunnies = this.BunnyWarCollection.ListBunniesBySuffix("AmiSega");

            //Assert
            Assert.AreEqual(0, bunnies.Count(), "Incorrect amount of bunnies returned!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void ListBunniesBySuffix_WithEmptyString_ShouldReturnBunniesCorrectlySorted()
        {
            //Arange
            this.BunnyWarCollection.AddRoom(88);
            this.BunnyWarCollection.AddBunny("Zaik1", 0, 88);
            this.BunnyWarCollection.AddBunny("", 0, 88);
            this.BunnyWarCollection.AddBunny("a", 0, 88);
            this.BunnyWarCollection.AddBunny("WTFNAMETOOBIGCANTFIT", 0, 88);
            this.BunnyWarCollection.AddBunny("ZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZz", 0, 88);
            this.BunnyWarCollection.AddBunny("Nasko", 0, 88);

            //Act
            var bunnies = this.BunnyWarCollection.ListBunniesBySuffix("");

            //Assert
            var enumerator = bunnies.GetEnumerator();
            Assert.AreEqual(6, bunnies.Count());

            enumerator.MoveNext();
            var current = enumerator.Current;
            Assert.AreEqual("", current.Name, "Expected name did not match!");          
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Zaik1", current.Name, "Expected name did not match!");    
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("WTFNAMETOOBIGCANTFIT", current.Name, "Expected name did not match!");  
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("a", current.Name, "Expected name did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("Nasko", current.Name, "Expected name did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("ZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZz", current.Name, "Expected name did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void ListBunniesBySuffix_WithMultipleBunniesInMultipleRoomsAndTeams_ShouldReturnAllBunniesWithGivenSuffix()
        {
            //Arange
            this.BunnyWarCollection.AddRoom(111);
            this.BunnyWarCollection.AddRoom(222);
            this.BunnyWarCollection.AddRoom(333);
            this.BunnyWarCollection.AddRoom(444);
            this.BunnyWarCollection.AddRoom(-111);          
            this.BunnyWarCollection.AddBunny("aapen", 0, -111);         
            this.BunnyWarCollection.AddBunny("bapen", 2, 222);
            this.BunnyWarCollection.AddBunny("Nasko", 4, 111);
            this.BunnyWarCollection.AddBunny("bpen", 0, 444);
            this.BunnyWarCollection.AddBunny("Tpen", 3, 222);
            this.BunnyWarCollection.AddBunny("Edo", 2, 111);
            this.BunnyWarCollection.AddBunny("Trifon", 1, 444);
            this.BunnyWarCollection.AddBunny("Royal", 1, -111);
            this.BunnyWarCollection.AddBunny("apen", 4, 333);
            this.BunnyWarCollection.AddBunny("Dancho", 4, 222);

            //Act
            var bunnies = this.BunnyWarCollection.ListBunniesBySuffix("pen");

            
            //Assert
            var enumerator = bunnies.GetEnumerator();
            Assert.AreEqual(5, bunnies.Count());

            enumerator.MoveNext();
            var current = enumerator.Current;
            Assert.AreEqual("Tpen", current.Name, "Name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(3, current.Team, "Team did not match!");
            Assert.AreEqual(222, current.RoomId, "Room Id did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("apen", current.Name, "Expected name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(4, current.Team, "Team did not match!");
            Assert.AreEqual(333, current.RoomId, "Room Id did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("aapen", current.Name, "Expected name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(0, current.Team, "Team did not match!");
            Assert.AreEqual(-111, current.RoomId, "Room Id did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("bapen", current.Name, "Expected name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(2, current.Team, "Team did not match!");
            Assert.AreEqual(222, current.RoomId, "Room Id did not match!");
            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("bpen", current.Name, "Expected name did not match!");
            Assert.AreEqual(100, current.Health, "Health did not match!");
            Assert.AreEqual(0, current.Score, "Score did not match!");
            Assert.AreEqual(0, current.Team, "Team did not match!");
            Assert.AreEqual(444, current.RoomId, "Room Id did not match!");
        }
    }
}
