using System;

public class KdTree
{
    public class Node
    {
        public Node(StarSystem point)
        {
            Point = point;
        }

        public StarSystem Point { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }

    public Node Root { get; private set; }

    public bool Contains(StarSystem point)
    {
        var node = Contains(Root, point, 0);

        return node != null;
    }

    private static Node Contains(Node node, StarSystem point, int depth)
    {
        if (node == null)
        {
            return null;
        }

        var cmp = Compare(node.Point, point, depth);

        if (cmp < 0)
        {
            return Contains(node.Left, point, depth + 1);
        }

        if (cmp > 0)
        {
            return Contains(node.Right, point, depth + 1);
        }

        return node;
    }

    public void Insert(StarSystem point)
    {
        Root = Insert(Root, point, 0);
    }

    public Node Insert(Node node, StarSystem point, int depth)
    {
        if (node == null)
        {
            return new Node(point);
        }

        var cmp = Compare(node.Point, point, depth);

        if (cmp < 0)
        {
            node.Left = Insert(node.Left, point, depth + 1);
        }
        else if (cmp > 0)
        {
            node.Right = Insert(node.Right, point, depth + 1);
        }

        return node;
    }

    private static int Compare(StarSystem a, StarSystem b, int depth)
    {
        var cmp = 0;

        if (depth % 2 == 0)
        {
            cmp = b.X.CompareTo(a.X);

            if (cmp == 0)
            {
                cmp = b.Y.CompareTo(a.Y);
            }
        }
        else
        {
            cmp = b.Y.CompareTo(a.Y);

            if (cmp == 0)
            {
                cmp = b.X.CompareTo(a.X);
            }
        }

        return cmp;
    }

    public void EachInOrder(Action<StarSystem> action)
    {
        EachInOrder(Root, action);
    }

    private static void EachInOrder(Node node, Action<StarSystem> action)
    {
        if (node == null)
        {
            return;
        }

        EachInOrder(node.Left, action);

        action(node.Point);

        EachInOrder(node.Right, action);
    }
}
