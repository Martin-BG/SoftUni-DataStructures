using System;
using System.Collections;
using System.Linq;

namespace _01.Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Stack stack = new Stack();
            
            foreach (int num in numbers)
            {
                stack.Push(num);
            }
            
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
