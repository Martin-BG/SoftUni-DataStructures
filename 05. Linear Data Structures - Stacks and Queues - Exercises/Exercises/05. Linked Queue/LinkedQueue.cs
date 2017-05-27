using System;

namespace LinkedQueue
{
    public class LinkedQueue<T>
    {
        private QueueNode<T> Head;
        private QueueNode<T> Tail;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            QueueNode<T> newNode = new QueueNode<T> { Value = element };

            if (this.Count == 0)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                this.Tail.NextNode = newNode;
                newNode.PrevNode = this.Tail;
                this.Tail = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            T value = this.Head.Value;

            this.Head.NextNode.PrevNode = null;
            this.Head = this.Head.NextNode;

            this.Count--;

            return value;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            QueueNode<T> current = this.Head;
            int index = 0;

            while (current != null)
            {
                array[index++] = current.Value;
                current = current.NextNode;
            }

            return array;
        }

        private class QueueNode<T>
        {
            public T Value { get; set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //LinkedQueue<int> myStack = new LinkedQueue<int>();

            //myStack.Enqueue(0);
            //myStack.Enqueue(1);
            //myStack.Enqueue(2);
            //myStack.Enqueue(3);
            //myStack.Enqueue(4);

            //int[] arr = myStack.ToArray();

            //Console.WriteLine(string.Join(", ", arr));

            //Console.WriteLine(myStack.Dequeue());
            //Console.WriteLine(myStack.Dequeue());
            //Console.WriteLine(myStack.Dequeue());
            //Console.WriteLine(myStack.Dequeue());
            //myStack.Enqueue(5);
            //myStack.Enqueue(6);

            //Console.WriteLine(string.Join(", ", myStack.ToArray()));
        }
    }
}
