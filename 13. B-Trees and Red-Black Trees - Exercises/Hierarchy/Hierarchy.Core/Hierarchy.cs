using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections;

public class Hierarchy<T> : IHierarchy<T>
{
    private Node<T> root;
    private Dictionary<T, Node<T>> nodes;

    public Hierarchy(T root)
    {
        this.root = new Node<T>(root);
        this.nodes = new Dictionary<T, Node<T>>();
        this.nodes.Add(root, this.root);
    }

    public int Count => nodes.Count;

    public void Add(T element, T child)
    {
        Node<T> parent;
        if (!this.nodes.TryGetValue(element, out parent))
        {
            throw new ArgumentException("Parent not found");
        }

        if (this.nodes.ContainsKey(child))
        {
            throw new ArgumentException("Child already has parent");
        }

        var childNode = new Hierarchy<T>.Node<T>(child, parent);
        this.nodes[child] = childNode;
        parent.Children.Add(childNode);
    }

    public void Remove(T element)
    {
        Node<T> node;

        if (!this.nodes.TryGetValue(element, out node))
        {
            throw new ArgumentException("Element not found");
        }

        if (node.Parent == null)
        {
            throw new ArgumentException("Cannot delete root");
        }

        node.Parent.Children.AddRange(node.Children);

        var childrenCount = node.Children.Count;
        var nodeParent = node.Parent;
        for (var index = 0; index < childrenCount; index++)
        {
            node.Children[index].Parent = nodeParent;
        }

        this.nodes.Remove(element);
        node.Parent.Children.Remove(node);
    }

    public IEnumerable<T> GetChildren(T item)
    {
        Node<T> node;
        if (!this.nodes.TryGetValue(item, out node))
        {
            throw new ArgumentException("Element not found");
        }

        return node.Children.Select(n => n.Value);
    }

    public T GetParent(T item)
    {
        Node<T> node;
        if (!this.nodes.TryGetValue(item, out node))
        {
            throw new ArgumentException("Element does not found");
        }

        return node.Parent != null ? node.Parent.Value : default(T);
    }

    public bool Contains(T value)
    {
        return this.nodes.ContainsKey(value);
    }

    public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
    {
        return this.nodes
            .Keys
            .Where(key => other.nodes.ContainsKey(key))
            .ToList();
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (this.Count == 0)
            yield break;

        var queue = new Queue<Node<T>>();
        queue.Enqueue(this.root);
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            yield return current.Value;

            foreach (var subordinate in current.Children)
            {
                queue.Enqueue(subordinate);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class Node<T>
    {
        public Node(T value, Node<T> parent = null)
        {
            this.Parent = parent;
            this.Value = value;
            this.Children = new List<Node<T>>();
        }

        public T Value { get; set; }

        public Node<T> Parent { get; set; }

        public List<Node<T>> Children { get; set; }
    }
}
