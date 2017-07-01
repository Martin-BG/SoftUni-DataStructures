using System.Collections.Generic;

namespace Hierarchy.Core
{
    internal class Node<T>
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
