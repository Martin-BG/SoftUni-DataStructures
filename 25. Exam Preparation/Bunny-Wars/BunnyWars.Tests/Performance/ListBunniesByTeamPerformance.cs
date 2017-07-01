using System.Diagnostics;
using System.Linq;

namespace BunnyWars.Tests.Performance
{
    using System;
    using System.Collections.Generic;
    using BunnyWars;
    using BunnyWars.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListByTeamPerformance : BaseTestClass
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
        public void PerformanceListByTeam_With10000BunniesInOneRoomInSameTeam()
        {
            //Arrange
            var bunniesCount = 10000;
            this.BunnyWarCollection.AddRoom(0);
            for (int i = 0; i < bunniesCount; i++)
            {
                this.BunnyWarCollection.AddBunny(i.ToString(), 0, 0);
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 10000; i++)
            {
                var result = this.BunnyWarCollection.ListBunniesByTeam(0).Count();
                Assert.AreEqual(10000, result, "Incorrect count of bunnies returned by List By Team Command!");
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 100);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceListByTeam_With10000BunniesRandomlyDistributedIn5000RoomsInSameTeam()
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
                this.BunnyWarCollection.AddBunny(i.ToString(), 2, this.Random.Next(0, roomsCount));
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 10000; i++)
            {
                var result = this.BunnyWarCollection.ListBunniesByTeam(2).Count();
                Assert.AreEqual(10000, result, "Incorrect count of bunnies returned by List By Team Command!");
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 100);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceListByTeam_With10000BunniesRandomlyDistributedIn5000RoomsInDifferentTeams()
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
                this.BunnyWarCollection.AddBunny(i.ToString(), this.Random.Next(0, 5), this.Random.Next(0, roomsCount));
            }

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 10000; i++)
            {
                var result = this.BunnyWarCollection.ListBunniesByTeam(this.Random.Next(0, 5)).Count();
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 100);
        }

        static int MyCount(IEnumerable<Bunny> enumerable)
        {
            var count = 0;
            foreach (Bunny item in enumerable)
            {
                count++;
            }

            return count;
        }
    }
}
