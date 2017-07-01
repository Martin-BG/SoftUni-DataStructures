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
    public class PerformanceAddMinion : BaseTestClass
    {
        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddMinion_WithRandomAmounts1()
        {
            FileStream input = File.Open("../../Tests/AddMinion/addMinion.0.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < commands.Count; i++)
                {
                    this.PitFortressCollection.AddMinion(commands[i]);
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 120);

                Assert.AreEqual(commands.Count, this.PitFortressCollection.MinionsCount, "Minon Count did not match!");

                var minions = this.PitFortressCollection.ReportMinions();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/AddMinion/addMinion.0.result.txt",FileMode.Open)))
                {
                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]),minion.XCoordinate,"Minion Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddMinion_WithRandomAmounts2()
        {

            FileStream input2 = File.Open("../../Tests/AddMinion/addMinion.1.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input2))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < commands.Count; i++)
                {
                    this.PitFortressCollection.AddMinion(commands[i]);
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 120);

                Assert.AreEqual(commands.Count, this.PitFortressCollection.MinionsCount, "Minon Count did not match!");

                var minions = this.PitFortressCollection.ReportMinions();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/AddMinion/addMinion.1.result.txt", FileMode.Open)))
                {
                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minion Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddMinion_WithRandomAmounts3()
        {
            FileStream input3 = File.Open("../../Tests/AddMinion/addMinion.2.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input3))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < commands.Count; i++)
                {
                    this.PitFortressCollection.AddMinion(commands[i]);
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 120);

                Assert.AreEqual(commands.Count, this.PitFortressCollection.MinionsCount, "Minon Count did not match!");

                var minions = this.PitFortressCollection.ReportMinions();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/AddMinion/addMinion.2.result.txt", FileMode.Open)))
                {
                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minion Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddMinion_WithRandomAmounts4()
        {
            FileStream input4 = File.Open("../../Tests/AddMinion/addMinion.3.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input4))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < commands.Count; i++)
                {
                    this.PitFortressCollection.AddMinion(commands[i]);
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 120);

                Assert.AreEqual(commands.Count, this.PitFortressCollection.MinionsCount, "Minon Count did not match!");

                var minions = this.PitFortressCollection.ReportMinions();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/AddMinion/addMinion.3.result.txt", FileMode.Open)))
                {
                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minion Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddMinion_WithRandomAmounts5()
        {
            FileStream input5 = File.Open("../../Tests/AddMinion/addMinion.4.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input5))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (int i = 0; i < commands.Count; i++)
                {
                    this.PitFortressCollection.AddMinion(commands[i]);
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 120);

                Assert.AreEqual(commands.Count, this.PitFortressCollection.MinionsCount, "Minon Count did not match!");

                var minions = this.PitFortressCollection.ReportMinions();

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/AddMinion/addMinion.4.result.txt", FileMode.Open)))
                {
                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minion Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }
                }
            }
        }
    }
}
