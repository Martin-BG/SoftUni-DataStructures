using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LimitedMemory.Tests
{
    [TestClass]
    public class GetTests : BaseTest
    {
        [TestMethod]
        [TestCategory("Correctness")]
        public void Get_ExistingKey_ShouldReturnCorrectValue()
        {
            collection.Set("A", 1);
            collection.Set("B", 2);

            var value = collection.Get("B");

            Assert.AreEqual(2, value);
        }

        [TestMethod]
        [TestCategory("Correctness")]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Get_MissingKey_ShouldThrow()
        {
            collection.Set("A", 1);
            collection.Get("B");
        }

        [TestMethod]
        [TestCategory("Correctness")]
        public void Get_AfterTwoTimesSet_OnSameKey_ShouldReturnSecondValue()
        {
            collection.Set("A", 1);
            var firstValue = collection.Get("A");
            Assert.AreEqual(1, firstValue);

            collection.Set("A", 2);
            var secondValue = collection.Get("A");
            Assert.AreEqual(2, secondValue);
        }
    }
}
