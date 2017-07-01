using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitedMemory.Tests.Performance
{
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PerformanceSet
    {
        protected const int DefaultCapacity = 100000;

        protected ILimitedMemoryCollection<string, int> collection;

        [TestInitialize]
        public void TestInit()
        {
            this.collection = LimitedMemoryCollectionInitializer.Create<string, int>(DefaultCapacity);
        }

        [TestCleanup]
        public void TestFinish()
        {
            Assert.IsTrue(collection.Count <= collection.Capacity);
        }

        [TestMethod]
        [TestCategory("Performance")]
        public void PerformanceSet_With100000CallsOnExistingElements()
        {
            for (int i = 1; i <= DefaultCapacity; i++)
            {
                collection.Set(i.ToString(), i);
            }

            var sw = new Stopwatch();
            sw.Start();

            for (int i = 1; i <= DefaultCapacity; i++)
            {
                collection.Set(i.ToString(), DefaultCapacity - i);
            }

            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds <= 200);

            for (int i = 1; i < DefaultCapacity; i++)
            {
                Assert.AreEqual(DefaultCapacity - i, this.collection.Get(i.ToString()),"Expected Value did not match!");
            }
        }

        [TestMethod]
        [TestCategory("Performance")]
        public void PerformanceSet_Called100000Times()
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 1; i <= 100000; i++)
            {
                collection.Set(i.ToString(), i);
            }

            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds <= 200);

            for (int i = 1; i <= DefaultCapacity; i++)
            {
                Assert.AreEqual(i, this.collection.Get(i.ToString()), "Expected Value did not match!");
            }
        }

        [TestMethod]
        [TestCategory("Performance")]
        public void PerformanceSet_With200000ElementsWith100000Capacity()
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 1; i <= 200000; i++)
            {
                collection.Set(i.ToString(), i);
            }

            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds <= 500);
        }
    }
}
