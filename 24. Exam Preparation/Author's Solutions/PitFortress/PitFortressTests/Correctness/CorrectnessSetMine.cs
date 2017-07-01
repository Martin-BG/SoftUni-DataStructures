using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitFortressTests.Correctness
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CorrectnessSetMine : BaseTestClass
    {
        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessSetMine_WithNonExistingPlayer_ShouldThrowCorrectException()
        {
            this.PitFortressCollection.SetMine("Mr.MMS", 0, 1, 50);
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessSetMine_WithNegativeCoordinate_ShouldThrowCorrectException()
        {
            this.PitFortressCollection.AddPlayer("Mr.MMs", 10);
            this.PitFortressCollection.SetMine("Mr.MMS", -20, 1, 50);
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessSetMine_WithInvalidCoordinate_ShouldThrowCorrectException()
        {
            this.PitFortressCollection.AddPlayer("Mr.MMs", 10);
            this.PitFortressCollection.SetMine("Mr.MMS", 2000000, 1, 50);
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessSetMine_WithNegativeDelay_ShouldThrowCorrectException()
        {
            this.PitFortressCollection.AddPlayer("Mr.MMs", 10);
            this.PitFortressCollection.SetMine("Mr.MMS", 0, -1, 50);
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessSetMine_WithIncorrectDelay_ShouldThrowCorrectException()
        {
            this.PitFortressCollection.AddPlayer("Mr.MMs", 10);
            this.PitFortressCollection.SetMine("Mr.MMS", 0, 20000, 50);
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessSetMine_WithNegativeDamage_ShouldThrowCorrectException()
        {
            this.PitFortressCollection.AddPlayer("Mr.MMs", 10);
            this.PitFortressCollection.SetMine("Mr.MMS", 0, 5, -5);
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessSetMine_WithInvalidDamage_ShouldThrowCorrectException()
        {
            this.PitFortressCollection.AddPlayer("Mr.MMs", 10);
            this.PitFortressCollection.SetMine("Mr.MMS", 0, 5, 101);
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessSetMine_WithValidMine_ShouldIncreaseMinesCount()
        {
            this.PitFortressCollection.AddPlayer("Jichkata", 10);
            this.PitFortressCollection.SetMine("Jichkata", 13, 5, 89);

            Assert.AreEqual(this.PitFortressCollection.MinesCount,1,"Mines Count did not match!");

        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessSetMine_WithExistingMines_ShouldIncreaseMinesCountCorrectly()
        {
            this.PitFortressCollection.AddPlayer("Jichkata", 5);
            this.PitFortressCollection.AddPlayer("Pesho", 10);

            this.PitFortressCollection.SetMine("Pesho", 13, 1, 20);
            this.PitFortressCollection.SetMine("Jichkata", 1, 1, 15);
            this.PitFortressCollection.SetMine("Pesho", 20, 2, 25);
            this.PitFortressCollection.SetMine("Pesho", 25, 3, 40);

            Assert.AreEqual(this.PitFortressCollection.MinesCount, 4, "Mines Count did not match!");

            this.PitFortressCollection.SetMine("Jichkata", 117, 13, 99);

            Assert.AreEqual(this.PitFortressCollection.MinesCount, 5, "Mines Count did not match!");

        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessSetMine_WithValidMine_ShouldAddCorrectMine()
        {
            this.PitFortressCollection.AddPlayer("Jichkata", 10);
            this.PitFortressCollection.SetMine("Jichkata", 13, 5, 89);

            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(mines[0].Id, 1, "Mine Id did not match!");
            Assert.AreEqual(mines[0].XCoordinate, 13, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[0].Delay, 5, "Mine Delay did not match!");
            Assert.AreEqual(mines[0].Damage, 89, "Mine Damage did not match!");
            Assert.AreEqual(mines[0].Player.Name, "Jichkata", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[0].Player.Radius, 10, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[0].Player.Score, 0, "Mine's Player's Score did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessSetMine_MultipleMinesWithMultiplePlayers_ShouldAddCorrectMines()
        {
            this.PitFortressCollection.AddPlayer("Pencho", 1);
            this.PitFortressCollection.AddPlayer("Oncho", 2);
            this.PitFortressCollection.AddPlayer("Gencho", 3);

            this.PitFortressCollection.SetMine("Gencho", 999996, 96, 96);
            this.PitFortressCollection.SetMine("Pencho", 999997, 97, 97);
            this.PitFortressCollection.SetMine("Gencho", 999998, 98, 98);
            this.PitFortressCollection.SetMine("Pencho", 999999, 99, 99);
            this.PitFortressCollection.SetMine("Oncho", 1000000, 100, 100);

            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(mines[0].Id, 1, "Mine Id did not match!");
            Assert.AreEqual(mines[0].XCoordinate, 999996, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[0].Delay, 96, "Mine Delay did not match!");
            Assert.AreEqual(mines[0].Damage, 96, "Mine Damage did not match!");
            Assert.AreEqual(mines[0].Player.Name, "Gencho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[0].Player.Radius, 3, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[0].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[1].Id, 2, "Mine Id did not match!");
            Assert.AreEqual(mines[1].XCoordinate, 999997, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[1].Delay, 97, "Mine Delay did not match!");
            Assert.AreEqual(mines[1].Damage, 97, "Mine Damage did not match!");
            Assert.AreEqual(mines[1].Player.Name, "Pencho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[1].Player.Radius, 1, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[1].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[2].Id, 3, "Mine Id did not match!");
            Assert.AreEqual(mines[2].XCoordinate, 999998, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[2].Delay, 98, "Mine Delay did not match!");
            Assert.AreEqual(mines[2].Damage, 98, "Mine Damage did not match!");
            Assert.AreEqual(mines[2].Player.Name, "Gencho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[2].Player.Radius, 3, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[2].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[3].Id, 4, "Mine Id did not match!");
            Assert.AreEqual(mines[3].XCoordinate, 999999, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[3].Delay, 99, "Mine Delay did not match!");
            Assert.AreEqual(mines[3].Damage, 99, "Mine Damage did not match!");
            Assert.AreEqual(mines[3].Player.Name, "Pencho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[3].Player.Radius, 1, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[3].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[4].Id, 5, "Mine Id did not match!");
            Assert.AreEqual(mines[4].XCoordinate, 1000000, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[4].Delay, 100, "Mine Delay did not match!");
            Assert.AreEqual(mines[4].Damage, 100, "Mine Damage did not match!");
            Assert.AreEqual(mines[4].Player.Name, "Oncho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[4].Player.Radius, 2, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[4].Player.Score, 0, "Mine's Player's Score did not match!");
        }
    }
}
