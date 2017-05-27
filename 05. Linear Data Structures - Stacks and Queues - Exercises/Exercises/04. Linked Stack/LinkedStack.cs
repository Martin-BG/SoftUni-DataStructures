using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{
    public class LinkedStack<T>
    {
        private Node<T> firstNode;
        public int Count { get; private set; }

        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element, this.firstNode);
            this.firstNode = newNode;
            this.Count++;
        }

        public T Pop()
        {
            T value = firstNode.value;
            firstNode = firstNode.NextNode;
            this.Count--;
            return value;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            Node<T> current = this.firstNode;
            int index = 0;

            while (current != null)
            {
                array[index++] = current.value;
                current = current.NextNode;
            }

            return array;
        }

        private class Node<T>
        {
            public T value;
            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                this.value = value;
                this.NextNode = nextNode;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //LinkedStack<int> myStack = new LinkedStack<int>();

            //myStack.Push(0);
            //myStack.Push(1);
            //myStack.Push(2);
            //myStack.Push(3);
            //myStack.Push(4);

            //int[] arr = myStack.ToArray();

            //Console.WriteLine(string.Join(", ", arr));

            //Console.WriteLine(myStack.Pop());
            //Console.WriteLine(myStack.Pop());
            //Console.WriteLine(myStack.Pop());
            //Console.WriteLine(myStack.Pop());
            //myStack.Push(5);
            //myStack.Push(6);

            //Console.WriteLine(string.Join(", ", myStack.ToArray()));
        }
    }
}

