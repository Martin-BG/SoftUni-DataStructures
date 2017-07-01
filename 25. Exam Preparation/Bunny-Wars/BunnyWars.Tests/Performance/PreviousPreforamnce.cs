namespace BunnyWars.Tests.Performance
{
    using System;
    using System.Diagnostics;
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PreviousPerformance : BaseTestClass
    {
        public Random Random { get; private set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.Random = new Random();
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformancePrevious_With10000ConsecutivePreviousCommands_With10000BunniesInOneRoom()
        {
            //Arrange
            var bunniesCount = 10000;
            this.BunnyWarCollection.AddRoom(0);
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i.ToString(), i % 5, 0);
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.Previous(i.ToString());
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 500);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformancePrevious_With10000ConsecutivePreviousCommands_With10000BunniesIn5000Room()
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
                this.BunnyWarCollection.AddBunny(i.ToString(), i % 5, i / 2);
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.Previous(i.ToString());
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 400);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformancePrevious_With10000RandomPreviousCommands_With10000BunniesIn5000Rooms()
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
                this.BunnyWarCollection.AddBunny(i.ToString(), i % 5, i / 2);
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.Previous(this.Random.Next(0, bunniesCount).ToString());
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 400);
        }
    }
}
