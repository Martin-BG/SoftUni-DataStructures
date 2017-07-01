namespace BunnyWars.Tests.Performance
{
    using System;
    using System.Diagnostics;
    using BunnyWars.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddRoomPerformance : BaseTestClass
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
        [Timeout(250)]
        public void PerformanceAddRoom_With50000Rooms()
        {
            //Arrange
            var count = 1;
            var roomsCount = 50000;

            var sw = new Stopwatch();
            sw.Start();
            //Act
            for (int i = 0; i < roomsCount; i++)
            {
                this.BunnyWarCollection.AddRoom(i);
                Assert.AreEqual(count++,this.BunnyWarCollection.RoomCount,"Incorrect count of rooms after adding!");
            }
        }
    }
}
