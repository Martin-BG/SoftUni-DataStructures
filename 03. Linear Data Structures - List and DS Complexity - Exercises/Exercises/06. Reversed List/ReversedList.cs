using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private T[] Data;
    private const int DefaultCapacity = 2;

    public ReversedList(int capacity = DefaultCapacity)
    {
        this.Capacity = capacity;
        this.Data = new T[capacity];
    }

    public int Count
    {
        get;
        private set;
    }

    public int Capacity
    {
        get;
        private set;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.Data[this.Count - 1 - index];
        }

        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Data[this.Count - 1 - index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.Count >= this.Data.Length)
        {
            T[] newData = new T[this.Data.Length * 2];

            Array.Copy(this.Data, newData, this.Data.Length);
            this.Data = newData;
        }

        this.Data[this.Count++] = item;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        index = this.Count - 1 - index;
        for (int i = index; i < this.Count - 1; i++)
        {
            this.Data[i] = this.Data[i + 1];
        }
        this.Count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return Data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


class Example
{
    static void Main()
    {
        var list = new ReversedList<int>();

        Console.WriteLine("--------------------");

        list.Add(5);
        list.Add(3);
        list.Add(2);
        list.Add(10);

        Console.WriteLine(string.Join(" ", list));
        Console.WriteLine("Count = {0}", list.Count);

        Console.WriteLine("--------------------");

        list.RemoveAt(0);
        Console.WriteLine(string.Join(" ", list));
        Console.WriteLine("Count = {0}", list.Count);
    }
}

