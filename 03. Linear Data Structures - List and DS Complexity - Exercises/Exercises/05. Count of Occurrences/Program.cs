using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Count_of_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MaxNumber = 1001;
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            int[] occurences = new int[MaxNumber];

            foreach (int number in numbers)
            {
                occurences[number]++;
            }

            for (int i = 0; i < MaxNumber - 1; i++)
            {
                if (occurences[i] > 0)
                {
                    Console.WriteLine($"{i} -> {occurences[i]} times");
                }
            }
        }
    }
}
