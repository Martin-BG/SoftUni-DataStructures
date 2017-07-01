namespace BunnyWars.Tests.Performance
{
    using System;
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DetonatePerformance : BaseTestClass
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
        public void PerformanceDetonate_WithOneBunnyDetonatingMultipleTimes_With10000BunniesInOneRoomInDifferentTeams()
        {
            //Arrange
            var bunniesCount = 10000;
            this.BunnyWarCollection.AddRoom(4);
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i.ToString(), i % 4, 4);
            }

            var bunny = this.Random.Next(0, bunniesCount).ToString();

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.Detonate(bunny);
            }
            Assert.AreEqual(2500,this.BunnyWarCollection.BunnyCount, "Incorrect amount of bunnies after detonation!");
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 500);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceDetonate_With10000RandomDetonates_With10000BunniesInOneRoomWithSameTeam()
        {
            //Arrange
            var bunniesCount = 10000;
            this.BunnyWarCollection.AddRoom(3);
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i.ToString(), 0, 3);
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.Detonate(this.Random.Next(0, bunniesCount).ToString());
            }
            Assert.AreEqual(10000,this.BunnyWarCollection.BunnyCount,"Incorrect amount of bunnies after detonation!");
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 100);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceDetonate_With4OutOf5BunniesDetonatingConsecutivelyInEveryRoom_With10000BunniesIn2000RoomsInDifferentTeams()
        {
            //Arrange
            var roomsCount = 2000;
            var bunniesCount = 10000;
            for (int i = 0; i < roomsCount; i++)
            {
                this.BunnyWarCollection.AddRoom(i);
            }

            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i.ToString(), i % 5, i / 5);
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < bunniesCount; i++)
            {
                if (i % 5 != 4)
                {
                    this.BunnyWarCollection.Detonate(i.ToString());
                }
            }
            Assert.AreEqual(8000, this.BunnyWarCollection.BunnyCount, "Incorrect amount of bunnies after detonation!");
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 100);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceDetonate_With10000DetonationsInReverseOrder_With10000BunniesIn3334RoomsInDifferentTeams()
        {
            //Arrange
            var roomsCount = 3334;
            var bunniesCount = 10000;
            for (int i = 0; i < roomsCount; i++)
            {
                this.BunnyWarCollection.AddRoom(i);
            }

            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i.ToString(), i % 5, i / 3);
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = bunniesCount - 1; i >= 0; i--)
            {
                this.BunnyWarCollection.Detonate(i.ToString());
            }
            Assert.AreEqual(10000, this.BunnyWarCollection.BunnyCount, "Incorrect amount of bunnies after detonation!");
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 100);
        }
    }
}
