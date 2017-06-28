using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LimitedMemory.Tests
{
    [TestClass]
    public class PerformanceForEach
    {
        private Random random = new Random();

        [TestMethod]
        [TestCategory("Performance")]
        public void PerformanceForEach_With100000Elements_ShouldIterateOptimally()
        {
            var Capacity = 100000;
            var collection = new LimitedMemoryCollection<int, int>(Capacity);
            var records = Enumerable.Range(1, Capacity)
               .Select(i => new
               {
                   Key = i,
                   Value = random.Next(0, 100)
               })
               .ToArray();

            foreach (var record in records)
            {
                collection.Set(record.Key, record.Value);
            }

            var count = 99999;

            var sw = new Stopwatch();
            sw.Start();

            foreach (var record in collection)
            {
                Assert.AreEqual(records[count].Key, record.Key, "Expected Key did not match!");
                Assert.AreEqual(records[count--].Value, record.Value, "Expected Value did not match!");
            }

            var exercutionTime = sw.ElapsedMilliseconds;
            Assert.IsTrue(exercutionTime <= 300);
        }

        [TestMethod]
        [TestCategory("Performance")]
        public void PerformanceForEach_With100000ElementsReversed_ShouldIterateOptimally()
        {
            var Capacity = 100000;
            var collection = new LimitedMemoryCollection<int, int>(Capacity);
            var records = Enumerable.Range(1, Capacity)
               .Select(i => new
               {
                   Key = i,
                   Value = i
               })
               .Reverse()
               .ToArray();

            foreach (var record in records)
            {
                collection.Set(record.Key, record.Value);
            }
            records = records.Reverse().ToArray();

            var count = 0;

            var sw = new Stopwatch();
            sw.Start();

            foreach (var record in collection)
            {
                Assert.AreEqual(records[count].Key, record.Key, "Expected Key did not match!");
                Assert.AreEqual(records[count++].Value, record.Value, "Expected Value did not match!");
            }

            var exercutionTime = sw.ElapsedMilliseconds;
            Assert.IsTrue(exercutionTime <= 300);
        }

        [TestMethod]
        [TestCategory("Performance")]
        public void PerformanceForEach_With80000MixedElements_ShouldIterateOptimally()
        {
            var Capacity = 80000;
            var collection = new LimitedMemoryCollection<int, int>(Capacity);
            var records = new List<int>();
            for (int i = 0; i < 40000; i++)
            {
                records.Add(i);
                records.Add(79999 - i);
            }
        
            foreach (var record in records)
            {
                collection.Set(record, record);
            }

            records.Reverse();

            var count = 0;

            var sw = new Stopwatch();
            sw.Start();

            foreach (var record in collection)
            {
                Assert.AreEqual(records[count], record.Key, "Expected Key did not match!");
                Assert.AreEqual(records[count++], record.Value, "Expected Value did not match!");
            }

            var exercutionTime = sw.ElapsedMilliseconds;
            Assert.IsTrue(exercutionTime <= 300);
        }
    }
}
