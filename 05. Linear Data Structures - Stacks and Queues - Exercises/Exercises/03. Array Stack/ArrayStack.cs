using System;

namespace ArrayStack
{
    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] Elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            Elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (Elements.Length == Count)
                Grow();

            Elements[Count++] = element;
        }


        public T Pop()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            Count--;
            var value = Elements[Count];

            return value;
        }

        public T[] ToArray()
        {
            var array = new T[Count];
            Array.Copy(Elements, array, Count);
            return array;
        }

        private void Grow()
        {
            var newStack = new T[2 * Elements.Length];
            Array.Copy(Elements, newStack, Elements.Length);
            Elements = newStack;
        }
    }


    internal class Program
    {
        private static void Main(string[] args)
        {
            //ArrayStack<int> myStack = new ArrayStack<int>();

            //myStack.Push(0);
            //myStack.Push(1);
            //myStack.Push(2);
            //myStack.Push(3);
            //myStack.Push(4);

            //int[] arr = myStack.ToArray();

            //Console.WriteLine(string.Join(", ", arr));

            //Console.WriteLine(myStack.Pop());

            //Console.WriteLine(string.Join(", ", myStack.ToArray()));
        }
    }
}