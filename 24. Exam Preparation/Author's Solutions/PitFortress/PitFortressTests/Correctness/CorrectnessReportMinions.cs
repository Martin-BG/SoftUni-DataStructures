using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitFortressTests.Correctness
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CorrectnessReportMinions : BaseTestClass
    {

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessReportMinions_WithoutMinions_ShouldReturnEmptyCollection()
        {
            var minions = this.PitFortressCollection.ReportMinions().ToList();
            
            Assert.AreEqual(0,minions.Count,"Incorrect minion count returned.");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessReportMinions_WithMultipleMinions_ShouldReturnCorrectAmountOfMinions()
        {
            this.PitFortressCollection.AddMinion(1);
            this.PitFortressCollection.AddMinion(2);
            this.PitFortressCollection.AddMinion(3);
            this.PitFortressCollection.AddMinion(4);
            this.PitFortressCollection.AddMinion(5);
            this.PitFortressCollection.AddMinion(6);
            this.PitFortressCollection.AddMinion(7);
            this.PitFortressCollection.AddMinion(8);

            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(8, minions.Count, "Incorrect minion count returned.");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessReportMinions_WithMultipleValidMinions_ShouldReturnCorrectMinions()
        {
            this.PitFortressCollection.AddMinion(5);
            this.PitFortressCollection.AddMinion(13);
            this.PitFortressCollection.AddMinion(27);

            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(minions[0].XCoordinate, 5, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[0].Health, 100, "Minion health did not match!");
            Assert.AreEqual(minions[0].Id, 1, "Minion Id did not match!");

            Assert.AreEqual(minions[1].XCoordinate, 13, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[1].Health, 100, "Minion health did not match!");
            Assert.AreEqual(minions[1].Id, 2, "Minion Id did not match!");

            Assert.AreEqual(minions[2].XCoordinate, 27, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[2].Health, 100, "Minion health did not match!");
            Assert.AreEqual(minions[2].Id, 3, "Minion Id did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessReportMinions_WithMinionsWithDuplicateCoordinates_ShouldReturnCorrectlySortedMinions()
        {
            this.PitFortressCollection.AddMinion(13);
            this.PitFortressCollection.AddMinion(27);
            this.PitFortressCollection.AddMinion(5);
            this.PitFortressCollection.AddMinion(5066);
            this.PitFortressCollection.AddMinion(5066);
            this.PitFortressCollection.AddMinion(134013);

            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(minions[0].XCoordinate, 5, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[0].Health, 100, "Minion health did not match!");
            Assert.AreEqual(minions[0].Id, 3, "Minion Id did not match!");

            Assert.AreEqual(minions[1].XCoordinate, 13, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[1].Health, 100, "Minion health did not match!");
            Assert.AreEqual(minions[1].Id, 1, "Minion Id did not match!");

            Assert.AreEqual(minions[2].XCoordinate, 27, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[2].Health, 100, "Minion health did not match!");
            Assert.AreEqual(minions[2].Id, 2, "Minion Id did not match!");

            Assert.AreEqual(minions[3].XCoordinate, 5066, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[3].Health, 100, "Minion health did not match!");
            Assert.AreEqual(minions[3].Id, 4, "Minion Id did not match!");

            Assert.AreEqual(minions[4].XCoordinate, 5066, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[4].Health, 100, "Minion health did not match!");
            Assert.AreEqual(minions[4].Id, 5, "Minion Id did not match!");

            Assert.AreEqual(minions[5].XCoordinate, 134013, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[5].Health, 100, "Minion health did not match!");
            Assert.AreEqual(minions[5].Id, 6, "Minion Id did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessReportMinions_WithMultipleValidMinions_ShouldReturnCorrectlySortedMinions()
        {
            this.PitFortressCollection.AddMinion(20);
            this.PitFortressCollection.AddMinion(30);
            this.PitFortressCollection.AddMinion(10);

            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(minions[0].XCoordinate, 10, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[0].Health, 100, "Minion health did not match!");
            Assert.AreEqual(minions[0].Id, 3, "Minion Id did not match!");

            Assert.AreEqual(minions[1].XCoordinate, 20, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[1].Health, 100, "Minion health did not match!");
            Assert.AreEqual(minions[1].Id, 1, "Minion Id did not match!");

            Assert.AreEqual(minions[2].XCoordinate, 30, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[2].Health, 100, "Minion health did not match!");
            Assert.AreEqual(minions[2].Id, 2, "Minion Id did not match!");
        }
    }
}
