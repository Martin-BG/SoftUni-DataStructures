using System;
using System.Collections.Generic;

public class Trie<Value>
{
    private Node root;

    private class Node
    {
        public Value Val;
        public bool IsTerminal;
        public Dictionary<char, Node> Next = new Dictionary<char, Node>();
    }

    public Value GetValue(string key)
    {
        Node node = this.GetNode(this.root, key, 0);
        if (node == null || !node.IsTerminal)
        {
            throw new InvalidOperationException();
        }

        return node.Val;
    }

    public bool Contains(string key)
    {
        Node node = this.GetNode(this.root, key, 0);
        return node != null && node.IsTerminal;
    }

    public void Insert(string key, Value val)
    {
        this.root = this.Insert(this.root, key, val, 0);
    }

    public IEnumerable<string> GetByPrefix(string prefix)
    {
        Queue<string> results = new Queue<string>();
        Node node = this.GetNode(this.root, prefix, 0);

        this.Collect(node, prefix, results);

        return results;
    }

    private Node GetNode(Node node, string key, int d)
    {
        if (node == null)
        {
            return null;
        }

        if (d == key.Length)
        {
            return node;
        }

        Node currentNode = null;
        char c = key[d];

        if (node.Next.ContainsKey(c))
        {
            currentNode = node.Next[c];
        }

        return this.GetNode(currentNode, key, d + 1);
    }

    private Node Insert(Node node, string key, Value val, int d)
    {
        if (node == null)
        {
            node = new Node();
        }

        if (d == key.Length)
        {
            node.Val = val;
            node.IsTerminal = true;
            return node;
        }

        Node currentNode = null;
        char c = key[d];

        if (node.Next.ContainsKey(c))
        {
            currentNode = node.Next[c];
        }

        node.Next[c] = this.Insert(currentNode, key, val, d + 1);
        return node;
    }

    private void Collect(Node node, string prefix, Queue<string> results)
    {
        if (node == null)
        {
            return;
        }

        if (node.Val != null && node.IsTerminal)
        {
            results.Enqueue(prefix);
        }

        foreach (char c in node.Next.Keys)
        {
            this.Collect(node.Next[c], prefix + c, results);
        }
    }

    public void Delete(string key)
    {
        this.root = this.Delete(this.root, key, 0);
    }

    private Node Delete(Node node, string key, int d)
    {
        if (node == null)
        {
            return null;
        }

        Node currentNode = null;
        if (d == key.Length)
        {
            node.IsTerminal = false;
            return node;
        }
        char c = key[d];

        if (node.Next.ContainsKey(c))
        {
            currentNode = node.Next[c];
        }

        node.Next[c] = this.Delete(currentNode, key, d + 1);
        return node;
    }
}