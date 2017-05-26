using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Remove_Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            Dictionary<int, int> occurencies = new Dictionary<int, int>();

            foreach (int number in numbers)
            {
                if (!occurencies.ContainsKey(number))
                {
                    occurencies.Add(number, 0);
                }

                occurencies[number]++;
            }

            foreach (int number in numbers)
            {
                if (occurencies[number] % 2 == 0)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
