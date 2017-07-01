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
    public class PerformanceGet
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
        public void PerformanceGet_WithExistingKeyWith100000Elements_ShouldReturnElementFast()
        {
            for (int i = 0; i < DefaultCapacity; i++)
            {
                collection.Set(i.ToString(), i);
            }

            var sw = new Stopwatch();
            sw.Start();

            var item = this.collection.Get("99999");

            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds <= 30);

            Assert.AreEqual(99999, item, "Expected value did not match");
        }

        [TestMethod]
        [TestCategory("Performance")]
        public void PerformanceGet_WithExistingKeyWith80000Elements_ShouldReturnElementFast()
        {
            for (int i = 1; i <= 80000; i++)
            {
                collection.Set(i.ToString(), DefaultCapacity - i);
            }

            var sw = new Stopwatch();
            sw.Start();

            var item = this.collection.Get("75000");

            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds <= 30);

            Assert.AreEqual(DefaultCapacity - 75000,item, "Expected value did not match");
        }

        [TestMethod]
        [TestCategory("Performance")]
        public void PerformanceGet_WithNonExistingKeyWith100000Elements_ShouldReturnKeyNotFoundFast()
        {
            for (int i = 0; i < DefaultCapacity; i++)
            {
                collection.Set(i.ToString(), i);
            }

            var sw = new Stopwatch();
            sw.Start();

            try
            {
                this.collection.Get("100001");
            }
            catch (KeyNotFoundException)
            {
                //Expected
                sw.Stop();
                Assert.IsTrue(sw.ElapsedMilliseconds <= 30);
            }
        }

        [TestMethod]
        [TestCategory("Performance")]
        public void PerformanceGet_With100000GetCalls()
        {
            for (int i = 1; i <= DefaultCapacity; i++)
            {
                collection.Set(i.ToString(), i);
            }

            var sw = new Stopwatch();
            sw.Start();

            for (int i = 1; i <= DefaultCapacity; i++)
            {
                Assert.AreEqual(i, collection.Get(i.ToString()), "Expected Value did not match");
            }
            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds <= 350);
        }

        [TestMethod]
        [TestCategory("Performance")]
        public void PerformanceGet_With100000GetCallsReversed()
        {
            for (int i = 1; i <= DefaultCapacity; i++)
            {
                collection.Set(i.ToString(), i);
            }

            var sw = new Stopwatch();
            sw.Start();

            for (int i = DefaultCapacity; i > 0; i--)
            {
                Assert.AreEqual(i,collection.Get(i.ToString()),"Expected Value did not match");
            }
            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds <= 350);
        }
    }
}
