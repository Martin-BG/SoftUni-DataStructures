namespace BunnyWars.Tests.Performance
{
    using System.Diagnostics;
    using BunnyWars;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemovePerformance : BaseTestClass
    {
        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceRemoveRoom_With15000RemoveCommands_With15000EmptyRooms()
        {
            for (int i = 0; i < 15000; i++)
            {
                this.BunnyWarCollection.AddRoom(i);
            }

            //Arrange
            var count = 15000;
            var roomsCount = 15000;

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < roomsCount; i++)
            {
                this.BunnyWarCollection.Remove(i);
                Assert.AreEqual(--count,this.BunnyWarCollection.RoomCount,"Incorrect count of rooms after removal!");
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 300);
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceRemoveRoom_With5000RemoveCommands_With10000BunniesIn5000Rooms()
        {
            for (int i = 0; i < 5000; i++)
            {
                this.BunnyWarCollection.AddRoom(i);
            }

            for (int i = 0; i < 10000; i++)
            {
                this.BunnyWarCollection.AddBunny(i.ToString(), i % 5, i / 2);
            }

            //Arrange
            var count = 5000;
            var roomsCount = 5000;

            //Act
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < roomsCount; i++)
            {
                this.BunnyWarCollection.Remove(i);
                Assert.AreEqual(--count, this.BunnyWarCollection.RoomCount, "Incorrect count of rooms after removal!");
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 300);
        }
    }
}
