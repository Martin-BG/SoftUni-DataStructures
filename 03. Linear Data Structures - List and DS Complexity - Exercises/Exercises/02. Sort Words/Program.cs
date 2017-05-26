using System;
using System.Collections.Generic;

namespace _02.Sort_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();

            string[] input = Console.ReadLine().Split(' ');

            foreach (string number in input)
            {
                words.Add(number);
            }

            words.Sort();

            foreach (string word in words)
            {
                Console.Write($"{word} ");
            }
        }
    }
}
