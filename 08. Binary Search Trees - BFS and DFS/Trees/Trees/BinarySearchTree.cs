using System;
using System.Collections.Generic;
using System.Reflection;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node Root;

    public BinarySearchTree()
    {
        
    }

    private BinarySearchTree(Node root)
    {
        this.Copy(root);
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }

    private class Node
    {
        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }

    public void Insert(T value)
    {
        if (this.Root == null)
        {
            this.Root = new Node(value);
            return;
        }

        Node current = this.Root;
        Node parent = null;

        while (current != null)
        {
            parent = current;
            if (value.CompareTo(current.Value) < 0)
            {
                current = current.Left;
            }
            else if (value.CompareTo(current.Value) > 0)
            {
                current = current.Right;
            }
            else
            {
                return;
            }
        }

        if (parent != null)
        {
            if (parent.Value.CompareTo(value) < 0)
            {
                parent.Right = new Node(value);
            }
            else
            {
                parent.Left = new Node(value);
            }
        }
    }

    public bool Contains(T value)
    {
        Node current = this.Root;

        while (current != null)
        {
            if (value.CompareTo(current.Value) < 0)
            {
                current = current.Left;
            }
            else if (value.CompareTo(current.Value) > 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current != null;
    }

    public void DeleteMin()
    {
        if (this.Root == null)
        {
            return;
        }

        Node min = this.Root;
        Node parent = null;

        while (min.Left != null)
        {
            parent = min;
            min = min.Left;
        }

        if (parent == null)
        {
            this.Root = this.Root.Right;
        }
        else if (parent.Left == null)
        {
            this.Root = null;
        }
        else
        {
            parent.Left = null;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node current = this.Root;

        while (current != null)
        {
            if (item.CompareTo(current.Value) < 0)
            {
                current = current.Left;
            }
            else if (item.CompareTo(current.Value) > 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return new BinarySearchTree<T>(current);
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> range = new Queue<T>();

        this.Range(startRange, endRange, range, this.Root);

        return range;
    }

    private void Range(T startRange, T endRange, Queue<T> range, Node node)
    {
        if (node == null)
        {
            return;
        }

        int compareLow = startRange.CompareTo(node.Value);
        int compareHigh = endRange.CompareTo(node.Value);

        if (compareLow < 0)
        {
            this.Range(startRange, endRange, range, node.Left);
        }

        if (compareLow <= 0 && compareHigh >= 0)
        {
            range.Enqueue(node.Value);
        }

        if (compareHigh > 0)
        {
            this.Range(startRange, endRange, range, node.Right);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.Root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        EachInOrder(node.Left, action);
        action(node.Value);
        EachInOrder(node.Right, action);
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
    }
}
