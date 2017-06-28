
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PitFortressTests.Correctness
{
    [TestClass]
    public class CorrectnessAddPlayer : BaseTestClass
    {
        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessAddPlayer_WithDuplicateName_ShouldThrowCorrectException()
        {
            this.PitFortressCollection.AddPlayer("Mr.MMS", 0);
            this.PitFortressCollection.AddPlayer("Mr.MMS", 0);
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessAddPlayer_WithIncorrectRadius_ShouldThrowCorrectException()
        {
            this.PitFortressCollection.AddPlayer("Mr.MMS2", -10);
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessAddPlayer_WithValidPlayerWithAnEmptyCollection_ShouldIncreasePlayerCounter()
        {
            this.PitFortressCollection.AddPlayer("Mr.MMS3",0);

            Assert.AreEqual(this.PitFortressCollection.PlayersCount, 1,"Incorrect player count.");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessAddPlayer_WithExistingPlayers_ShouldIncreasePlayerCounterCorrectly()
        {
            this.PitFortressCollection.AddPlayer("Kircho", 2);
            this.PitFortressCollection.AddPlayer("Pencho", 0);
            this.PitFortressCollection.AddPlayer("Jichka", 3);
            this.PitFortressCollection.AddPlayer("Sashka", 4);
            this.PitFortressCollection.AddPlayer("Ginka", 22);
            this.PitFortressCollection.AddPlayer("Radomir", 87);

            Assert.AreEqual(this.PitFortressCollection.PlayersCount, 6, "Incorrect player count.");

            this.PitFortressCollection.AddPlayer("Joro", 117);

            Assert.AreEqual(this.PitFortressCollection.PlayersCount, 7, "Incorrect player count.");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessAddPlayer_WithMultipleValidPlayers_ShouldIncreaseCounterCorrectly()
        {
            this.PitFortressCollection.AddPlayer("Mr.MMS", 0);
            this.PitFortressCollection.AddPlayer("Memory", 1);
            this.PitFortressCollection.AddPlayer("Limit", 2);
            this.PitFortressCollection.AddPlayer("Stack", 3);
            this.PitFortressCollection.AddPlayer("Overflow", 4);

            Assert.AreEqual(this.PitFortressCollection.PlayersCount, 5, "Incorrect player count.");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessAddPlayer_WithMultipleValidPlayers_ShouldAddCorrectPlayers()
        {
            this.PitFortressCollection.AddPlayer("Limit", 2);
            this.PitFortressCollection.AddPlayer("Stack", 3);
            this.PitFortressCollection.AddPlayer("Overflow", 4);

            var topPlayers = this.PitFortressCollection.Top3PlayersByScore().ToList();

            Assert.AreEqual(topPlayers[0].Name, "Stack", "Names did not match!");
            Assert.AreEqual(topPlayers[0].Radius, 3, "Radius did not match!");
            Assert.AreEqual(topPlayers[0].Score, 0, "Score did not match!");

            Assert.AreEqual(topPlayers[1].Name, "Overflow", "Names did not match!");
            Assert.AreEqual(topPlayers[1].Radius, 4, "Radius did not match!");
            Assert.AreEqual(topPlayers[1].Score, 0, "Score did not match!");

            Assert.AreEqual(topPlayers[2].Name, "Limit", "Names did not match!");
            Assert.AreEqual(topPlayers[2].Radius, 2, "Radius did not match!");
            Assert.AreEqual(topPlayers[2].Score, 0, "Score did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessAddPlayer_WithMultipleValidPlayers2_ShouldAddCorrectPlayers()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 13);
            this.PitFortressCollection.AddPlayer("Gosho", 21);
            this.PitFortressCollection.AddPlayer("Stamat", 2);

            var topPlayers = this.PitFortressCollection.Top3PlayersByScore().ToList();

            Assert.AreEqual(topPlayers[0].Name, "Stamat", "Names did not match!");
            Assert.AreEqual(topPlayers[0].Radius, 2, "Radius did not match!");
            Assert.AreEqual(topPlayers[0].Score, 0, "Score did not match!");

            Assert.AreEqual(topPlayers[1].Name, "Pesho", "Names did not match!");
            Assert.AreEqual(topPlayers[1].Radius, 13, "Radius did not match!");
            Assert.AreEqual(topPlayers[1].Score, 0, "Score did not match!");

            Assert.AreEqual(topPlayers[2].Name, "Gosho", "Names did not match!");
            Assert.AreEqual(topPlayers[2].Radius, 21, "Radius did not match!");
            Assert.AreEqual(topPlayers[2].Score, 0, "Score did not match!");

            this.PitFortressCollection.AddPlayer("Z", 11);

            topPlayers = this.PitFortressCollection.Top3PlayersByScore().ToList();

            Assert.AreEqual(topPlayers[0].Name, "Z", "Names did not match!");
            Assert.AreEqual(topPlayers[0].Radius, 11, "Radius did not match!");
            Assert.AreEqual(topPlayers[0].Score, 0, "Score did not match!");
        }
    }
}
