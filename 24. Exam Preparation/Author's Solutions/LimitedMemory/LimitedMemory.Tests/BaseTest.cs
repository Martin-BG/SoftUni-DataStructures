using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LimitedMemory.Tests
{
    [TestClass]
    public class BaseTest
    {
        protected const int DefaultCapacity = 4;

        protected readonly int Capacity;
        protected ILimitedMemoryCollection<string, int> collection;

        public BaseTest(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
        }

        [TestInitialize]
        public void TestInit()
        {
            this.collection = LimitedMemoryCollectionInitializer.Create<string, int>(this.Capacity);
        }

        [TestCleanup]
        public void TestFinish()
        {
            Assert.IsTrue(collection.Count <= collection.Capacity);
        }
    }
}
