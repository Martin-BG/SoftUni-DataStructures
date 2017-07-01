using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LimitedMemory.Tests
{
    [TestClass]
    public class ForeachTests : BaseTest
    {
        [TestMethod]
        [TestCategory("Correctness")]
        public void Foreach_ShouldEnumerate_CountElements()
        {
            var keys = Enumerable.Range(65, this.Capacity)
                .Select(i => ((char)i).ToString());

            foreach (var key in keys)
            {
                collection.Set(key, 1);
            }

            var count = 0;
            foreach (var record in collection)
            {
                count++;
            }

            Assert.AreEqual(count, collection.Count);
        }

        [TestMethod]
        [TestCategory("Correctness")]
        public void Foreach_ShouldReturn_InOrder_MostRecentlyRequested()
        {
            var random = new Random();
            var records = Enumerable.Range(65, this.Capacity)
                .Select(i => new
                {
                    Key = ((char)i).ToString(),
                    Value = random.Next(0, 100)
                })
                .ToArray();

            foreach (var record in records)
            {
                collection.Set(record.Key, record.Value);
            }

            int order = collection.Count - 1;
            foreach (var record in collection)
            {
                Assert.AreEqual(record.Key, records[order].Key);
                Assert.AreEqual(record.Value, records[order].Value);
                order--;
            }
        }

        [TestMethod]
        [TestCategory("Correctness")]
        public void Foreach_Should_Return_InOrder_MostRecentlyRequested_2()
        {
            var collection = LimitedMemoryCollectionInitializer.Create<string, int>(4);
            var random = new Random();
            var records = Enumerable.Range(65, 4)
                .Select(i => new
                {
                    Key = ((char)i).ToString(),
                    Value = random.Next(0, 100)
                })
                .ToArray();

            foreach (var record in records)
            {
                collection.Set(record.Key, record.Value);
            }

            collection.Get(records[1].Key);
            var expectedOrder = new [] { records[0], records[2],  records[3], records[1] };

            int order = collection.Count - 1;
            foreach (var record in collection)
            {
                Assert.AreEqual(record.Key, expectedOrder[order].Key);
                Assert.AreEqual(record.Value, expectedOrder[order].Value);
                order--;
            }
        }

        [TestMethod]
        [TestCategory("Correctness")]
        public void Foreach_Should_Return_InOrder_MostRecentlyRequested_3()
        {
            var collection = LimitedMemoryCollectionInitializer.Create<string, int>(4);
            var random = new Random();
            var records = Enumerable.Range(65, 4)
                .Select(i => new
                {
                    Key = ((char)i).ToString(),
                    Value = random.Next(0, 100)
                })
                .ToArray();

            foreach (var record in records)
            {
                collection.Set(record.Key, record.Value);
            }

            collection.Get(records[2].Key);
            collection.Get(records[0].Key);
            var expectedOrder = new[] { records[1], records[3], records[2], records[0] };

            int order = collection.Count - 1;
            foreach (var record in collection)
            {
                Assert.AreEqual(record.Key, expectedOrder[order].Key);
                Assert.AreEqual(record.Value, expectedOrder[order].Value);
                order--;
            }
        }

        [TestMethod]
        [TestCategory("Correctness")]
        public void Foreach_Should_Return_InOrder_MostRecentlyRequested_4()
        {
            var collection = LimitedMemoryCollectionInitializer.Create<string, int>(4);
            var random = new Random();
            var records = Enumerable.Range(65, 4)
                .Select(i => new
                {
                    Key = ((char)i).ToString(),
                    Value = random.Next(0, 100)
                })
                .ToArray();

            foreach (var record in records)
            {
                collection.Set(record.Key, record.Value);
            }

            collection.Set(records[1].Key, 5);
            var expectedOrder = new[] { records[0], records[2], records[3], records[1] };

            int order = collection.Count - 1;
            foreach (var record in collection)
            {
                Assert.AreEqual(record.Key, expectedOrder[order].Key);
                order--;
            }
        }

        [TestMethod]
        [TestCategory("Correctness")]
        public void Foreach_Should_Return_InOrder_MostRecentlyRequested_5()
        {
            var collection = LimitedMemoryCollectionInitializer.Create<string, int>(5);
            var random = new Random();
            var records = Enumerable.Range(65, collection.Capacity)
                .Select(i => new
                {
                    Key = ((char)i).ToString(),
                    Value = random.Next(0, 100)
                })
                .ToArray();

            foreach (var record in records)
            {
                collection.Set(record.Key, record.Value);
            }

            collection.Set(records[0].Key, random.Next());
            collection.Set(records[3].Key, random.Next());
            collection.Get(records[0].Key);
            var expectedOrder = new[] { records[1], records[2], records[4], records[3], records[0] };

            int order = collection.Count - 1;
            foreach (var record in collection)
            {
                Assert.AreEqual(record.Key, expectedOrder[order].Key);
                order--;
            }
        }
    }
}
