using System;

namespace LimitedMemory
{
    class TestingPlayground
    {
        static void Main()
        {
            var collection = new LimitedMemoryCollection<string, int>(4);
            collection.Set("Gosho", 5);
            collection.Set("Penio", 3);
            collection.Set("Prakash", 7);
            collection.Set("Maria", 2); // Max capacity reached

            collection.Set("Tanio", 3); // Removes Gosho to make room for Tanio
            collection.Get("Penio");
            collection.Set("Penka", 10); // Removes Prakash to make room for Penka
            foreach (var record in collection)
            {
                Console.Write("{0}({1}) ", record.Key, record.Value); // Penka(10) Penio(3) Tanio(3) Maria(2)
            }
        }
    }
}
