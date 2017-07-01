namespace BunnyWars.Tests
{
    using BunnyWars.Core;
    using BunnyWars.Tests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseTestClass
    {
        public IBunnyWarsStructure BunnyWarCollection { get; private set; }

        [TestInitialize]
        public virtual void Initialize()
        {
            this.BunnyWarCollection = BunnyWarsStructureInitializer.Create();
        }
    }
}
