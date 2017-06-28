using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PitFortressTests.Correctness
{

    [TestClass]
    public class CorrectnessAddMinion : BaseTestClass
    {
        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessAddMinion_WithNegativeCoordinate_ShouldThrowCorrectException()
        {
                this.PitFortressCollection.AddMinion(-1);
        }

        [TestCategory("Correctness")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CorrectnessAddMinion_WithIncorrectCoordinate_ShouldThrowCorrectException()
        {
            this.PitFortressCollection.AddMinion(1000001);
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessAddMinion_WithValidCoordinate_ShouldIncreaseMinionCounter()
        {
            this.PitFortressCollection.AddMinion(13);
            
            Assert.AreEqual(1,this.PitFortressCollection.MinionsCount,"Minions Count did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessAddMinion_WithExistingMinions_ShouldIncreaseMinionCounterCorrectly()
        {
            this.PitFortressCollection.AddMinion(1000);
            this.PitFortressCollection.AddMinion(999);
            this.PitFortressCollection.AddMinion(998);
            this.PitFortressCollection.AddMinion(997);

            Assert.AreEqual(4, this.PitFortressCollection.MinionsCount, "Minions Count did not match!");

            this.PitFortressCollection.AddMinion(10);

            Assert.AreEqual(5, this.PitFortressCollection.MinionsCount, "Minions Count did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessAddMinion_WithMinionsWithSameCoordinate_ShouldIncreaseMinionCounterCorrectly()
        {
            this.PitFortressCollection.AddMinion(13);
            this.PitFortressCollection.AddMinion(27);
            this.PitFortressCollection.AddMinion(5);
            this.PitFortressCollection.AddMinion(13);

            Assert.AreEqual(4, this.PitFortressCollection.MinionsCount, "Minions Count did not match!");
        }

        [TestCategory("Correctness")]
        [TestMethod]
        public void CorrectnessAddMinion_WithMultipleValidMinions_ShouldAddCorrectMinions()
        {
            this.PitFortressCollection.AddMinion(13);
            this.PitFortressCollection.AddMinion(27);
            this.PitFortressCollection.AddMinion(5);

            var minions = this.PitFortressCollection.ReportMinions().ToList();

            Assert.AreEqual(minions[0].XCoordinate, 5, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[0].Health, 100, "Minion health did not match!");

            Assert.AreEqual(minions[1].XCoordinate, 13, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[1].Health, 100, "Minion health did not match!");

            Assert.AreEqual(minions[2].XCoordinate, 27, "Minion xCoordinate did not match!");
            Assert.AreEqual(minions[2].Health, 100, "Minion health did not match!");
        }
    }
}
