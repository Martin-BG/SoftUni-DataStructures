using System;
using System.Collections.Generic;
using System.Linq;

public class QuadTree<T> where T : IBoundable
{
    public const int DefaultMaxDepth = 5;

    public readonly int MaxDepth;

    private readonly Node<T> _root;

    public QuadTree(int width, int height, int maxDepth = DefaultMaxDepth)
    {
        _root = new Node<T>(0, 0, width, height);

        Bounds = _root.Bounds;

        MaxDepth = maxDepth;
    }

    public int Count { get; private set; }

    public Rectangle Bounds { get; }

    public void ForEachDfs(Action<List<T>, int, int> action)
    {
        ForEachDfs(_root, action);
    }

    public bool Insert(T item)
    {
        if (!item.Bounds.IsInside(Bounds))
        {
            return false;
        }

        var depth = 1;
        var currNode = _root;

        while (currNode.Children != null)
        {
            var quadrant = GetQuadrant(currNode, item.Bounds);

            if (quadrant == -1)
            {
                break;
            }

            currNode = currNode.Children[quadrant];
            depth++;
        }

        currNode.Items.Add(item);

        TrySplit(currNode, depth);

        Count++;

        return true;
    }

    private static int GetQuadrant(Node<T> node, Rectangle bounds)
    {
        if (node.Children == null)
        {
            return -1;
        }

        for (var quadrant = 0; quadrant < 4; quadrant++)
        {
            if (bounds.IsInside(node.Children[quadrant].Bounds))
            {
                return quadrant;
            }
        }

        return -1;
    }

    private void TrySplit(Node<T> node, int depth)
    {
        if (!(node.ShouldSplit && depth < MaxDepth))
        {
            return;
        }

        var leftWidth = node.Bounds.Width / 2;
        var rightWidth = node.Bounds.Width - leftWidth;
        var topHeight = node.Bounds.Height / 2;
        var bottomHeight = node.Bounds.Height - topHeight;

        node.Children = new[]
        {
            new Node<T>(node.Bounds.MidX, node.Bounds.MidY, rightWidth, topHeight),
            new Node<T>(node.Bounds.X1, node.Bounds.MidY, leftWidth, topHeight),
            new Node<T>(node.Bounds.X1, node.Bounds.Y1, leftWidth, bottomHeight),
            new Node<T>(node.Bounds.MidX, node.Bounds.Y1, rightWidth, bottomHeight)
        };

        for (var i = 0; i < node.Items.Count;)
        {
            var item = node.Items[i];
            var quadrant = GetQuadrant(node, item.Bounds);
            if (quadrant != -1)
            {
                node.Items.Remove(item);
                node.Children[quadrant].Items.Add(item);
            }
            else
            {
                i++;
            }
        }

        foreach (var child in node.Children)
        {
            TrySplit(child, depth + 1);
        }
    }

    public List<T> Report(Rectangle bounds)
    {
        var collisionCandidates = new List<T>();

        GetCollisionCandidates(_root, bounds, collisionCandidates);

        return collisionCandidates;
    }

    private void GetCollisionCandidates(Node<T> node, Rectangle bounds, List<T> results)
    {
        var quadrant = GetQuadrant(node, bounds);

        if (quadrant == -1)
        {
            GetSubtreeContents(node, bounds, results);
        }
        else
        {
            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    if (bounds.IsInside(child.Bounds))
                    {
                        GetCollisionCandidates(child, bounds, results);
                    }
                }
            }

            results.AddRange(node.Items);
        }
    }

    private static void GetSubtreeContents(Node<T> node, Rectangle bounds, List<T> results)
    {
        if (node.Children != null)
        {
            foreach (var child in node.Children)
            {
                if (child.Bounds.Intersects(bounds))
                {
                    GetSubtreeContents(child, bounds, results);
                }
            }
        }

        results.AddRange(node.Items);
    }

    private static void ForEachDfs(Node<T> node, Action<List<T>, int, int> action, int depth = 1, int quadrant = 0)
    {
        if (node == null)
        {
            return;
        }

        if (node.Items.Any())
        {
            action(node.Items, depth, quadrant);
        }

        if (node.Children == null)
        {
            return;
        }

        for (var i = 0; i < node.Children.Length; i++)
        {
            ForEachDfs(node.Children[i], action, depth + 1, i);
        }
    }
}
