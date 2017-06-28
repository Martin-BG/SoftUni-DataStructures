using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitFortressTests.Performance
{
    using System.Diagnostics;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PerformanceSetMine : BaseTestClass
    {

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceSetMine_WithRandomAmounts1()
        {
            FileStream input = File.Open("../../Tests/SetMine/mine.0.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                    }
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 80);

                Assert.AreEqual(commands.Count - 8, this.PitFortressCollection.MinesCount, "Mines Count did not match!");

                var mines = this.PitFortressCollection.GetMines();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/SetMine/mine.0.result.txt", FileMode.Open)))
                {
                    foreach (var mine in mines)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), mine.Delay, "Mine Delay did not match!");
                        Assert.AreEqual(int.Parse(line[1]), mine.Id, "Mine Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), mine.XCoordinate, "Mine Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[3]), mine.Damage, "Mine Damage did not match!");
                        Assert.AreEqual(line[4], mine.Player.Name, "Mine Player did not match!");
                    }
                }
            }
        }


        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceSetMine_WithRandomAmounts2()
        {
            FileStream input = File.Open("../../Tests/SetMine/mine.1.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                    }
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 80);

                Assert.AreEqual(commands.Count - 8, this.PitFortressCollection.MinesCount, "Mines Count did not match!");

                var mines = this.PitFortressCollection.GetMines();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/SetMine/mine.1.result.txt", FileMode.Open)))
                {
                    foreach (var mine in mines)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), mine.Delay, "Mine Delay did not match!");
                        Assert.AreEqual(int.Parse(line[1]), mine.Id, "Mine Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), mine.XCoordinate, "Mine Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[3]), mine.Damage, "Mine Damage did not match!");
                        Assert.AreEqual(line[4], mine.Player.Name, "Mine Player did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceSetMine_WithRandomAmounts3()
        {
            FileStream input = File.Open("../../Tests/SetMine/mine.2.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                    }
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 80);

                Assert.AreEqual(commands.Count - 8, this.PitFortressCollection.MinesCount, "Mines Count did not match!");

                var mines = this.PitFortressCollection.GetMines();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/SetMine/mine.2.result.txt", FileMode.Open)))
                {
                    foreach (var mine in mines)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), mine.Delay, "Mine Delay did not match!");
                        Assert.AreEqual(int.Parse(line[1]), mine.Id, "Mine Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), mine.XCoordinate, "Mine Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[3]), mine.Damage, "Mine Damage did not match!");
                        Assert.AreEqual(line[4], mine.Player.Name, "Mine Player did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceSetMine_WithRandomAmounts4()
        {
            FileStream input = File.Open("../../Tests/SetMine/mine.3.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                    }
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 80);

                Assert.AreEqual(commands.Count - 8, this.PitFortressCollection.MinesCount, "Mines Count did not match!");

                var mines = this.PitFortressCollection.GetMines();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/SetMine/mine.3.result.txt", FileMode.Open)))
                {
                    foreach (var mine in mines)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), mine.Delay, "Mine Delay did not match!");
                        Assert.AreEqual(int.Parse(line[1]), mine.Id, "Mine Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), mine.XCoordinate, "Mine Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[3]), mine.Damage, "Mine Damage did not match!");
                        Assert.AreEqual(line[4], mine.Player.Name, "Mine Player did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceSetMine_WithRandomAmounts5()
        {
            FileStream input = File.Open("../../Tests/SetMine/mine.4.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                    }
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 80);

                Assert.AreEqual(commands.Count - 8, this.PitFortressCollection.MinesCount, "Mines Count did not match!");

                var mines = this.PitFortressCollection.GetMines();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/SetMine/mine.4.result.txt", FileMode.Open)))
                {
                    foreach (var mine in mines)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), mine.Delay, "Mine Delay did not match!");
                        Assert.AreEqual(int.Parse(line[1]), mine.Id, "Mine Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), mine.XCoordinate, "Mine Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[3]), mine.Damage, "Mine Damage did not match!");
                        Assert.AreEqual(line[4], mine.Player.Name, "Mine Player did not match!");
                    }
                }
            }
        }
    }
}
