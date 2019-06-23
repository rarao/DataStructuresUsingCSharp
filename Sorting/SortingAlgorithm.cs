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

        public static void MergeSort(int[] arr, int start, int end)
        {
            if (start >= end)
                return;

            int mid = (start + end) / 2;

            MergeSort(arr, start, mid);
            MergeSort(arr, mid + 1, end);

            Merge(arr, start, end);
        }

        private static void Merge(int[] arr, int start1, int end2)
        {
            int end1 = (start1 + end2) / 2;
            int start2 = end1 + 1;

            int[] temp = new int[end2 - start1 + 1];

            int first = start1;
            int second = start2;
            int index = 0;

            while (first <= end1 && second <= end2)
            {
                temp[index++] = (arr[first] <= arr[second]) ? arr[first++] : arr[second++];
            }

            while (first <= end1)
                temp[index++] = arr[first++];

            while (second <= end2)
                temp[index++] = arr[second++];

            for (int i = 0; i < index; i++)
                arr[start1++] = temp[i];
        }

        //Generalized form of insertion sort. Here the idea is to bring the smaller element present far away in the list
        // in the beginning of the list . This is done by chosing a gap using a recurrence relation (n=3n+1, known as knuth sequence)
        // and then decreasing the gap eventually. Insertion sort is applied on the elements with the gap assuming the other elements doesnot exist.
        public static void ShellSort(int[] arr)
        {
            int n = arr.Length;

            int gap = 1;

            while (gap < n / 3)
            {
                gap = 3 * gap + 1;
            }

            while (gap >= 1)
            {
                for (int i = 0; i < (n - gap); i += gap)
                {
                    int j = i;
                    int temp = arr[i + gap];
                    for (; j >= 0 && arr[j] > temp; j = j - gap)
                    {
                        arr[j + gap] = arr[j];
                    }
                    arr[j + gap] = temp;
                }
                gap /= 3;
            }
        }

        public static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = Partition(arr, start, end);

            QuickSort(arr, start, pivot - 1);
            QuickSort(arr, pivot + 1, end);
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int pivot = start;

            int i = start + 1;
            int j = end;

            while (i <= j)
            {
                while ((i <= j) && arr[i] <= arr[pivot])
                    i++;
                while ((i <= j) && arr[j] > arr[pivot])
                    j--;
                if (i < j)
                    Swap(ref arr[i], ref arr[j]);
            }

            Swap(ref arr[pivot], ref arr[j]);

            return j;
        }

        public static void HeapSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                CreateHeap(arr, i + 1);
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int temp = arr[0];
                arr[0] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = temp;

                Heapify(arr, 0, arr.Length - i - 1);
            }
        }
        private static void CreateHeap(int[] HeapArray, int count)
        {
            for (int i = count - 1; i >= 1; i = (i - 1) / 2)
            {
                if (HeapArray[i] > HeapArray[(i - 1) / 2])
                {
                    int temp = HeapArray[i];
                    HeapArray[i] = HeapArray[(i - 1) / 2];
                    HeapArray[(i - 1) / 2] = temp;
                }
                else
                    break;
            }
        }
        private static void Heapify(int[] HeapArray, int rootIndex, int count)
        {
            int i = rootIndex;
            while (i <= (count - 2) / 2)
            {
                int childIndex = (HeapArray[2 * i + 1] > HeapArray[2 * i + 2]) ? 2 * i + 1 : 2 * i + 2;
                if (childIndex >= count)
                    childIndex = count - 1;

                if (HeapArray[i] < HeapArray[childIndex])
                {
                    int temp = HeapArray[i];
                    HeapArray[i] = HeapArray[childIndex];
                    HeapArray[childIndex] = temp;
                    i = childIndex;
                }
                else
                    break;
            }
        }
    }
}
