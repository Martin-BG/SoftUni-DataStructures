namespace Hierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections;
    using System.Diagnostics;
    
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

        public int Count
        {
            get
            {
                return this.nodes.Count;
            }
        }

        public void Add(T element, T child)
        {
            Node<T> parentNode;
            if (!this.nodes.TryGetValue(element, out parentNode))
            {
                throw new ArgumentException("Parent element does not exist in hierarchy");
            }
            
            if (this.nodes.ContainsKey(child))
            {
                throw new ArgumentException("Child cannot have 2 parents");
            }
            
            var childNode = new Node<T>(child, parentNode);
            this.nodes[child] = childNode;
            parentNode.Children.Add(childNode);
        }

        public void Remove(T element)
        {
            Node<T> node;
            if (! this.nodes.TryGetValue(element, out node))
            {
                throw new ArgumentException("Element does not exist in hierarchy");
            }

            if (node.Parent == null)
            {
                throw new InvalidOperationException("Cannot delete root element");
            }

            node.Parent.Children.AddRange(node.Children);
            foreach (var child in node.Children)
            {
                child.Parent = node.Parent;
            }

            this.nodes.Remove(element);
            node.Parent.Children.Remove(node);
        }

        public IEnumerable<T> GetChildren(T item)
        {
            Node<T> node;
            if (!this.nodes.TryGetValue(item, out node))
            {
                throw new ArgumentException("Element does not exist in the hierarchy");
            }

            return node.Children.Select(n => n.Value);
        }

        public T GetParent(T item)
        {
            Node<T> node;
            if (!this.nodes.TryGetValue(item, out node))
            {
                throw new ArgumentException("Element does not exist in the hierarchy");
            }

            return node.Parent != null ? 
                node.Parent.Value : default(T);
        }

        public bool Contains(T value)
        {
            return this.nodes.ContainsKey(value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            var commonElements = new List<T>();
            foreach (T key in this.nodes.Keys)
            {
                if (other.nodes.ContainsKey(key))
                {
                    commonElements.Add(key);
                }
            }

            return commonElements;
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
    }
}