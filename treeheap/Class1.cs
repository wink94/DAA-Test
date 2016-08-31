using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace treeheap
{
    class Class1
    {
        private int HeapSize;

        public void Heapify(int[] arr, int i)
        {
            int left, right, largest;

            left = 2 * i + 1;
            right = 2 * i + 2;

            if (left <= HeapSize - 1 && arr[left] > arr[i])
                largest = left;
            else
                largest = i;

            if (right <= HeapSize - 1 && arr[right] > arr[largest])
                largest = right;

            if (largest != i)
            {
                Exchange(arr, largest, i);

                Heapify(arr, largest);
            }

        }

        public void Exchange(int[] arr, int index1, int index2)
        {
            int temp;

            temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        public void Build_Heap(int[] arr)
        {

            for (int i = (arr.Length) / 2; i >= 0; i--)
            {
                Heapify(arr, i);
            }
        }

        public Class1(int[] arr)
        {
            HeapSize = arr.Length;
            Build_Heap(arr);

            for (int i = HeapSize - 1; i >= 1; i--)
            {
                Exchange(arr, 0, i);
                HeapSize--;
                Heapify(arr, 0);
            }
        }

        

    }
}
