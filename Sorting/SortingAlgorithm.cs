using System;

namespace Sorting
{
    public class SortingAlgorithm
    {
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static void BubbleSort(int[] arr)
        {
            int length = arr.Length;
            bool swap = true;
            for (int i = 0; i < length - 1 && swap; i++)
            {
                swap = false;
                for (int j = 0; j < length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap = true;
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }

        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int smallest = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[smallest])
                        smallest = j;
                }
                if (i != smallest)
                    Swap(ref arr[i], ref arr[smallest]);
            }
        }

        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                for (; j >= 0 && arr[j] > temp; j--)
                {
                    arr[j + 1] = arr[j];
                }
                arr[j + 1] = temp;
            }
        }
    }
}
