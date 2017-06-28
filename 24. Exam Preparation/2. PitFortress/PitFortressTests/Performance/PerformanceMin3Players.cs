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
    public class PerformanceMin3Players : BaseTestClass
    {
        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceMin3Players_WithRandomAmounts1()
        {
            FileStream input = File.Open("../../Tests/Min3Players/min3.0.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(' '))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case"player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case"minion":
                            this.PitFortressCollection.AddMinion(int.Parse(commands[i][1]));
                            break;
                        case"mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                        case"skip":
                            this.PitFortressCollection.PlayTurn();
                            break;
                    }
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();

                var players = this.PitFortressCollection.Min3PlayersByScore();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 10);

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/Min3Players/min3.0.result.txt", FileMode.Open)))
                {
                    foreach (var player in players)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }
                }
            }

        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceMin3Players_WithRandomAmounts2()
        {

            FileStream input2 = File.Open("../../Tests/Min3Players/min3.1.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input2))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(' '))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "minion":
                            this.PitFortressCollection.AddMinion(int.Parse(commands[i][1]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                        case "skip":
                            this.PitFortressCollection.PlayTurn();
                            break;
                    }
                }


                Stopwatch timer = new Stopwatch();
                timer.Start();

                var players = this.PitFortressCollection.Min3PlayersByScore();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 10);

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/Min3Players/min3.1.result.txt", FileMode.Open)))
                {
                    foreach (var player in players)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }
                }
            }

        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceMin3Players_WithRandomAmounts3()
        {
            FileStream input2 = File.Open("../../Tests/Min3Players/min3.2.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input2))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(' '))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "minion":
                            this.PitFortressCollection.AddMinion(int.Parse(commands[i][1]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                        case "skip":
                            this.PitFortressCollection.PlayTurn();
                            break;
                    }
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();

                var players = this.PitFortressCollection.Min3PlayersByScore();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 10);

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/Min3Players/min3.2.result.txt", FileMode.Open)))
                {
                    foreach (var player in players)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }
                }
            }

        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceMin3Players_WithRandomAmounts4()
        {
            FileStream input4 = File.Open("../../Tests/Min3Players/min3.3.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input4))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(' '))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "minion":
                            this.PitFortressCollection.AddMinion(int.Parse(commands[i][1]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                        case "skip":
                            this.PitFortressCollection.PlayTurn();
                            break;
                    }
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();

                var players = this.PitFortressCollection.Min3PlayersByScore();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 10);

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/Min3Players/min3.3.result.txt", FileMode.Open)))
                {
                    foreach (var player in players)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }
                }
            }

        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceMin3Players_WithRandomAmounts5()
        {
            FileStream input5 = File.Open("../../Tests/Min3Players/min3.4.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input5))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(' '))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "minion":
                            this.PitFortressCollection.AddMinion(int.Parse(commands[i][1]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                        case "skip":
                            this.PitFortressCollection.PlayTurn();
                            break;
                    }
                }


                Stopwatch timer = new Stopwatch();
                timer.Start();

                var players = this.PitFortressCollection.Min3PlayersByScore();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 10);

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/Min3Players/min3.4.result.txt", FileMode.Open)))
                {
                    foreach (var player in players)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }
                }
            }
        }
    }
}
