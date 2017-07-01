using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LimitedMemory.Tests
{
    [TestClass]
    public class SetTests : BaseTest
    {
        [TestMethod]
        [TestCategory("Correctness")]
        public void Set_WithAnExistingKey_ShouldSetNewValue()
        {
            collection.Set("A", 5);

            collection.Set("A", 3);

            Assert.AreEqual(3, collection.Get("A"),"Expected Value did not match!");
        }

        [TestMethod]
        [TestCategory("Correctness")]
        public void Set_WithMultipleExistingKeys_ShouldSetElementsCorrectly()
        {
            for (int i = 0; i < this.Capacity; i++)
            {
                var letter = ((char)(65 + i)).ToString();
                collection.Set(letter, i);
            }

            for (int i = 0; i < this.Capacity; i++)
            {
                var letter = ((char)(65 + i)).ToString();
                collection.Set(letter, i + 1);
            }

            for (int i = 0; i < this.Capacity; i++)
            {
                var letter = ((char)(65 + i)).ToString();
                Assert.AreEqual(this.collection.Get(letter), i + 1, "Expected Values did not match!");
            }
        }

        [TestMethod]
        [TestCategory("Correctness")]
        public void Set_MissingKey_CapacityLeft_ShouldAddElement()
        {
            try
            {
                this.collection.Get("A");
                Assert.Fail();
            }
            catch (KeyNotFoundException)
            {
                //Expected
            }
            collection.Set("A", 5);

            this.collection.Get("A");

        }

        [TestMethod]
        [TestCategory("Correctness")]
        public void Set_MissingKey_CapacityLeft_ShouldIncreaseCount()
        {
            collection.Set("A", 5);
            Assert.AreEqual(1, collection.Count);
            collection.Set("B", 3);
            Assert.AreEqual(2, collection.Count);
        }

        [TestMethod]
        [TestCategory("Correctness")]
        public void Set_ExistingKey_CapacityLeft_ShouldNotChangeCount()
        {
            collection.Set("A", 3);
            collection.Set("A", 4);

            Assert.AreEqual(4, collection.Get("A"));
            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        [TestCategory("Correctness")]
        public void Set_ExistingKey_CapacityFull_ShouldNotChangeCount()
        {
            for (int i = 0; i < this.Capacity; i++)
            {
                var letter = ((char)(65 + i)).ToString();
                collection.Set(letter, i);
            }

            collection.Set("A", 2);

            Assert.AreEqual(2, collection.Get("A"));
            Assert.AreEqual(4, collection.Count);
        }


        [TestMethod]
        [TestCategory("Correctness")]
        public void Set_ExistingKey_CapacityFull_ShouldNotChangeOtherElements()
        {
            for (int i = 0; i < this.Capacity; i++)
            {
                var letter = ((char)(65 + i)).ToString();
                this.collection.Set(letter, i);
            }

            this.collection.Set("A", 2);

            for (int i = 1; i < this.Capacity; i++)
            {
                // Check if records are still there
                var letter = ((char)(65 + i)).ToString();
                Assert.AreEqual(i, this.collection.Get(letter), "Expected Value did not match!");
            }
        }

        [TestMethod]
        [TestCategory("Correctness")]
        public void Set_NewKey_CapacityFull_ShouldRemove_LongestAgoRequestedRecord()
        {
            string[] keys = { "A", "C", "D", "B" };
            for (int i = 0; i < keys.Length; i++)
            {
                collection.Set(keys[i], 1);
            }

            collection.Set("G", 1);
            for (int i = 1; i < keys.Length; i++)
            {
                // Check if records are still there
                collection.Get(keys[i]);
            }

            try
            {
                // Expecting exception to be thrown
                collection.Get(keys[0]);
                Assert.Fail("Key should be removed to make room for new key!");
            }
            catch (KeyNotFoundException)
            {
                // Everything is OK
            }
        }
    }
}
