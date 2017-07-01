using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LimitedMemory
{
    public class LimitedMemoryCollection<K, V> : ILimitedMemoryCollection<K, V>
    {
        private LinkedList<Pair<K, V>> recordsInOrder;
        private Dictionary<K, LinkedListNode<Pair<K, V>>> records;

        public LimitedMemoryCollection(int capacity)
        {
            this.recordsInOrder = new LinkedList<Pair<K, V>>();
            this.records = new Dictionary<K, LinkedListNode<Pair<K, V>>>(capacity * 2);
            this.Capacity = capacity;
        }

        public void Set(K key, V value)
        {
            LinkedListNode<Pair<K, V>> linkedListNode;
            if (this.records.TryGetValue(key, out linkedListNode))
            {
                linkedListNode.Value.Value = value;
                this.UpdateToLatest(linkedListNode);
            }
            else
            {
                var pair = new Pair<K, V>() { Key = key, Value = value };
                if (this.Count == this.Capacity)
                {
                    var firstKey = this.recordsInOrder.First.Value.Key;
                    this.records.Remove(firstKey);
                    this.recordsInOrder.RemoveFirst();
                }

                var node = this.recordsInOrder.AddLast(pair);
                this.records.Add(key, node);
            }
        }

        public V Get(K key)
        {
            LinkedListNode<Pair<K, V>> linkedListNode;
            if (!this.records.TryGetValue(key, out linkedListNode))
            {
                throw new KeyNotFoundException("Key not present in collection");
            }

            this.UpdateToLatest(linkedListNode);
            var pair = linkedListNode.Value;

            return pair.Value;
        }

        private void UpdateToLatest(LinkedListNode<Pair<K, V>> node)
        {
            this.recordsInOrder.Remove(node);
            this.recordsInOrder.AddLast(node);
        }

        public int Capacity { get; private set; }

        public int Count
        {
            get
            {
                return this.recordsInOrder.Count;
            }
        }

        public IEnumerator<Pair<K, V>> GetEnumerator()
        {
            return this.recordsInOrder.Reverse().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
