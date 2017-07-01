namespace PitFortressTests.Correctness
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CorrectnessMin3Players : BaseTestClass
    {

        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessMin3Players_WithoutPlayers_ShouldThrowCorrectException()
        {
            this.PitFortressCollection.Min3PlayersByScore();
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessMin3Players_WithLessThan3Players_ShouldThrowCorrectException()
        {
            this.PitFortressCollection.AddPlayer("Acho", 5);
            this.PitFortressCollection.AddPlayer("Becho", 5);

            this.PitFortressCollection.Min3PlayersByScore();
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessMin3Players_WithValidPlayers_ShouldReturnExactly3Players()
        {
            this.PitFortressCollection.AddPlayer("Cecho", 5);
            this.PitFortressCollection.AddPlayer("Decho", 5);
            this.PitFortressCollection.AddPlayer("Echo", 5);
            this.PitFortressCollection.AddPlayer("Jecho", 6);
            this.PitFortressCollection.AddPlayer("Zecho", 7);

            var players = this.PitFortressCollection.Min3PlayersByScore();

            Assert.AreEqual(3, players.Count(), "Incorrect amount of players returned!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessMin3Players_WithMultipleValidPlayers_ShouldReturnCorrectPlayers()
        {
            this.PitFortressCollection.AddPlayer("Mr.MMS", 0);
            this.PitFortressCollection.AddPlayer("Memory", 1);
            this.PitFortressCollection.AddPlayer("Limit", 2);
            this.PitFortressCollection.AddPlayer("Stack", 3);
            this.PitFortressCollection.AddPlayer("Overflow", 4);
            this.PitFortressCollection.AddPlayer("Memory Limit Memory Limit Stack Overflow", 5);

            var botPlayers = this.PitFortressCollection.Min3PlayersByScore().ToList();

            Assert.AreEqual(botPlayers[0].Name, "Limit", "Names did not match!");
            Assert.AreEqual(botPlayers[0].Radius, 2, "Radius did not match!");
            Assert.AreEqual(botPlayers[0].Score, 0, "Score did not match!");

            Assert.AreEqual(botPlayers[1].Name, "Memory", "Names did not match!");
            Assert.AreEqual(botPlayers[1].Radius, 1, "Radius did not match!");
            Assert.AreEqual(botPlayers[1].Score, 0, "Score did not match!");

            Assert.AreEqual(botPlayers[2].Name, "Memory Limit Memory Limit Stack Overflow", "Names did not match!");
            Assert.AreEqual(botPlayers[2].Radius, 5, "Radius did not match!");
            Assert.AreEqual(botPlayers[2].Score, 0, "Score did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessMin3Players_WithThreeeValidPlayers_ShouldReturnCorrectlyRankedPlayers()
        {
            this.PitFortressCollection.AddPlayer("A", 10);
            this.PitFortressCollection.AddPlayer("B", 30);
            this.PitFortressCollection.AddPlayer("C", 20);

            var botPlayers = this.PitFortressCollection.Min3PlayersByScore().ToList();

            Assert.AreEqual(botPlayers[0].Name, "A", "Names did not match!");
            Assert.AreEqual(botPlayers[0].Radius, 10, "Radius did not match!");
            Assert.AreEqual(botPlayers[0].Score, 0, "Score did not match!");

            Assert.AreEqual(botPlayers[1].Name, "B", "Names did not match!");
            Assert.AreEqual(botPlayers[1].Radius, 30, "Radius did not match!");
            Assert.AreEqual(botPlayers[1].Score, 0, "Score did not match!");

            Assert.AreEqual(botPlayers[2].Name, "C", "Names did not match!");
            Assert.AreEqual(botPlayers[2].Radius, 20, "Radius did not match!");
            Assert.AreEqual(botPlayers[2].Score, 0, "Score did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessMin3Players_AfterAPlayerKillsAMinion_ShouldReturnCorrectlyRankedPlayers()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 20);
            this.PitFortressCollection.AddPlayer("Gosho", 30);
            this.PitFortressCollection.AddPlayer("StamatLoveca", 10);

            this.PitFortressCollection.AddMinion(5);

            this.PitFortressCollection.SetMine("StamatLoveca", 10, 1, 100);

            this.PitFortressCollection.PlayTurn();

            var botPlayers = this.PitFortressCollection.Min3PlayersByScore().ToList();

            Assert.AreEqual(botPlayers[0].Name, "Gosho", "Names did not match!");
            Assert.AreEqual(botPlayers[0].Radius, 30, "Radius did not match!");
            Assert.AreEqual(botPlayers[0].Score, 0, "Score did not match!");

            Assert.AreEqual(botPlayers[1].Name, "Pesho", "Names did not match!");
            Assert.AreEqual(botPlayers[1].Radius, 20, "Radius did not match!");
            Assert.AreEqual(botPlayers[1].Score, 0, "Score did not match!");

            Assert.AreEqual(botPlayers[2].Name, "StamatLoveca", "Names did not match!");
            Assert.AreEqual(botPlayers[2].Radius, 10, "Radius did not match!");
            Assert.AreEqual(botPlayers[2].Score, 1, "Score did not match!");


        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessMin3Players_AfterMulitplePlayersKillingMultipleMinions_ShouldReturnCorrectlyRankedPlayers()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 0);
            this.PitFortressCollection.AddPlayer("Gosho", 0);
            this.PitFortressCollection.AddPlayer("StamatLoveca", 0);
            this.PitFortressCollection.AddPlayer("BoikoSnaiperista", 0);
            this.PitFortressCollection.AddPlayer("JichkaTokoprovoda", 0);

            this.PitFortressCollection.AddMinion(5);
            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(15);
            this.PitFortressCollection.AddMinion(20);

            this.PitFortressCollection.SetMine("JichkaTokoprovoda", 15, 1, 100);
            this.PitFortressCollection.SetMine("BoikoSnaiperista", 10, 1, 100);
            this.PitFortressCollection.SetMine("BoikoSnaiperista", 20, 1, 100);
            this.PitFortressCollection.SetMine("StamatLoveca", 5, 1, 100);

            this.PitFortressCollection.PlayTurn();

            var topPlayers = this.PitFortressCollection.Min3PlayersByScore().ToList();

            Assert.AreEqual(topPlayers[0].Name, "Gosho", "Names did not match!");
            Assert.AreEqual(topPlayers[0].Radius, 0, "Radius did not match!");
            Assert.AreEqual(topPlayers[0].Score, 0, "Score did not match!");

            Assert.AreEqual(topPlayers[1].Name, "Pesho", "Names did not match!");
            Assert.AreEqual(topPlayers[1].Radius, 0, "Radius did not match!");
            Assert.AreEqual(topPlayers[1].Score, 0, "Score did not match!");

            Assert.AreEqual(topPlayers[2].Name, "JichkaTokoprovoda", "Names did not match!");
            Assert.AreEqual(topPlayers[2].Radius, 0, "Radius did not match!");
            Assert.AreEqual(topPlayers[2].Score, 1, "Score did not match!");
        }
    }
}
