using System.Linq;

namespace BunnyWars.Tests.Performance
{
    using System;
    using System.Diagnostics;
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListBySuffixPerformance : BaseTestClass
    {
        public Random Random { get; private set; }

        public string[] Suffixes { get; private set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.Random = new Random();
            this.Suffixes = new string[] { "Pesho", "Nasko", "RoYaL", "Dijkstra", "Stamat", "RevaL", "Gosho" };
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceListBySuffix_With10000BunniesWithoutGivenSuffixInOneRoom()
        {
            //Arrange
            var bunniesCount = 10000;
            this.BunnyWarCollection.AddRoom(0);
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i + this.Suffixes[3], this.Random.Next(0, 5), 0);
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 1000; i++)
            {
                var result = this.BunnyWarCollection.ListBunniesBySuffix("DoesNotExist");
                Assert.AreEqual(0, result.Count(), "Incorrect count of List By Suffix Command!");
            }
            
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 100);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceListBySuffix_With10000BunniesWithSameSuffixInOneRoom()
        {
            //Arrange
            var bunniesCount = 10000;
            this.BunnyWarCollection.AddRoom(0);
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i + this.Suffixes[this.Random.Next(0, this.Suffixes.Length)], this.Random.Next(0, 5), 0);
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 1000; i++)
            {
                var result = this.BunnyWarCollection.ListBunniesBySuffix("o").Count();
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceListBySuffix_With10000BunniesWithSharedSuffixInMultipleRooms()
        {
            //Arrange
            var roomsCount = 5000;
            var bunniesCount = 10000;
            for (int i = 0; i < roomsCount; i++)
            {
                this.BunnyWarCollection.AddRoom(i);
            }
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i + this.Suffixes[this.Random.Next(0, this.Suffixes.Length)], this.Random.Next(0, 5), this.Random.Next(0, roomsCount));
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 1000; i++)
            {
                var result = this.BunnyWarCollection.ListBunniesBySuffix("aL").Count();
            }
    
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 300);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceListBySuffix_WithEmptySuffix_With10000BunniesWithRandomSuffixesInMultipleRooms()
        {
            //Arrange
            var roomsCount = 5000;
            var bunniesCount = 10000;
            for (int i = 0; i < roomsCount; i++)
            {
                this.BunnyWarCollection.AddRoom(i);
            }
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i + this.Suffixes[this.Random.Next(0, this.Suffixes.Length)], this.Random.Next(0, 5), this.Random.Next(0, roomsCount));
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 1000; i++)
            {
                var result = this.BunnyWarCollection.ListBunniesBySuffix("").Count();
                Assert.AreEqual(10000, result, "Incorrect count of List By Suffix Command!");
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);
        }
    }
}
