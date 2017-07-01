namespace Hierarchy.Tests
{
    using Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseTest
    {
        public Hierarchy<int> Hierarchy { get; private set; }

        public const int DefaultRootValue = 5;

        [TestInitialize]
        public void Initialize()
        {
            this.Hierarchy = new Hierarchy<int>(5);
        }
    }
}
