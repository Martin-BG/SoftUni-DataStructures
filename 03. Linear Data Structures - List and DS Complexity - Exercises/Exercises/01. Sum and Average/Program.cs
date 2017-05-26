using System;
using System.Collections.Generic;

namespace _01.Sum_and_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();

            string[] numbers = Console.ReadLine().Split(' ');

            foreach (string number in numbers)
            {
                int num;
                if (Int32.TryParse(number, out num))
                {
                    nums.Add(num);
                }
            }

            int sum = 0;
            double avrg = 0d;

            foreach (int num in nums)
            {
                sum += num;
            }

            if (sum != 0)
            {
                avrg = (double)sum / nums.Count;
            }

            Console.WriteLine($"Sum={sum}; Average={avrg:F2}");
        }
    }
}
