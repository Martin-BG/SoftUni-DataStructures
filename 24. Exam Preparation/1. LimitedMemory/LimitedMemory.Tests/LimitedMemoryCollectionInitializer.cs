namespace LimitedMemory.Tests
{
    public class LimitedMemoryCollectionInitializer
    {
        public static ILimitedMemoryCollection<K, V> Create<K, V>(int capacity)
        {
            return new LimitedMemoryCollection<K, V>(capacity);
        }
    }
}
