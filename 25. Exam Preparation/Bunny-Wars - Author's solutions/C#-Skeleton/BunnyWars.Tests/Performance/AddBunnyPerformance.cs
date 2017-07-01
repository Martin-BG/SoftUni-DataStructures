using System.Diagnostics;

namespace BunnyWars.Tests.Performance
{
    using System;
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddBunnyPerformance : BaseTestClass
    {
        public Random Random { get; set; }

        public string[] Prefixes { get; private set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.Random = new Random();
            this.Prefixes = new string[] { "Pesho", "Nasko", "Joro", "Dijkstra", "Stamat" };
        }
        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddBunny_With10000Bunnies_WithASingleRoomAndTeam()
        {
            //Arrange
            var count = 1;
            var bunnyCount = 10000;
            this.BunnyWarCollection.AddRoom(0);

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < bunnyCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i.ToString(), 0, 0);
                Assert.AreEqual(count++,this.BunnyWarCollection.BunnyCount,"Incorrect count after adding!");
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 600);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddBunny_With10000Bunnies_With1000Rooms()
        {
            for (int i = 0; i < 1000; i++)
            {
                this.BunnyWarCollection.AddRoom(i);
            }
            //Arrange
            var count = 1;
            var bunnyCount = 10000;

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < bunnyCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i.ToString(), 0, i / 10);
                Assert.AreEqual(count++, this.BunnyWarCollection.BunnyCount, "Incorrect count after adding!");
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 400);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddBunny_With10000Bunnies_With1000RoomsAnd5Teams()
        {
            for (int i = 0; i < 1000; i++)
            {
                this.BunnyWarCollection.AddRoom(i);
            }
            //Arrange
            var count = 1;
            var bunnyCount = 10000;

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < bunnyCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i.ToString(), i % 5, i / 10);
                Assert.AreEqual(count++, this.BunnyWarCollection.BunnyCount, "Incorrect count after adding!");
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 400);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddBunny_With10000RandomBunnies_WithASingleRoomAndTeam()
        {
            //Arrange
            var count = 1;
            var bunnyCount = 10000;
            this.BunnyWarCollection.AddRoom(0);

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < bunnyCount; i++)
            {
                this.BunnyWarCollection.AddBunny(this.Prefixes[this.Random.Next(0, this.Prefixes.Length)] + i, 0, 0);
                Assert.AreEqual(count++, this.BunnyWarCollection.BunnyCount, "Incorrect count after adding!");
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 500);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceAddBunny_With10000RandomBunnies_With1000RoomsAnd5Teams()
        {
            for (int i = 0; i < 1000; i++)
            {
                this.BunnyWarCollection.AddRoom(i);
            }
            //Arrange
            var count = 1;
            var bunnyCount = 10000;

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < bunnyCount; i++)
            {
                this.BunnyWarCollection.AddBunny(this.Prefixes[this.Random.Next(0, this.Prefixes.Length)] + i, this.Random.Next(0, 5), this.Random.Next(0, 1000));
                Assert.AreEqual(count++, this.BunnyWarCollection.BunnyCount, "Incorrect count after adding!");
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 400);
        }
    }
}
