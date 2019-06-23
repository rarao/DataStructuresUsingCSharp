using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.HeapAndPriorityQueue
{
    public class BinaryHeap
    {
        private List<int> HeapArray;
        private bool isMinHeap;

        public int HeapCount { get { return HeapArray.Count; } }

        public BinaryHeap()
        {
            HeapArray = new List<int>();
            isMinHeap = false;
        }
        public BinaryHeap(int root, bool minHeap=false)
        {
            HeapArray = new List<int>();
            HeapArray.Add(root);
            isMinHeap = minHeap;
        }

        public void Insert(int val)
        {
            HeapArray.Add(val);

            for (int i = HeapCount - 1; i >= 1; i = (i - 1) / 2)
            {
                if ((HeapArray[i] > HeapArray[(i - 1) / 2] && !isMinHeap) || (HeapArray[i] > HeapArray[(i - 1) / 2] && isMinHeap))
                {
                    int temp = HeapArray[i];
                    HeapArray[i] = HeapArray[(i - 1) / 2];
                    HeapArray[(i - 1) / 2] = temp;
                }
                else
                    break;
            }
        }

        public int GetMaxMin()
        {
            if (HeapArray.Count > 0)
            {
                return HeapArray[0];
            }
            throw new Exception("Heap is empty.");
        }

        public int Remove()
        {
            if (HeapArray.Count > 0)
            {
                int result = HeapArray[0];

                HeapArray[0] = HeapArray[HeapCount - 1];
                HeapArray.RemoveAt(HeapCount - 1);

                Heapify(0,HeapCount);

                return result;
            }
            throw new Exception("Heap is empty.");
        }

        public void PrintAll()
        {
            for (int i = 0; i < HeapArray.Count; i++)
            {
                Console.WriteLine(HeapArray[i]);
            }
        }

        private void Heapify(int rootIndex,int count)
        {
            int i = rootIndex;
            while (i <= (count - 2) / 2)
            {
                int childIndex = ((!isMinHeap && HeapArray[2 * i + 1] > HeapArray[2 * i + 2]) || (isMinHeap && HeapArray[2 * i + 1] < HeapArray[2 * i + 2])) ? 2 * i + 1 : 2 * i + 2;
                if (childIndex >= count)
                    childIndex = count - 1;

                if ((!isMinHeap && HeapArray[i] < HeapArray[childIndex]) || (isMinHeap && HeapArray[i] > HeapArray[childIndex]))
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
