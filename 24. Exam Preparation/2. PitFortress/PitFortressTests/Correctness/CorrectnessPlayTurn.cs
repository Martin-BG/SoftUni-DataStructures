using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitFortressTests.Correctness
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CorrectnessPlayTurn : BaseTestClass
    {
        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithOneSkipWithNoMines_ShouldNotChangeExistingObjectsCount()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);
            this.PitFortressCollection.AddPlayer("Gosho", 2);
            this.PitFortressCollection.AddPlayer("Stamat", 3);

            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);
            this.PitFortressCollection.AddMinion(40);
            this.PitFortressCollection.AddMinion(50);

            this.PitFortressCollection.PlayTurn();

            var topPlayers = this.PitFortressCollection.Top3PlayersByScore().ToList();
            var minions = this.PitFortressCollection.ReportMinions().ToList();
            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(3, topPlayers.Count, "Player Count did not match!");
            Assert.AreEqual(5, minions.Count, "Minion Count did not match!");
            Assert.AreEqual(0, mines.Count, "Mine Count did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithMultipleSkipsWithNoMines_ShouldNotChangeExistingObjectsCount()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);
            this.PitFortressCollection.AddPlayer("Gosho", 2);
            this.PitFortressCollection.AddPlayer("Stamat", 3);

            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);
            this.PitFortressCollection.AddMinion(40);
            this.PitFortressCollection.AddMinion(50);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var topPlayers = this.PitFortressCollection.Top3PlayersByScore().ToList();
            var minions = this.PitFortressCollection.ReportMinions().ToList();
            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(3, topPlayers.Count, "Player Count did not match!");
            Assert.AreEqual(5, minions.Count, "Minion Count did not match!");
            Assert.AreEqual(0, mines.Count, "Mine Count did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithOneSkipWithNoMines_ShouldNotChangeExistingObjects()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);
            this.PitFortressCollection.AddPlayer("Gosho", 2);
            this.PitFortressCollection.AddPlayer("Stamat", 3);

            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);

            this.PitFortressCollection.PlayTurn();

            var topPlayers = this.PitFortressCollection.Top3PlayersByScore().ToList();
            var minions = this.PitFortressCollection.ReportMinions().ToList();
            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(0, topPlayers[0].Score, "Player's Score did not match!");
            Assert.AreEqual(0, topPlayers[1].Score, "Player's Score did not match!");
            Assert.AreEqual(0, topPlayers[2].Score, "Player's Score did not match!");

            Assert.AreEqual(100, minions[0].Health, "Minion's Health did not match!");
            Assert.AreEqual(100, minions[1].Health, "Minion's Health did not match!");
            Assert.AreEqual(100, minions[2].Health, "Minion's Health did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithMultipleSkipsWithNoMines_ShouldNotChangeExistingObjects()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);
            this.PitFortressCollection.AddPlayer("Gosho", 2);
            this.PitFortressCollection.AddPlayer("Stamat", 3);

            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var topPlayers = this.PitFortressCollection.Top3PlayersByScore().ToList();
            var minions = this.PitFortressCollection.ReportMinions().ToList();
            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(0, topPlayers[0].Score, "Player's Score did not match!");
            Assert.AreEqual(0, topPlayers[1].Score, "Player's Score did not match!");
            Assert.AreEqual(0, topPlayers[2].Score, "Player's Score did not match!");

            Assert.AreEqual(100, minions[0].Health, "Minion's Health did not match!");
            Assert.AreEqual(100, minions[1].Health, "Minion's Health did not match!");
            Assert.AreEqual(100, minions[2].Health, "Minion's Health did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithMultipleSkipsWithASingleMineWithNoMinionsInRange_ShouldDeleteMineAfterBlowingUp()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);

            this.PitFortressCollection.SetMine("Pesho", 100, 4, 100);

            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(1, mines.Count, "Mine Count did not match!");

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(0, mines.Count, "Mine Count did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithMultipleSkipsWithASingleMineWithNoMinionsInRange_ShouldBlowMineWithoutKillingMinions()
        {
            this.PitFortressCollection.AddPlayer("Stamat", 3);

            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);
            this.PitFortressCollection.AddMinion(40);
            this.PitFortressCollection.AddMinion(50);

            this.PitFortressCollection.SetMine("Stamat", 100, 4, 100);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(5, minions.Count, "Minion Count did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithMultipleSkipsWithASingleMineWithNoMinionsInRange_SholdNotDamageMinions()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);
            this.PitFortressCollection.AddPlayer("Gosho", 2);
            this.PitFortressCollection.AddPlayer("Stamat", 3);

            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);

            this.PitFortressCollection.SetMine("Stamat", 100, 4, 100);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(100, minions[0].Health, "Minion's Health did not match!");
            Assert.AreEqual(100, minions[1].Health, "Minion's Health did not match!");
            Assert.AreEqual(100, minions[2].Health, "Minion's Health did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithMultipleSkipsWithAMineDamagingAMinion_ShouldBlowMineAndDamageMinion()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);
            this.PitFortressCollection.AddPlayer("Gosho", 2);
            this.PitFortressCollection.AddPlayer("Stamat", 3);

            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);

            this.PitFortressCollection.SetMine("Stamat", 31, 4, 99);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(10, minions[0].XCoordinate, "Minion's Coordinate did not match!");
            Assert.AreEqual(1, minions[0].Id, "Minion's Id did not match!");
            Assert.AreEqual(100, minions[0].Health, "Minion's Health did not match!");

            Assert.AreEqual(20, minions[1].XCoordinate, "Minion's Coordinate did not match!");
            Assert.AreEqual(2, minions[1].Id, "Minion's Id did not match!");
            Assert.AreEqual(100, minions[1].Health, "Minion's Health did not match!");

            Assert.AreEqual(30, minions[2].XCoordinate, "Minion's Coordinate did not match!");
            Assert.AreEqual(3, minions[2].Id, "Minion's Id did not match!");
            Assert.AreEqual(1, minions[2].Health, "Minion's Health did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithMultipleSkipsWithAMineDamagingAMinion_ShouldNotChangePlayersScore()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);
            this.PitFortressCollection.AddPlayer("Gosho", 2);
            this.PitFortressCollection.AddPlayer("Stamat", 3);

            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);

            this.PitFortressCollection.SetMine("Stamat", 31, 4, 99);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var topPlayers = this.PitFortressCollection.Top3PlayersByScore().ToList();
            var minions = this.PitFortressCollection.ReportMinions().ToList();
            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(0, topPlayers[0].Score, "Player's Score did not match!");
            Assert.AreEqual(0, topPlayers[1].Score, "Player's Score did not match!");
            Assert.AreEqual(0, topPlayers[2].Score, "Player's Score did not match!");
        }


        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithAMineKillingAMinion_ShouldDeleteCorrectMinion()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);
            this.PitFortressCollection.AddPlayer("Gosho", 2);
            this.PitFortressCollection.AddPlayer("Stamat", 3);

            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);

            this.PitFortressCollection.SetMine("Stamat", 31, 2, 100);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(2, minions.Count, "Minion count did not match!");

            Assert.AreEqual(10, minions[0].XCoordinate, "Minion's Coordinate did not match!");
            Assert.AreEqual(1, minions[0].Id, "Minion's Id did not match!");
            Assert.AreEqual(100, minions[0].Health, "Minion's Health did not match!");

            Assert.AreEqual(20, minions[1].XCoordinate, "Minion's Coordinate did not match!");
            Assert.AreEqual(2, minions[1].Id, "Minion's Id did not match!");
            Assert.AreEqual(100, minions[1].Health, "Minion's Health did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithKillingAMinionWith2Mines_ShouldDeleteCorrectMinion()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);
            this.PitFortressCollection.AddPlayer("Gosho", 2);
            this.PitFortressCollection.AddPlayer("Stamat", 3);

            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);

            this.PitFortressCollection.SetMine("Stamat", 31, 2, 50);
            this.PitFortressCollection.SetMine("Gosho", 30, 3, 50);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(2, minions.Count, "Minion count did not match!");

            Assert.AreEqual(10, minions[0].XCoordinate, "Minion's Coordinate did not match!");
            Assert.AreEqual(1, minions[0].Id, "Minion's Id did not match!");
            Assert.AreEqual(100, minions[0].Health, "Minion's Health did not match!");

            Assert.AreEqual(20, minions[1].XCoordinate, "Minion's Coordinate did not match!");
            Assert.AreEqual(2, minions[1].Id, "Minion's Id did not match!");
            Assert.AreEqual(100, minions[1].Health, "Minion's Health did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithAMineKillingAMinion_ShouldChangePlayerScore()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);
            this.PitFortressCollection.AddPlayer("Gosho", 2);
            this.PitFortressCollection.AddPlayer("Stamat", 3);

            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);

            this.PitFortressCollection.SetMine("Stamat", 31, 4, 100);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var topPlayers = this.PitFortressCollection.Top3PlayersByScore().ToList();

            Assert.AreEqual(1, topPlayers[0].Score, "Player's Score did not match!");
            Assert.AreEqual("Stamat", topPlayers[0].Name, "Player's Name did not match!");
            Assert.AreEqual(3, topPlayers[0].Radius, "Player's Radius did not match!");

            Assert.AreEqual(0, topPlayers[1].Score, "Player's Score did not match!");
            Assert.AreEqual("Pesho", topPlayers[1].Name, "Player's Name did not match!");
            Assert.AreEqual(1, topPlayers[1].Radius, "Player's Radius did not match!");

            Assert.AreEqual(0, topPlayers[2].Score, "Player's Score did not match!");
            Assert.AreEqual("Gosho", topPlayers[2].Name, "Player's Name did not match!");
            Assert.AreEqual(2, topPlayers[2].Radius, "Player's Radius did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithKillingAMinionWith2Mines_ShouldRaiseKillingMinesPlayesScore()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);
            this.PitFortressCollection.AddPlayer("Gosho", 2);
            this.PitFortressCollection.AddPlayer("Stamat", 3);

            this.PitFortressCollection.AddMinion(10);
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);

            this.PitFortressCollection.SetMine("Stamat", 31, 4, 80);
            this.PitFortressCollection.SetMine("Pesho", 31, 4, 20);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var topPlayers = this.PitFortressCollection.Top3PlayersByScore().ToList();

            Assert.AreEqual(1, topPlayers[0].Score, "Player's Score did not match!");
            Assert.AreEqual("Pesho", topPlayers[0].Name, "Player's Name did not match!");
            Assert.AreEqual(1, topPlayers[0].Radius, "Player's Radius did not match!");

            Assert.AreEqual(0, topPlayers[1].Score, "Player's Score did not match!");
            Assert.AreEqual("Stamat", topPlayers[1].Name, "Player's Name did not match!");
            Assert.AreEqual(3, topPlayers[1].Radius, "Player's Radius did not match!");

            Assert.AreEqual(0, topPlayers[2].Score, "Player's Score did not match!");
            Assert.AreEqual("Gosho", topPlayers[2].Name, "Player's Name did not match!");
            Assert.AreEqual(2, topPlayers[2].Radius, "Player's Radius did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithAMinionOnTheEdgeOfMinesRange_ShouldHitMinion()
        {
            this.PitFortressCollection.AddPlayer("Dimcho", 5);
            this.PitFortressCollection.AddPlayer("Domcho", 6);
            this.PitFortressCollection.AddPlayer("Dumcho", 7);

            this.PitFortressCollection.AddMinion(0);
            this.PitFortressCollection.AddMinion(100);
            this.PitFortressCollection.AddMinion(200);

            this.PitFortressCollection.SetMine("Dumcho", 107, 3, 66);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(100, minions[1].XCoordinate, "Minion's Coordinate did not match!");
            Assert.AreEqual(2, minions[1].Id, "Minion's Id did not match!");
            Assert.AreEqual(34, minions[1].Health, "Minion's Health did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithMultipleMinionsInMinesRange_ShouldHitAllOfThem()
        {
            this.PitFortressCollection.AddPlayer("Domcho", 100);

            this.PitFortressCollection.AddMinion(0);
            this.PitFortressCollection.AddMinion(100);
            this.PitFortressCollection.AddMinion(200);
            this.PitFortressCollection.AddMinion(201);

            this.PitFortressCollection.SetMine("Domcho", 100, 5, 11);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(0, minions[0].XCoordinate, "Minion's Coordinate did not match!");
            Assert.AreEqual(1, minions[0].Id, "Minion's Id did not match!");
            Assert.AreEqual(89, minions[0].Health, "Minion's Health did not match!");

            Assert.AreEqual(100, minions[1].XCoordinate, "Minion's Coordinate did not match!");
            Assert.AreEqual(2, minions[1].Id, "Minion's Id did not match!");
            Assert.AreEqual(89, minions[1].Health, "Minion's Health did not match!");

            Assert.AreEqual(200, minions[2].XCoordinate, "Minion's Coordinate did not match!");
            Assert.AreEqual(3, minions[2].Id, "Minion's Id did not match!");
            Assert.AreEqual(89, minions[2].Health, "Minion's Health did not match!");

            Assert.AreEqual(201, minions[3].XCoordinate, "Minion's Coordinate did not match!");
            Assert.AreEqual(4, minions[3].Id, "Minion's Id did not match!");
            Assert.AreEqual(100, minions[3].Health, "Minion's Health did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithMultipleMinesWithDifferentDelays_ShouldBlowThemAtCorrectTurns()
        {
            this.PitFortressCollection.AddPlayer("Dimcho", 10);
            this.PitFortressCollection.AddPlayer("Domcho", 20);
            this.PitFortressCollection.AddPlayer("Dumcho", 30);

            this.PitFortressCollection.AddMinion(0);
            this.PitFortressCollection.AddMinion(100);
            this.PitFortressCollection.AddMinion(110);
            this.PitFortressCollection.AddMinion(120);

            this.PitFortressCollection.SetMine("Dumcho", 135, 1, 10);
            this.PitFortressCollection.SetMine("Domcho", 110, 4, 20);
            this.PitFortressCollection.SetMine("Dimcho", 99, 6, 30);

            var mines = this.PitFortressCollection.GetMines().ToList();
            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(3, mines.Count, "Mine Count did not match!");

            Assert.AreEqual(100, minions[0].Health, "Minion's Health did not match!");
            Assert.AreEqual(100, minions[1].Health, "Minion's Health did not match!");
            Assert.AreEqual(100, minions[2].Health, "Minion's Health did not match!");
            Assert.AreEqual(100, minions[3].Health, "Minion's Health did not match!");

            //Pass first turn
            this.PitFortressCollection.PlayTurn();

            mines = this.PitFortressCollection.GetMines().ToList();
            minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(2, mines.Count, "Mine Count did not match!");
            Assert.AreEqual(100, minions[0].Health, "Minion's Health did not match!");
            Assert.AreEqual(100, minions[1].Health, "Minion's Health did not match!");
            Assert.AreEqual(90, minions[2].Health, "Minion's Health did not match!");
            Assert.AreEqual(90, minions[3].Health, "Minion's Health did not match!");

            //Pass second and third turn
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            mines = this.PitFortressCollection.GetMines().ToList();
            minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(2, mines.Count, "Mine Count did not match!");
            Assert.AreEqual(100, minions[0].Health, "Minion's Health did not match!");
            Assert.AreEqual(100, minions[1].Health, "Minion's Health did not match!");
            Assert.AreEqual(90, minions[2].Health, "Minion's Health did not match!");
            Assert.AreEqual(90, minions[3].Health, "Minion's Health did not match!");

            //Pass fourth turn
            this.PitFortressCollection.PlayTurn();

            mines = this.PitFortressCollection.GetMines().ToList();
            minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(1, mines.Count, "Mine Count did not match!");
            Assert.AreEqual(100, minions[0].Health, "Minion's Health did not match!");
            Assert.AreEqual(80, minions[1].Health, "Minion's Health did not match!");
            Assert.AreEqual(70, minions[2].Health, "Minion's Health did not match!");
            Assert.AreEqual(70, minions[3].Health, "Minion's Health did not match!");

            //Pass fifth turn
            this.PitFortressCollection.PlayTurn();

            mines = this.PitFortressCollection.GetMines().ToList();
            minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(1, mines.Count, "Mine Count did not match!");
            Assert.AreEqual(100, minions[0].Health, "Minion's Health did not match!");
            Assert.AreEqual(80, minions[1].Health, "Minion's Health did not match!");
            Assert.AreEqual(70, minions[2].Health, "Minion's Health did not match!");
            Assert.AreEqual(70, minions[3].Health, "Minion's Health did not match!");

            //Pass sixth turn
            this.PitFortressCollection.PlayTurn();

            mines = this.PitFortressCollection.GetMines().ToList();
            minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(0, mines.Count, "Mine Count did not match!");
            Assert.AreEqual(100, minions[0].Health, "Minion's Health did not match!");
            Assert.AreEqual(50, minions[1].Health, "Minion's Health did not match!");
            Assert.AreEqual(70, minions[2].Health, "Minion's Health did not match!");
            Assert.AreEqual(70, minions[3].Health, "Minion's Health did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithASingleSkip_ShouldCorrectlyReduceMineDelays()
        {
            this.PitFortressCollection.AddPlayer("X", 10);
            this.PitFortressCollection.AddPlayer("Y", 20);
            this.PitFortressCollection.AddPlayer("Z", 30);

            this.PitFortressCollection.SetMine("Y", 100, 10, 2);
            this.PitFortressCollection.SetMine("Z", 100, 3, 2);
            this.PitFortressCollection.SetMine("Z", 100, 21, 2);
            this.PitFortressCollection.SetMine("X", 100, 10000, 2);

            this.PitFortressCollection.PlayTurn();

            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(2, mines[0].Delay, "Mine's Delay did not match!");
            Assert.AreEqual(9, mines[1].Delay, "Mine's Delay did not match!");
            Assert.AreEqual(20, mines[2].Delay, "Mine's Delay did not match!");
            Assert.AreEqual(9999, mines[3].Delay, "Mine's Delay did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithMultipleSkips_ShouldCorrectlyReduceMineDelays()
        {
            this.PitFortressCollection.AddPlayer("X", 10);
            this.PitFortressCollection.AddPlayer("Y", 20);
            this.PitFortressCollection.AddPlayer("Z", 30);

            this.PitFortressCollection.SetMine("Y", 100, 17, 2);
            this.PitFortressCollection.SetMine("Z", 100, 27, 2);
            this.PitFortressCollection.SetMine("X", 100, 1007, 2);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(10, mines[0].Delay, "Mine's Delay did not match!");
            Assert.AreEqual(20, mines[1].Delay, "Mine's Delay did not match!");
            Assert.AreEqual(1000, mines[2].Delay, "Mine's Delay did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithTwoMinesWithSameDelay_ShouldExplodeTheOneWithSmallerIdFirst()
        {
            this.PitFortressCollection.AddPlayer("X", 10);
            this.PitFortressCollection.AddPlayer("Y", 20);
            this.PitFortressCollection.AddPlayer("Z", 30);

            this.PitFortressCollection.AddMinion(100);

            this.PitFortressCollection.SetMine("Z", 100, 3, 100);
            this.PitFortressCollection.SetMine("Y", 100, 3, 100);

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            var topPlayers = this.PitFortressCollection.Top3PlayersByScore().ToList();

            Assert.AreEqual(1, topPlayers[0].Score, "Player's Score did not match!");
            Assert.AreEqual("Z", topPlayers[0].Name, "Player's Name did not match!");
            Assert.AreEqual(30, topPlayers[0].Radius, "Player's Radius did not match!");

            Assert.AreEqual(0, topPlayers[1].Score, "Player's Score did not match!");
            Assert.AreEqual("Y", topPlayers[1].Name, "Player's Name did not match!");
            Assert.AreEqual(20, topPlayers[1].Radius, "Player's Radius did not match!");


            Assert.AreEqual(0, topPlayers[2].Score, "Player's Score did not match!");
            Assert.AreEqual("X", topPlayers[2].Name, "Player's Name did not match!");
            Assert.AreEqual(10, topPlayers[2].Radius, "Player's Radius did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithMultipleMinesWithSameDelay_ShouldExplodeAll()
        {
            this.PitFortressCollection.AddPlayer("X", 10);
            this.PitFortressCollection.AddPlayer("Y", 20);
            this.PitFortressCollection.AddPlayer("Z", 30);

            this.PitFortressCollection.AddMinion(100);

            this.PitFortressCollection.SetMine("Z", 100, 3, 100);
            this.PitFortressCollection.SetMine("Z", 50, 3, 50);
            this.PitFortressCollection.SetMine("Y", 100, 3, 100);

            var mines = this.PitFortressCollection.GetMines().ToList();
            Assert.AreEqual(3, mines.Count, "Mine Count did not match.");

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(0,mines.Count,"Mine Count did not match.");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessPlayTurn_WithAMineWith0Damage_ShouldNotDamageMinion()
        {
            this.PitFortressCollection.AddPlayer("Z", 30);

            this.PitFortressCollection.AddMinion(100);

            this.PitFortressCollection.SetMine("Z", 100, 3, 0);

            var minions = this.PitFortressCollection.ReportMinions().ToList();
            Assert.AreEqual(100, minions[0].Health, "Minion Health did not match!");

            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();
            this.PitFortressCollection.PlayTurn();

            minions = this.PitFortressCollection.ReportMinions().ToList();
            Assert.AreEqual(100, minions[0].Health, "Minion Health did not match!");
        }
    }
}
