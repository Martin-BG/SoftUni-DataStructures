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
    public class PerformancePlayTurn : BaseTestClass
    {
        [TestCategory("Performance")]
        [TestMethod]
        public void PerformancePlayTurn_WithRandomAmounts1()
        {
            FileStream input = File.Open("../../Tests/PlayTurn/turn.0.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
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
                    }
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < 30; i++)
                {
                    this.PitFortressCollection.PlayTurn();
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 650);

                var topPlayers = this.PitFortressCollection.Top3PlayersByScore();
                var botPlayers = this.PitFortressCollection.Min3PlayersByScore();
                var minions = this.PitFortressCollection.ReportMinions();
                var mines = this.PitFortressCollection.GetMines();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/PlayTurn/turn.0.result.txt", FileMode.Open)))
                {
                    foreach (var player in topPlayers)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }

                    foreach (var player in botPlayers)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }

                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minion Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }

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
        public void PerformancePlayTurn_WithRandomAmounts2()
        {
            FileStream input2 = File.Open("../../Tests/PlayTurn/turn.1.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input2))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
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
                    }
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < 40; i++)
                {
                    this.PitFortressCollection.PlayTurn();
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 650);

                var topPlayers = this.PitFortressCollection.Top3PlayersByScore();
                var botPlayers = this.PitFortressCollection.Min3PlayersByScore();
                var minions = this.PitFortressCollection.ReportMinions();
                var mines = this.PitFortressCollection.GetMines();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/PlayTurn/turn.1.result.txt", FileMode.Open)))
                {
                    foreach (var player in topPlayers)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }

                    foreach (var player in botPlayers)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }

                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minion Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }

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
        public void PerformancePlayTurn_WithRandomAmounts3()
        {
            FileStream input2 = File.Open("../../Tests/PlayTurn/turn.2.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input2))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
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
                    }
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < 50; i++)
                {
                    this.PitFortressCollection.PlayTurn();
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 650);

                var topPlayers = this.PitFortressCollection.Top3PlayersByScore();
                var botPlayers = this.PitFortressCollection.Min3PlayersByScore();
                var minions = this.PitFortressCollection.ReportMinions();
                var mines = this.PitFortressCollection.GetMines();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/PlayTurn/turn.2.result.txt", FileMode.Open)))
                {
                    foreach (var player in topPlayers)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }

                    foreach (var player in botPlayers)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }

                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minion Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }

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
        public void PerformancePlayTurn_WithRandomAmounts4()
        {
            FileStream input4 = File.Open("../../Tests/PlayTurn/turn.3.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input4))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
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
                    }
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < 60; i++)
                {
                    this.PitFortressCollection.PlayTurn();
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 700);

                var topPlayers = this.PitFortressCollection.Top3PlayersByScore();
                var botPlayers = this.PitFortressCollection.Min3PlayersByScore();
                var minions = this.PitFortressCollection.ReportMinions();
                var mines = this.PitFortressCollection.GetMines();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/PlayTurn/turn.3.result.txt", FileMode.Open)))
                {
                    foreach (var player in topPlayers)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }

                    foreach (var player in botPlayers)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }

                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minion Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }

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
        public void PerformancePlayTurn_WithRandomAmounts5()
        {
            FileStream input5 = File.Open("../../Tests/PlayTurn/turn.4.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input5))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
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
                    }
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < 80; i++)
                {
                    this.PitFortressCollection.PlayTurn();
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 700);

                var topPlayers = this.PitFortressCollection.Top3PlayersByScore();
                var botPlayers = this.PitFortressCollection.Min3PlayersByScore();
                var minions = this.PitFortressCollection.ReportMinions();
                var mines = this.PitFortressCollection.GetMines();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/PlayTurn/turn.4.result.txt", FileMode.Open)))
                {
                    foreach (var player in topPlayers)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }

                    foreach (var player in botPlayers)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(line[0], player.Name, "Player Name did not match!");
                        Assert.AreEqual(int.Parse(line[1]), player.Radius, "Player Radius did not match!");
                        Assert.AreEqual(int.Parse(line[2]), player.Score, "Player Score did not match!");
                    }

                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minion Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }

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
