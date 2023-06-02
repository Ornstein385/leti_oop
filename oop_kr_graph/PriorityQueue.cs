using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> heap;

    public int Count
    {
        get
        {
            return heap.Count;
        }
    }

    public PriorityQueue()
    {
        heap = new List<T>();
    }

    public void Enqueue(T item)
    {
        heap.Add(item);
        int currentIndex = heap.Count - 1;
        while (currentIndex > 0 && heap[currentIndex].CompareTo(heap[(currentIndex - 1) / 2]) < 0)
        {
            int parentIndex = (currentIndex - 1) / 2;
            T tmp = heap[currentIndex];
            heap[currentIndex] = heap[parentIndex];
            heap[parentIndex] = tmp;
            currentIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Priority queue is empty");
        }
        T result = heap[0];
        int lastIndex = heap.Count - 1;
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);
        if (heap.Count > 0)
        {
            int currentIndex = 0;
            while (true)
            {
                int leftChildIndex = currentIndex * 2 + 1;
                int rightChildIndex = currentIndex * 2 + 2;
                if (leftChildIndex >= heap.Count)
                {
                    break;
                }
                int smallerChildIndex = leftChildIndex;
                if (rightChildIndex < heap.Count && heap[rightChildIndex].CompareTo(heap[leftChildIndex]) < 0)
                {
                    smallerChildIndex = rightChildIndex;
                }
                if (heap[currentIndex].CompareTo(heap[smallerChildIndex]) > 0)
                {
                    T tmp = heap[currentIndex];
                    heap[currentIndex] = heap[smallerChildIndex];
                    heap[smallerChildIndex] = tmp;
                    currentIndex = smallerChildIndex;
                }
                else
                {
                    break;
                }
            }
        }
        return result;
    }

    public T Peek()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Priority queue is empty");
        }
        return heap[0];
    }
}
