using System;
using System.Collections.Generic;

namespace _06.Sequence_N_M
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = Console.ReadLine().Split(' ');
            int start = int.Parse(values[0]);
            int end = int.Parse(values[1]);

            Queue<Item> queue = new Queue<Item>();

            queue.Enqueue(new Item(start, null));

            while (queue.Count > 0)
            {
                Item item = queue.Dequeue();

                if (item.Value == end)
                {
                    item.PrintSequence();
                    return;
                }

                if (item.Value < end)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int newVal = item.Value;
                        switch (i)
                        {
                            case 0:
                                newVal += 1;
                                break;
                            case 1:
                                newVal += 2;
                                break;
                            case 2:
                                newVal *= 2;
                                break;
                            default:
                                break;
                        }

                        if (newVal == end)
                        {
                            new Item(newVal, item).PrintSequence();
                            return;
                        }
                        else if (newVal < end)
                        {
                            queue.Enqueue(new Item(newVal, item));
                        }
                    }
                }
            }
        }

        class Item
        {
            private Item Prev { get; set; }
            public int Value { get; private set; }

            public Item(int value, Item prev = null)
            {
                this.Prev = prev;
                this.Value = value;
            }

            public void PrintSequence()
            {
                Stack<int> stack = new Stack<int>();

                Item current = this;

                while (current != null)
                {
                    stack.Push(current.Value);
                    current = current.Prev;
                }

                Console.WriteLine(string.Join(" -> ", stack.ToArray()));
            }
        }
    }
}
