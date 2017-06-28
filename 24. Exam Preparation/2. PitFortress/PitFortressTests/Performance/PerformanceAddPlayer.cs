namespace PitFortressTests.Performance
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PerformanceAddPlayer : BaseTestClass
    {

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddPlayer_WithRandomAmounts1()
        {
            FileStream input = File.Open("../../Tests/AddPlayer/addPlayer.0.txt", FileMode.Open);
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
                    this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 350);

                Assert.AreEqual(commands.Count,this.PitFortressCollection.PlayersCount,"Players Count did not match!");
            }
        }


        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddPlayer_WithRandomAmounts2()
        {
            FileStream input = File.Open("../../Tests/AddPlayer/addPlayer.1.txt", FileMode.Open);
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
                    this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 350);

                Assert.AreEqual(commands.Count, this.PitFortressCollection.PlayersCount, "Players Count did not match!");
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddPlayer_WithRandomAmounts3()
        {
            FileStream input = File.Open("../../Tests/AddPlayer/addPlayer.2.txt", FileMode.Open);
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
                    this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 350);

                Assert.AreEqual(commands.Count, this.PitFortressCollection.PlayersCount, "Players Count did not match!");
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddPlayer_WithRandomAmounts4()
        {
            FileStream input = File.Open("../../Tests/AddPlayer/addPlayer.3.txt", FileMode.Open);
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
                    this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 350);

                Assert.AreEqual(commands.Count, this.PitFortressCollection.PlayersCount, "Players Count did not match!");
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddPlayer_WithRandomAmounts5()
        {
            FileStream input = File.Open("../../Tests/AddPlayer/addPlayer.4.txt", FileMode.Open);
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
                    this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                }

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 350);

                Assert.AreEqual(commands.Count, this.PitFortressCollection.PlayersCount, "Players Count did not match!");
            }
        }
    }
}
