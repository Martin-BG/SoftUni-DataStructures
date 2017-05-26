using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class Node<T>
    {
        public T Value { get; private set; }

        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }

    private Node<T> Head;
    private Node<T> Tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.Count == 0)
        {
            this.Head = new Node<T>(element);
            this.Tail = this.Head;
        }
        else
        {
            Node<T> newHead = new Node<T>(element);
            newHead.Next = this.Head;
            this.Head.Prev = newHead;
            this.Head = newHead;
        }

        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            this.Head = new Node<T>(element);
            this.Tail = this.Head;
        }
        else
        {
            Node<T> newTail = new Node<T>(element);
            newTail.Prev = this.Tail;
            this.Tail.Next = newTail;
            this.Tail = newTail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List empty");
        }

        T oldHeadValue = this.Head.Value;

        if (this.Count == 1)
        {
            this.Head = null;
            this.Tail = null;
        }
        else
        {
            this.Head = this.Head.Next;
            this.Head.Prev = null;
        }

        this.Count--;
        return oldHeadValue;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List empty");
        }

        T oldTailValue = this.Tail.Value;

        if (this.Count == 1)
        {
            this.Head = null;
            this.Tail = null;
        }
        else
        {
            this.Tail = this.Tail.Prev;
            this.Tail.Next = null;
        }

        this.Count--;
        return oldTailValue;
    }

    public void ForEach(Action<T> action)
    {
        Node<T> currentNode = this.Head;

        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = this.Head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];

        Node<T> current = this.Head;

        int index = 0;
        while (current != null)
        {
            array[index++] = current.Value;
            current = current.Next;
        }

        return array;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
