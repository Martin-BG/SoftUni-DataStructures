using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitFortressTests.Correctness
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CorrectnessGetMines : BaseTestClass
    {
        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessGetMines_WithoutMines_ShouldReturnEmptyCollection()
        {
            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(0, mines.Count, "Incorrect mine count returned.");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessGetMines_WithMultipleMines_ShouldReturnCorrectMountOfMines()
        {
            this.PitFortressCollection.AddPlayer("Gencho", 13);
            this.PitFortressCollection.SetMine("Gencho", 1, 1, 1);
            this.PitFortressCollection.SetMine("Gencho", 2, 2, 2);
            this.PitFortressCollection.SetMine("Gencho", 3, 3, 3);
            this.PitFortressCollection.SetMine("Gencho", 4, 4, 4);
            this.PitFortressCollection.SetMine("Gencho", 5, 5, 5);

            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(5, mines.Count, "Incorrect mine count returned.");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessGetMines_WithASingleMine_ShouldReturnCorrectMine()
        {
            this.PitFortressCollection.AddPlayer("Gencho", 13);
            this.PitFortressCollection.SetMine("Gencho", 20, 20, 20);

            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(mines[0].Id, 1, "Mine Id did not match!");
            Assert.AreEqual(mines[0].XCoordinate, 20, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[0].Delay, 20, "Mine Delay did not match!");
            Assert.AreEqual(mines[0].Damage, 20, "Mine Damage did not match!");
            Assert.AreEqual(mines[0].Player.Name, "Gencho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[0].Player.Radius, 13, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[0].Player.Score, 0, "Mine's Player's Score did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessGetMines_WithMinesWithDuplicateDelays_ShouldReturnCorrectlySortedMines()
        {
            this.PitFortressCollection.AddPlayer("Poncho", 77);
            this.PitFortressCollection.SetMine("Poncho", 77, 77, 88);
            this.PitFortressCollection.SetMine("Poncho", 77, 77, 77);
            this.PitFortressCollection.SetMine("Poncho", 77, 77, 77);

            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(mines[0].Id, 1, "Mine Id did not match!");
            Assert.AreEqual(mines[0].XCoordinate, 77, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[0].Delay, 77, "Mine Delay did not match!");
            Assert.AreEqual(mines[0].Damage, 88, "Mine Damage did not match!");
            Assert.AreEqual(mines[0].Player.Name, "Poncho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[0].Player.Radius, 77, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[0].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[1].Id, 2, "Mine Id did not match!");
            Assert.AreEqual(mines[1].XCoordinate, 77, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[1].Delay, 77, "Mine Delay did not match!");
            Assert.AreEqual(mines[1].Damage, 77, "Mine Damage did not match!");
            Assert.AreEqual(mines[1].Player.Name, "Poncho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[1].Player.Radius, 77, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[1].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[2].Id, 3, "Mine Id did not match!");
            Assert.AreEqual(mines[2].XCoordinate, 77, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[2].Delay, 77, "Mine Delay did not match!");
            Assert.AreEqual(mines[2].Damage, 77, "Mine Damage did not match!");
            Assert.AreEqual(mines[2].Player.Name, "Poncho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[2].Player.Radius, 77, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[2].Player.Score, 0, "Mine's Player's Score did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessGetMines_WithSinglePlayerWithMultipleMines_ShouldReturnMinesCorrectlySorted()
        {
            this.PitFortressCollection.AddPlayer("Gencho", 5);
            this.PitFortressCollection.SetMine("Gencho", 20, 20, 20);
            this.PitFortressCollection.SetMine("Gencho", 100, 5, 30);
            this.PitFortressCollection.SetMine("Gencho", 333, 25, 50);
            this.PitFortressCollection.SetMine("Gencho", 201, 15, 50);
            this.PitFortressCollection.SetMine("Gencho", 666, 30, 60);
            this.PitFortressCollection.SetMine("Gencho", 200, 15, 40);

            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(mines[0].Id, 2, "Mine Id did not match!");
            Assert.AreEqual(mines[0].XCoordinate, 100, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[0].Delay, 5, "Mine Delay did not match!");
            Assert.AreEqual(mines[0].Damage, 30, "Mine Damage did not match!");
            Assert.AreEqual(mines[0].Player.Name, "Gencho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[0].Player.Radius, 5, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[0].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[1].Id, 4, "Mine Id did not match!");
            Assert.AreEqual(mines[1].XCoordinate, 201, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[1].Delay, 15, "Mine Delay did not match!");
            Assert.AreEqual(mines[1].Damage, 50, "Mine Damage did not match!");
            Assert.AreEqual(mines[1].Player.Name, "Gencho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[1].Player.Radius, 5, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[1].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[2].Id, 6, "Mine Id did not match!");
            Assert.AreEqual(mines[2].XCoordinate, 200, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[2].Delay, 15, "Mine Delay did not match!");
            Assert.AreEqual(mines[2].Damage, 40, "Mine Damage did not match!");
            Assert.AreEqual(mines[2].Player.Name, "Gencho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[2].Player.Radius, 5, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[2].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[3].Id, 1, "Mine Id did not match!");
            Assert.AreEqual(mines[3].XCoordinate, 20, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[3].Delay, 20, "Mine Delay did not match!");
            Assert.AreEqual(mines[3].Damage, 20, "Mine Damage did not match!");
            Assert.AreEqual(mines[3].Player.Name, "Gencho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[3].Player.Radius, 5, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[3].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[4].Id, 3, "Mine Id did not match!");
            Assert.AreEqual(mines[4].XCoordinate, 333, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[4].Delay, 25, "Mine Delay did not match!");
            Assert.AreEqual(mines[4].Damage, 50, "Mine Damage did not match!");
            Assert.AreEqual(mines[4].Player.Name, "Gencho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[4].Player.Radius, 5, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[4].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[5].Id, 5, "Mine Id did not match!");
            Assert.AreEqual(mines[5].XCoordinate, 666, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[5].Delay, 30, "Mine Delay did not match!");
            Assert.AreEqual(mines[5].Damage, 60, "Mine Damage did not match!");
            Assert.AreEqual(mines[5].Player.Name, "Gencho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[5].Player.Radius, 5, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[5].Player.Score, 0, "Mine's Player's Score did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessGetMines_WithMultiplePlayersWithMultipleMines_ShouldReturnMinesCorrectlySorted()
        {
            this.PitFortressCollection.AddPlayer("Pesho", 1);
            this.PitFortressCollection.AddPlayer("Tosho", 2);
            this.PitFortressCollection.AddPlayer("Gesho", 3);
            this.PitFortressCollection.AddPlayer("Rosho", 5);

            this.PitFortressCollection.SetMine("Gesho", 10, 10, 10);
            this.PitFortressCollection.SetMine("Tosho", 20, 9, 20);
            this.PitFortressCollection.SetMine("Tosho", 30, 171, 30);
            this.PitFortressCollection.SetMine("Pesho", 40, 15, 40);
            this.PitFortressCollection.SetMine("Gesho", 50, 66, 50);
            this.PitFortressCollection.SetMine("Rosho", 60, 1032, 60);

            var mines = this.PitFortressCollection.GetMines().ToList();

            Assert.AreEqual(mines[0].Id, 2, "Mine Id did not match!");
            Assert.AreEqual(mines[0].XCoordinate, 20, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[0].Delay, 9, "Mine Delay did not match!");
            Assert.AreEqual(mines[0].Damage, 20, "Mine Damage did not match!");
            Assert.AreEqual(mines[0].Player.Name, "Tosho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[0].Player.Radius, 2, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[0].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[1].Id, 1, "Mine Id did not match!");
            Assert.AreEqual(mines[1].XCoordinate, 10, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[1].Delay, 10, "Mine Delay did not match!");
            Assert.AreEqual(mines[1].Damage, 10, "Mine Damage did not match!");
            Assert.AreEqual(mines[1].Player.Name, "Gesho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[1].Player.Radius, 3, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[1].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[2].Id, 4, "Mine Id did not match!");
            Assert.AreEqual(mines[2].XCoordinate, 40, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[2].Delay, 15, "Mine Delay did not match!");
            Assert.AreEqual(mines[2].Damage, 40, "Mine Damage did not match!");
            Assert.AreEqual(mines[2].Player.Name, "Pesho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[2].Player.Radius, 1, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[2].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[3].Id, 5, "Mine Id did not match!");
            Assert.AreEqual(mines[3].XCoordinate, 50, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[3].Delay, 66, "Mine Delay did not match!");
            Assert.AreEqual(mines[3].Damage, 50, "Mine Damage did not match!");
            Assert.AreEqual(mines[3].Player.Name, "Gesho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[3].Player.Radius, 3, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[3].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[4].Id, 3, "Mine Id did not match!");
            Assert.AreEqual(mines[4].XCoordinate, 30, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[4].Delay, 171, "Mine Delay did not match!");
            Assert.AreEqual(mines[4].Damage, 30, "Mine Damage did not match!");
            Assert.AreEqual(mines[4].Player.Name, "Tosho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[4].Player.Radius, 2, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[4].Player.Score, 0, "Mine's Player's Score did not match!");

            Assert.AreEqual(mines[5].Id, 6, "Mine Id did not match!");
            Assert.AreEqual(mines[5].XCoordinate, 60, "Mine Coordinate did not match!");
            Assert.AreEqual(mines[5].Delay, 1032, "Mine Delay did not match!");
            Assert.AreEqual(mines[5].Damage, 60, "Mine Damage did not match!");
            Assert.AreEqual(mines[5].Player.Name, "Rosho", "Mine's Player's Name did not match!");
            Assert.AreEqual(mines[5].Player.Radius, 5, "Mine's Player's Radius did not match!");
            Assert.AreEqual(mines[5].Player.Score, 0, "Mine's Player's Score did not match!");
        }
    }
}
