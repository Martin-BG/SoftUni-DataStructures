using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 16;

    private T[] Elements;
    private int StartIndex = 0;
    private int EndIndex = 0;

    public int Count { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.Elements = new T[capacity];
    }

    public void Enqueue(T element)
    {
        if (this.Count >= this.Elements.Length)
        {
            this.Grow();
        }

        this.Elements[this.EndIndex++] = element;
        this.EndIndex %= this.Elements.Length;

        this.Count++;
    }

    private void Grow()
    {
        T[] newArray = new T[this.Elements.Length * 2];
        this.CopyElements(newArray);
        this.Elements = newArray;
        this.StartIndex = 0;
        this.EndIndex = this.Count;
    }

    private void CopyElements(T[] newArray)
    {
        for (int i = 0; i < this.Count; i++)
        {
            newArray[i] = this.Elements[this.StartIndex++];
            this.StartIndex %= this.Elements.Length;
        }
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T value = this.Elements[this.StartIndex++];
        this.StartIndex %= this.Elements.Length;
        this.Count--;

        return value;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        this.CopyElements(array);

        return array;
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
