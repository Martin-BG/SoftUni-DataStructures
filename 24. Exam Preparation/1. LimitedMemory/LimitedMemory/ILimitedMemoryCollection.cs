using System.Collections.Generic;

namespace LimitedMemory
{
    public interface ILimitedMemoryCollection<TK, TV> : IEnumerable<Pair<TK, TV>>
    {
        int Capacity { get; }

        int Count { get; }

        void Set(TK key, TV value);

        TV Get(TK key);
    }
}
