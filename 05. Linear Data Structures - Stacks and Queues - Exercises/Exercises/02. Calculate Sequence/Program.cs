using System;
using System.Collections.Generic;

namespace _02.Calculate_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            int num = int.Parse(Console.ReadLine());

            queue.Enqueue(num);

            int index = 0;
            int [] numbers = new int[50];

            while (index < 50)
            {
                num = queue.Dequeue();
                numbers[index++] = num;

                queue.Enqueue(num + 1);
                queue.Enqueue(2 * num + 1);
                queue.Enqueue(num + 2);
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
