using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public Node Head { get; private set; }
    public Node Tail { get; private set; }
    public int Count { get; private set; }

    public LinkedList()
    {
        this.Tail = null;
        this.Head = null;
        this.Count = 0;
    }

    public void AddFirst(T item)
    {
        Node oldHead = this.Head;
        this.Head = new Node(item);

        this.Head.Next = oldHead;
 
        if (this.Count == 0)
        {
            this.Tail = this.Head;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node oldTail = this.Tail;
        this.Tail = new Node(item);

        if (this.Count == 0)
        {
            this.Head = this.Tail;
        }
        else
        {
            oldTail.Next = this.Tail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T oldValue = this.Head.Value;

        this.Head = this.Head.Next;

        this.Count--;

        if (this.Count == 0)
        {
            this.Tail = null;
        }

        return oldValue;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T oldValue = this.Tail.Value;

        if (this.Count == 1)
        {
            this.Head = null;
            this.Tail = null;
        }
        else
        {
            Node newTail = this.SecondToLast();
            newTail.Next = null;
            this.Tail = newTail;
        }

        this.Count--;

        return oldValue;
    }

    private Node SecondToLast()
    {
        Node current = this.Head;

        while (current.Next.Next != null)
        {
            current = current.Next;
        }

        return current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.Head;

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

    public class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        
        public Node(T value)
        {
            this.Value = value;
            this.Next = null;
        }
    }
}
