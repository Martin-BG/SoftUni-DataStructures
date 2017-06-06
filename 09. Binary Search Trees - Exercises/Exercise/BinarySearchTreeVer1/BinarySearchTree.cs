using System;
using System.Collections.Generic;

public class BinarySearchTree<T> : IBinarySearchTree<T> where T:IComparable
{
    private Node root;

    private Node FindElement(T element)
    {
        Node current = this.root;

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
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.PreOrderCopy(node.Left);
        this.PreOrderCopy(node.Right);
    }

    private Node Insert(T element, Node node)
    {
        if (node == null)
        {
            node = new Node(element);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = this.Insert(element, node.Left);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = this.Insert(element, node.Right);
        }

        node.Count = Count(node.Left) + Count(node.Right) + 1;

        return node;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange < 0)
        {
            this.Range(node.Left, queue, startRange, endRange);
        }
        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (nodeInHigherRange > 0)
        {
            this.Range(node.Right, queue, startRange, endRange);
        }
    }
    
    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private BinarySearchTree(Node node)
    {
        this.PreOrderCopy(node);
    }

    public BinarySearchTree()
    {
        this.root = null;
    }
    
    public void Insert(T element)
    {
        this.root = this.Insert(element, this.root);
    }
    
    public bool Contains(T element)
    {
        Node current = this.FindElement(element);

        return current != null;
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        this.root = DeleteMin(this.root);
    }

    private Node DeleteMin(Node node)
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
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        this.root = DeleteMax(this.root);
    }

    private Node DeleteMax(Node node)
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
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    public void Delete(T element)
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        this.root = Delete(this.root, element);
    }

    private Node Delete(Node node, T item)
    {
        if (node == null)
        {
            return null;
        }

        int cmp = item.CompareTo(node.Value);

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

    private Node FindMin(Node node)
    {
        if (node == null)
        {
            return null;
        }

        if (node.Left == null)
        {
            return node;
        }

        return FindMin(node.Left);
    }

    public int Count()
    {
        return Count(this.root);
    }

    private int Count(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Count;
    }

    public int Rank(T element)
    {
        return this.GetRankOfT(this.root, element);
    }

    private int GetRankOfT(Node node, T element)
    {
        if (node == null)
        {
            return 0;
        }

        if (node.Value.CompareTo(element) > 0)
        {
            return GetRankOfT(node.Left, element);
        }

        if (node.Value.CompareTo(element) < 0)
        {
            return 1 + Count(node.Left) + GetRankOfT(node.Right, element);
        }

        return Count(node.Left);
    }

    public T Select(int rank)
    {
        Node node = Select(this.root, rank);

        if (node == null)
        {
            throw new InvalidOperationException();
        }

        return node.Value;
    }

    private Node Select(Node node, int rank)
    {
        if (node == null)
        {
            return null;
        }

        if (Rank(node.Value) < rank)
        {
            return Select(node.Right, rank);
        }

        if (Rank(node.Value) > rank)
        {
            return Select(node.Left, rank);
        }

        return node;
    }

    public T Ceiling(T element)
    {
        Node node = Ceiling(this.root, element);

        if (node == null)
        {
            throw new InvalidOperationException();
        }

        return node.Value;
    }

    private Node Ceiling(Node node, T element)
    {
        if (node == null)
        {
            return null;
        }

        if (node.Value.CompareTo(element) <= 0)
        {
            return Ceiling(node.Right, element);
        }
        if (node.Left?.Value.CompareTo(element) > 0)
        {
            return Ceiling(node.Left, element);
        }

        return node;
    }

    public T Floor(T element)
    {
        Node node = Floor(this.root, element);

        if (node == null)
        {
            throw new InvalidOperationException();
        }

        return node.Value;
    }

    private Node Floor(Node node, T element)
    {
        if (node == null)
        {
            return null;
        }

        if (node.Value.CompareTo(element) >= 0)
        {
            return Floor(node.Left, element);
        }
        if (node.Right?.Value.CompareTo(element) < 0)
        {
            return Floor(node.Right, element);
        }

        return node;
    }

    private class Node
    {
        public int Count { get; set; }
        public Node(T value)
        {
            this.Value = value;
            this.Count = 1;
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
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

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