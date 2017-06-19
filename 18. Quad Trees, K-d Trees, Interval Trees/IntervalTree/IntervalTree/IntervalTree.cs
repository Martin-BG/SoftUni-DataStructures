using System;
using System.Collections.Generic;

public class IntervalTree
{
    private class Node
    {
        internal Interval interval;
        internal double max;
        internal Node right;
        internal Node left;

        public Node(Interval interval)
        {
            this.interval = interval;
            this.max = interval.Hi;
        }
    }

    private Node root;

    public void Insert(double lo, double hi)
    {
        this.root = this.Insert(this.root, lo, hi);
    }

    public void EachInOrder(Action<Interval> action)
    {
        EachInOrder(this.root, action);
    }

    public Interval SearchAny(double lo, double hi)
    {
        var current = this.root;

        while (current != null && !current.interval.Intersects(lo, hi))
        {
            if (current.left != null && lo < current.left.max)
            {
                current = current.left;
            }
            else
            {
                current = current.right;
            }
        }

        if (current == null)
        {
            return null;
        }

        return current.interval;
    }

    public IEnumerable<Interval> SearchAll(double lo, double hi)
    {
        var results = new List<Interval>();
        SerachAll(this.root, lo, hi, results);
        return results;
    }

    private void SerachAll(Node node, double lo, double hi, List<Interval> results)
    {
        if (node == null)
        {
            return;
        }

        var goLeft = node.left != null && node.left.max > lo;
        var goRight = node.right != null && node.right.interval.Lo < hi;

        if (goLeft)
        {
            SerachAll(node.left, lo, hi, results);
        }

        if (node.interval.Intersects(lo, hi))
        {
            results.Add(node.interval);
        }

        if (goRight)
        {
            SerachAll(node.right, lo, hi, results);
        }
    }

    private void EachInOrder(Node node, Action<Interval> action)
    {
        if (node == null)
        {
            return;
        }

        EachInOrder(node.left, action);
        action(node.interval);
        EachInOrder(node.right, action);
    }

    private Node Insert(Node node, double lo, double hi)
    {
        if (node == null)
        {
            return new Node(new Interval(lo, hi));
        }

        int cmp = lo.CompareTo(node.interval.Lo);
        if (cmp < 0)
        {
            node.left = Insert(node.left, lo, hi);
        }
        else if (cmp > 0)
        {
            node.right = Insert(node.right, lo, hi);
        }

        UpdateMax(node);
        return node;
    }

    private void UpdateMax(Node node)
    {
        var maxChild = GetMax(node.left, node.right);

        node.max = GetMax(node, maxChild).max;
    }

    private Node GetMax(Node a, Node b)
    {
        if (a == null)
        {
            return b;
        }

        if (b == null)
        {
            return a;
        }

        return a.max.CompareTo(b.max) > 0 ? a : b;
    }
}
