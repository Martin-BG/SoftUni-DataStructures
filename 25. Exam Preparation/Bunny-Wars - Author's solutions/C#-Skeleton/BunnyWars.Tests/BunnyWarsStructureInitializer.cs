namespace BunnyWars.Tests
{
    using BunnyWars.Core;

    public static class BunnyWarsStructureInitializer
    {
        public static IBunnyWarsStructure Create()
        {
            return new BunnyWarsStructure();
        }
    }
}
