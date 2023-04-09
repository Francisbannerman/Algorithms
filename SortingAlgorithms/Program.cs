using System;
using System.Linq;
using System.Numerics;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
             SortingAlgos sorting = new SortingAlgos();
             int[] array = new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0, 50};
            //
            // // Console.WriteLine("bubbleSort");
            // // sorting.bubbleSort(array);
            //
            // // Console.WriteLine("selectionSort");
            // // sorting.selectionSort(array);
            //
            // // Console.WriteLine("insertionSort");
            // // sorting.insertionSort(array);
            //
            // // Console.WriteLine("merge Sort");
            // // sorting.MergeSortFunction(array, 0, array.Length - 1);
            // // foreach (int VARIABLE in array)
            // // {
            // //     Console.Write(VARIABLE + " ");
            // // }
            //
            // Console.WriteLine("quick Sort");
            // sorting.quickSort(array, 0, array.Length-1);
            // foreach (int VARIABLE in array)
            // {
            //     Console.Write(VARIABLE + " ");
            // }

            Console.WriteLine("heap Sort");
            sorting.HeapSort(array);
            foreach (int VARIABLE in array)
            {
                Console.Write(VARIABLE + " ");
            }
            
            Console.ReadKey();
        }
    }

    public class SortingAlgos
    {
        public void SortingInfos()
        {
            /// The inbuilt sorting function is discriminative to items that are not strings
            /// or of primitive data types. Thus the need for sorting algorithms.
        }

        public void bubbleSort(int[] arr) //BigO(n^2)
        {
            int length = arr.Length;

            for (int i = 0; i < length-1; i++)
            {
                for (int j = 0; j < length-1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        int temp = arr[j]; 
                        arr[j] = arr[j +  1]; 
                        arr[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted array:");
            foreach (int element in arr)
            {
                Console.Write(element + " ");
            }
        }

        public int[] selectionSort(int[] arr) //BigO(n^2)
        {
            int lenght = arr.Length;
            for (int i = 0; i < lenght; i++)
            {
                int min = i;
                int temp = arr[i];
                for (int j = i + 1; j < lenght; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                arr[i] = arr[min];
                arr[min] = temp;
            }

            foreach (var VARIABLE in arr)
            {
                Console.Write(VARIABLE + " ");
            }
            return arr;
        }

        public int[] insertionSort(int[] arr) //BigO(n^2)
        {
            int length = arr.Length;
            for (int i = 1; i < length; i++)
            {
                int curr = arr[i];
                int prev = i - 1;
                while (prev >= 0 && arr[prev] > curr)
                {
                    arr[prev + 1] = arr[prev];
                    prev = prev - 1;
                }
                arr[prev+ 1] = curr;
            }

            foreach (var VARIABLE in arr)
            {
                Console.Write(VARIABLE + ", ");
            }
            return arr;
        }

        private void Merge(int[] arr, int start, int mid, int end)
        {
            //initialize a new array to hold a copy of the portion of the arr to be sorted
            int[] temp = new int[arr.Length];
            
            //integer values to keep track of the arrays start, mid and end indices
            int i, j, k;
            
            //copies the arr values to the new temp arr and iterates over the temp arr
            for (i = start; i <= end; i++)
            {
                temp[i] = arr[i];
            }
            
            //sets values for the inter values declared to keep track of the start
            //and mid of the arr 
            i = start;
            j = mid + 1;
            k = start;
            
            //compares the elements of the new temp array and assigns the smaller
            //element to the mini array. This goes on until all the elements in 
            //either the left half or right half of the subarray has been processed.
            //This block of code compares the mini arrays created and sorts them
            //and also joins them. 
            while (i <= mid && j <= end)
            {
                if (temp[i] <= temp[j])
                {
                    arr[k] = temp[i];
                    i++;
                }
                else
                {
                    arr[k] = temp[j];
                    j++;
                }
                k++;
            }
            //processes any remaining elements in the left half of the subarray
            //that were not processed in the previous loop. This is useful in the
            //case where the array size is an odd number
            while (i <= mid)
            {
                arr[k] = temp[i];
                k++;
                i++;
            }
        }
        public void MergeSortFunction(int[] arr, int start, int end)
        {
            //checks if the starting index is less than the ending, if not the
            //subarray is already sorted. However if so, it looks for the mid and
            //divides the array, goes on till there is one 1 item in the array.
            
            //checks the size of the array index for the start and end.
            if (start < end)
            {
                //looks and defines the mid of the array
                int mid = (start + end) / 2;
                //recursively recalls function till start = end at which stage there 
                //will be only one item in the array for the divided arrays
                MergeSortFunction(arr, start, mid);
                MergeSortFunction(arr, mid + 1, end);
            //calls the merge function.
                Merge(arr, start, mid, end);
            }
        }

        public void quickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                quickSort(array, left, pivotIndex - 1);
                quickSort(array, pivotIndex + 1, right);
            }
        }
        private int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int i = start - 1;
            for (int j = start; j < end; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, end);
            return i + 1;
        }
        private void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        
        public void HeapSort(int[] arr)
        {
            int n = arr.Length;

            // Build a max heap
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);

            // Extract elements from the heap in sorted order
            for (int i = n - 1; i >= 0; i--)
            {
                // Move current root to end
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // Heapify the remaining elements
                Heapify(arr, i, 0);
            }
        }
        private void Heapify(int[] arr, int n, int i)
        {
            int largest = i;  // Initialize largest as root
            int l = 2 * i + 1;  // Left child
            int r = 2 * i + 2;  // Right child

            // If left child is larger than root
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // If right child is larger than largest so far
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // If largest is not root
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Recursively heapify the affected sub-tree
                Heapify(arr, n, largest);
            }
        }
    }
}