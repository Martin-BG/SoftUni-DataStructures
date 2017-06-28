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
    public class PerformanceReportMinions : BaseTestClass
    {
         [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceReportMinions_WithRandomAmounts1()
        {
            FileStream input = File.Open("../../Tests/ReportMinions/report.0.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    this.PitFortressCollection.AddMinion(int.Parse(commands[i][0]));
                }

                Assert.AreEqual(commands.Count, this.PitFortressCollection.MinionsCount, "Minions Count did not match!");

                Stopwatch timer = new Stopwatch();
                timer.Start();

                var minions = this.PitFortressCollection.ReportMinions();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 30);

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/ReportMinions/report.0.result.txt", FileMode.Open)))
                {
                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minon Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }
                }
            }
        }


        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceReportMinions_WithRandomAmounts2()
        {
             FileStream input = File.Open("../../Tests/ReportMinions/report.1.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    this.PitFortressCollection.AddMinion(int.Parse(commands[i][0]));
                }

                Assert.AreEqual(commands.Count, this.PitFortressCollection.MinionsCount, "Minions Count did not match!");

                Stopwatch timer = new Stopwatch();
                timer.Start();

                var minions = this.PitFortressCollection.ReportMinions();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 30);

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/ReportMinions/report.1.result.txt", FileMode.Open)))
                {
                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minon Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceReportMinions_WithRandomAmounts3()
        {
             FileStream input = File.Open("../../Tests/ReportMinions/report.2.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    this.PitFortressCollection.AddMinion(int.Parse(commands[i][0]));
                }

                Assert.AreEqual(commands.Count, this.PitFortressCollection.MinionsCount, "Minions Count did not match!");

                Stopwatch timer = new Stopwatch();
                timer.Start();

                var minions = this.PitFortressCollection.ReportMinions();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 30);

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/ReportMinions/report.2.result.txt", FileMode.Open)))
                {
                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minon Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceReportMinions_WithRandomAmounts4()
        {
            FileStream input = File.Open("../../Tests/ReportMinions/report.3.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    this.PitFortressCollection.AddMinion(int.Parse(commands[i][0]));
                }

                Assert.AreEqual(commands.Count, this.PitFortressCollection.MinionsCount, "Minions Count did not match!");

                Stopwatch timer = new Stopwatch();
                timer.Start();

                var minions = this.PitFortressCollection.ReportMinions();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 30);

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/ReportMinions/report.3.result.txt", FileMode.Open)))
                {
                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minon Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceReportMinions_WithRandomAmounts5()
        {
            FileStream input = File.Open("../../Tests/ReportMinions/report.4.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    this.PitFortressCollection.AddMinion(int.Parse(commands[i][0]));
                }

                Assert.AreEqual(commands.Count, this.PitFortressCollection.MinionsCount, "Minions Count did not match!");

                Stopwatch timer = new Stopwatch();
                timer.Start();

                var minions = this.PitFortressCollection.ReportMinions();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 30);

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/ReportMinions/report.4.result.txt", FileMode.Open)))
                {
                    foreach (var minion in minions)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), minion.XCoordinate, "Minon Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[1]), minion.Id, "Minion Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), minion.Health, "Minion Health did not match!");
                    }
                }
            }
        }
    }
}
