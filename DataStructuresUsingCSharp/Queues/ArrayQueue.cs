using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.Queues
{
    // This implementation uses an array in a circular fashion to avoid wastage of spaces as front index grows on dequeue.
    // This is how queues should be implemented using dynamic arrays
    public class CircularArrayQueue<T>
    {
        private T[] arr;
        private int capacity;
        private int front;
        private int rear;
        public CircularArrayQueue(int cap = 2)
        {
            arr = new T[cap];
            this.capacity = cap;
            front = rear = -1;
        }

        private bool IsQueueFull()
        {
            return (rear + 1) % capacity == front;
        }

        public bool IsQueueEmpty()
        {
            return (front == -1 && rear == -1);
        }

        private void Resize()
        {
            int originalSize = this.capacity;
            this.capacity = this.capacity * 2;

            T[] newArr = new T[this.capacity];

            if (front <= rear)
            {
                for (int i = front; i <= rear; i++)
                    newArr[i] = arr[i];
            }
            else
            {
                for (int i = front; i < originalSize; i++)
                    newArr[i] = arr[i];
                for (int i = 0; i <= rear; i++)
                    newArr[i + originalSize] = arr[i];
                this.rear = rear + originalSize;
            }
            this.arr = newArr;
        }

        public void Enqueue(T data)
        {
            if (IsQueueFull())
                Resize();

            if (IsQueueEmpty())
                front = 0;
            rear = (rear + 1) % capacity;

            arr[rear] = data;
        }
        public T Dequeue()
        {
            if (IsQueueEmpty())
                throw new Exception("Empty queue error .");
            else
            {
                T ele = arr[front];

                if (front == rear)
                    front = rear = -1;
                else
                    front = (front + 1) % capacity;

                return ele;
            }
        }

        public void ReadAll()
        {
            if (front <= rear)
            {
                for (int i = front; i <= rear; i++)
                {
                    Console.WriteLine(arr[i].ToString());
                }
            }
            else
            {
                for (int i = front; i < capacity; i++)
                {
                    Console.WriteLine(arr[i].ToString());
                }
                for (int i = 0; i <= rear; i++)
                {
                    Console.WriteLine(arr[i].ToString());
                }
            }
        }
    }
    public class ArrayQueue<T>
    {
        private List<T> list;

        public ArrayQueue()
        {
            list = new List<T>();
        }

        public int LENGTH
        {
            get { return list.Count; }
        }

        public void Enqueue(T data)
        {
            list.Add(data);
        }

        public T Dequeue()
        {
            if (list.Count == 0)
            {
                throw new Exception("Queue is empty");
            }
            else
            {
                T ele = list[0];
                list.RemoveAt(0);
                return ele;
            }
        }

        public void ReadAll()
        {
            foreach (T v in list)
            {
                Console.WriteLine(v.ToString());
            }
        }
    }
}
