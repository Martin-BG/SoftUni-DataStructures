using System.Collections.Generic;
using System.Collections;

namespace LimitedMemory
{
    public class LimitedMemoryCollection<TK, TV> : ILimitedMemoryCollection<TK, TV>
    {
        private readonly LinkedList<Pair<TK, TV>> _priority;
        private readonly Dictionary<TK, LinkedListNode<Pair<TK, TV>>> _elements;

        public LimitedMemoryCollection(int capacity)
        {
            Capacity = capacity;
            _priority = new LinkedList<Pair<TK, TV>>();
            _elements = new Dictionary<TK, LinkedListNode<Pair<TK, TV>>>();
        } 

        public IEnumerator<Pair<TK, TV>> GetEnumerator()
        {
            return ((IEnumerable<Pair<TK, TV>>) _priority).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Capacity { get; }

        public int Count => _elements.Count;

        public void Set(TK key, TV value)
        {
            if (!_elements.ContainsKey(key))
            {
                if (Count >= Capacity)
                {
                    RemoveOldestElement();
                }

                AddElement(key, value);
            }
            else
            {
                var node = _elements[key];
                node.Value.Value = value;
                _priority.Remove(node);
                _priority.AddFirst(node);
            }
        }

        private void AddElement(TK key, TV value)
        {
            var node = new LinkedListNode<Pair<TK, TV>>(new Pair<TK,TV>(key, value));
            _elements.Add(key, node);
            _priority.AddFirst(node);
        }

        private void RemoveOldestElement()
        {
            var oldest = _priority.Last;
            _elements.Remove(oldest.Value.Key);
            _priority.RemoveLast();
        }

        public TV Get(TK key)
        {
            if (!_elements.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }

            var node = _elements[key];
            _priority.Remove(node);
            _priority.AddFirst(node);

            return node.Value.Value;
        }
    }
}
