using System;
using System.Collections.Generic;

public class BinarySearchTree<T> : IBinarySearchTree<T> where T:IComparable
{
    private Node _root;

    private Node FindElement(T element)
    {
        var current = _root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    private void PreOrderCopy(Node node)
    {
        while (true)
        {
            if (node == null)
            {
                return;
            }

            Insert(node.Value);
            PreOrderCopy(node.Left);
            node = node.Right;
        }
    }

    private static Node Insert(T element, Node node)
    {
        if (node == null)
        {
            node = new Node(element);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = Insert(element, node.Left);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = Insert(element, node.Right);
        }

        node.Count = Count(node.Left) + Count(node.Right) + 1;

        return node;
    }

    private static void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        while (true)
        {
            if (node == null)
            {
                return;
            }

            var nodeInLowerRange = startRange.CompareTo(node.Value);
            var nodeInHigherRange = endRange.CompareTo(node.Value);

            if (nodeInLowerRange < 0)
            {
                Range(node.Left, queue, startRange, endRange);
            }
            if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
            {
                queue.Enqueue(node.Value);
            }
            if (nodeInHigherRange > 0)
            {
                node = node.Right;
                continue;
            }
            break;
        }
    }

    private static void EachInOrder(Node node, Action<T> action)
    {
        while (true)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(node.Left, action);
            action(node.Value);
            node = node.Right;
        }
    }

    private BinarySearchTree(Node node)
    {
        PreOrderCopy(node);
    }

    public BinarySearchTree()
    {
        _root = null;
    }
    
    public void Insert(T element)
    {
        _root = Insert(element, _root);
    }
    
    public bool Contains(T element)
    {
        var current = FindElement(element);

        return current != null;
    }

    public void EachInOrder(Action<T> action)
    {
        EachInOrder(_root, action);
    }

    public BinarySearchTree<T> Search(T element)
    {
        var current = FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    public void DeleteMin()
    {
        if (_root == null)
        {
            throw new InvalidOperationException();
        }

        _root = DeleteMin(_root);
    }

    private static Node DeleteMin(Node node)
    {
        if (node == null)
        {
            return null;
        }

        if (node.Left == null)
        {
            return node.Right;
        }

        node.Left =  DeleteMin(node.Left);
        node.Count = Count(node.Left) + Count(node.Right) + 1;
        return node;
    }

    public void DeleteMax()
    {
        if (_root == null)
        {
            throw new InvalidOperationException();
        }

        _root = DeleteMax(_root);
    }

    private static Node DeleteMax(Node node)
    {
        if (node == null)
        {
            return null;
        }

        if (node.Right == null)
        {
            return node.Left;
        }

        node.Right = DeleteMax(node.Right);
        node.Count = Count(node.Left) + Count(node.Right) + 1;
        return node;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        var queue = new Queue<T>();

        Range(_root, queue, startRange, endRange);

        return queue;
    }

    public void Delete(T element)
    {
        if (_root == null)
        {
            throw new InvalidOperationException();
        }

        _root = Delete(_root, element);
    }

    private static Node Delete(Node node, T item)
    {
        if (node == null)
        {
            return null;
        }

        var cmp = item.CompareTo(node.Value);

        if (cmp < 0)
        {
            node.Left = Delete(node.Left, item);
        }
        else if (cmp > 0)
        {
            node.Right = Delete(node.Right, item);
        }
        else
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            if (node.Left == null)
            {
                return node.Right;
            }

            var temp = FindMin(node.Right);
            temp.Right = DeleteMin(node.Right);
            temp.Left = node.Left;
            node = temp;
        }

        node.Count = Count(node.Left) + Count(node.Right) + 1;
        return node;
    }

    private static Node FindMin(Node node)
    {
        while (true)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Left == null)
            {
                return node;
            }

            node = node.Left;
        }
    }

    public int Count()
    {
        return Count(_root);
    }

    private static int Count(Node node)
    {
        return node?.Count ?? 0;
    }

    public int Rank(T element)
    {
        return GetRankOfT(_root, element);
    }

    private static int GetRankOfT(Node node, T element)
    {
        while (true)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.Value.CompareTo(element) > 0)
            {
                node = node.Left;
                continue;
            }

            if (node.Value.CompareTo(element) < 0)
            {
                return 1 + Count(node.Left) + GetRankOfT(node.Right, element);
            }

            return Count(node.Left);
        }
    }

    public T Select(int rank)
    {
        var node = Select(_root, rank);

        if (node == null)
        {
            throw new InvalidOperationException();
        }

        return node.Value;
    }

    private Node Select(Node node, int rank)
    {
        while (true)
        {
            if (node == null)
            {
                return null;
            }

            if (Rank(node.Value) < rank)
            {
                node = node.Right;
                continue;
            }

            if (Rank(node.Value) <= rank)
            {
                return node;
            }

            node = node.Left;
        }
    }

    public T Ceiling(T element)
    {
        var node = Ceiling(_root, element);

        if (node == null)
        {
            throw new InvalidOperationException();
        }

        return node.Value;
    }

    private static Node Ceiling(Node node, T element)
    {
        while (true)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.CompareTo(element) <= 0)
            {
                node = node.Right;
                continue;
            }

            if (!(node.Left?.Value.CompareTo(element) > 0))
            {
                return node;
            }

            node = node.Left;
        }
    }

    public T Floor(T element)
    {
        var node = Floor(_root, element);

        if (node == null)
        {
            throw new InvalidOperationException();
        }

        return node.Value;
    }

    private static Node Floor(Node node, T element)
    {
        while (true)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.CompareTo(element) >= 0)
            {
                node = node.Left;
                continue;
            }
            if (!(node.Right?.Value.CompareTo(element) < 0))
            {
                return node;
            }

            node = node.Right;
        }
    }

    private class Node
    {
        public int Count { get; set; }
        public Node(T value)
        {
            Value = value;
            Count = 1;
        }

        public T Value { get; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        var bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        bst.EachInOrder(Console.WriteLine);
        Console.WriteLine("Nodes : " + bst.Count());

        Console.WriteLine("Rank 8 = " + bst.Rank(8));
        Console.WriteLine("Rank 45 = " + bst.Rank(45));
        Console.WriteLine("Rank 1 = " + bst.Rank(1));
        Console.WriteLine("Rank 50 = " + bst.Rank(50));
        Console.WriteLine("Ceiling 4 = " + bst.Ceiling(4));
      //  Console.WriteLine("Ceiling 50 = " + bst.Ceiling(50));
        Console.WriteLine("Ceiling 13 = " + bst.Ceiling(13));

    //    Console.WriteLine("Floor -10 = " + bst.Floor(-10));
        Console.WriteLine("Floor 5 = " + bst.Floor(5));
        Console.WriteLine("Floor 50 = " + bst.Floor(50));

        Console.WriteLine("Select 4 = " + bst.Select(4));

        Console.WriteLine("Delete 37");
        bst.Delete(37);
        bst.EachInOrder(Console.WriteLine);
        Console.WriteLine("Insert 37");
        bst.Insert(37);
        Console.WriteLine("Delete 5");
        bst.Delete(5);
        bst.EachInOrder(Console.WriteLine);

        bst.DeleteMax();

        bst.EachInOrder(Console.WriteLine);
        Console.WriteLine("Nodes : " + bst.Count());

        bst.DeleteMin();

        bst.EachInOrder(Console.WriteLine);
        Console.WriteLine("Nodes : " + bst.Count());

        bst.Delete(37);
        bst.EachInOrder(Console.WriteLine);
        Console.WriteLine("Nodes : " + bst.Count());
    }
}