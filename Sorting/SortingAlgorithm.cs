using System;

namespace Sorting
{
    public class SortingAlgorithm
    {
        public static void Swap(ref int a,ref int b)
        {
            int temp = a;
            a=b;
            b=temp;
        }
        public static void BubbleSort(int []arr)
        {
            int length = arr.Length;
            bool swap = true;
            for(int i=0;i<length-1 && swap;i++)
            {
                swap = false;
                for(int j=0;j<length-1;j++)
                {
                    if(arr[j]>arr[j+1])
                    {
                        swap = true;
                        Swap(ref arr[j],ref arr[j+1]);
                    }
                }
            }
        }
    }
}
