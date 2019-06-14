﻿using System;

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

            while(first<=end1 && second <=end2)
            {
                temp[index++] = (arr[first] <= arr[second]) ?  arr[first++] : arr[second++];
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

            while(gap<n/3)
            {
                gap = 3 * gap + 1;
            }

            while (gap >= 1)
            {
                for (int i = 0; i < (n-1) / gap; i += gap)
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
    }
}
