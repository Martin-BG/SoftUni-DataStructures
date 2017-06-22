using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private LinkedList<KeyValue<TKey, TValue>>[] hashTable;
    private const int DefaultCapacity = 16;
    private const float LoadFactor = 0.75f;

    private int maxElements;

    public int Count { get; private set; }

    public int Capacity => this.hashTable.Length;

    public HashTable(int capacity = DefaultCapacity)
    {
        this.hashTable = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        this.maxElements = (int)(capacity * LoadFactor);
        this.Count = 0;
    }

    public void Add(TKey key, TValue value)
    {
        this.CheckGrowth();

        int hash = GetHash(key);

        if (this.hashTable[hash] == null)
        {
            this.hashTable[hash] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (KeyValue<TKey, TValue> keyValue in this.hashTable[hash])
        {
            if (keyValue.Key.Equals(key))
            {
                throw new ArgumentException();
            }
        }

        this.hashTable[hash].AddLast(new KeyValue<TKey, TValue>(key, value));

        this.Count++;
    }

    private int GetHash(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % this.Capacity;
    }

    private void CheckGrowth()
    {
        if (this.Count < maxElements)
        {
            return;
        }

        this.Growth();

        maxElements = (int)(this.Capacity * LoadFactor);
    }

    private void Growth()
    {
        HashTable<TKey, TValue> newTable = new HashTable<TKey, TValue>(this.Capacity * 2);

        foreach (LinkedList<KeyValue<TKey, TValue>> linkedList in this.hashTable)
        {
            if (linkedList == null)
            {
                continue;
            }

            foreach (KeyValue<TKey, TValue> keyValue in linkedList)
            {
                newTable.Add(keyValue.Key, keyValue.Value);
            }
        }

        this.hashTable = newTable.hashTable;

        this.Count = newTable.Count;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        this.CheckGrowth();

        int hash = GetHash(key);

        if (this.hashTable[hash] == null)
        {
            this.hashTable[hash] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (KeyValue<TKey, TValue> keyValue in this.hashTable[hash])
        {
            if (keyValue.Key.Equals(key))
            {
                keyValue.Value = value;
                return true;
            }
        }

        this.hashTable[hash].AddLast(new KeyValue<TKey, TValue>(key, value));

        this.Count++;

        return false;
    }

    public TValue Get(TKey key)
    {
        KeyValue<TKey, TValue> kvp = this.Find(key);

        if (kvp == null)
        {
            throw new KeyNotFoundException();
        }

        return kvp.Value;
    }

    public TValue this[TKey key]
    {
        get => this.Get(key);
        set => this.AddOrReplace(key, value);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        KeyValue<TKey, TValue> kvp = this.Find(key);

        if (kvp != null)
        {
            value = kvp.Value;
            return true;
        }

        value = default(TValue);
        return false;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        int hash = this.GetHash(key);

        if (this.hashTable[hash] != null)
        {
            foreach (KeyValue<TKey, TValue> keyValue in this.hashTable[hash])
            {
                if (key.Equals(keyValue.Key))
                {
                    return keyValue;
                }
            }
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        return this.Find(key) != null;
    }

    public bool Remove(TKey key)
    {
        KeyValue<TKey, TValue> kvp = this.Find(key);

        if (kvp != null)
        {
            int hash = GetHash(key);

            this.hashTable[hash].Remove(kvp);

            this.Count--;

            return true;
        }

        return false;
    }

    public void Clear()
    {
        this.hashTable = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
        this.maxElements = (int)(this.Capacity * LoadFactor);
        this.Count = 0;
    }

    public IEnumerable<TKey> Keys => this.hashTable
        .Where(list => list != null)
        .SelectMany(x => x.Select(y => y.Key));

    public IEnumerable<TValue> Values => this.hashTable
        .Where(list => list != null)
        .SelectMany(x => x.Select(y => y.Value));

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (LinkedList<KeyValue<TKey, TValue>> linkedList in this.hashTable)
        {
            if (linkedList != null)
            {
                foreach (KeyValue<TKey, TValue> keyValue in linkedList)
                {
                    yield return keyValue;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}