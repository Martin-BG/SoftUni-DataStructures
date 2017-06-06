using System;

public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        int n = arr.Length;

        for (int i = n / 2; i >= 0; i--)
        {
            HeapifyDown(arr, i, n);
        }

        for (int i = n - 1; i > 0; i--)
        {
            Swap(arr, 0, i);
            HeapifyDown(arr, 0, i);
        }
    }

    private static void HeapifyDown(T[] arr, int index, int border)
    {
        
        while (index < border / 2)
        {
            int child = 2 * index + 1;

            if (child + 1 < border && IsLess(arr, child, child + 1))
            {
                child++;
            }

            if (IsLess(arr, child, index))
            {
                break;
            }

            Swap(arr, index, child);
            index = child;
        }
    }

    private static bool IsLess(T[] arr, int a, int b)
    {
        return (arr[a].CompareTo(arr[b]) < 0);
    }

    private static void Swap(T[] arr, int a, int b)
    {
        T temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
}
