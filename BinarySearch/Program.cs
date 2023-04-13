using System;

class BinarySearch {
    static int binarySearch(int[] arr, int target) {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target) {
                return mid;
            } else if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return -1; // target not found
    }

    static void Main() {
        int[] arr = { 2, 4, 6, 8, 10, 12, 14 };
        int target = 8;

        int index = binarySearch(arr, target);

        if (index != -1) {
            Console.WriteLine("Target found at index {0}", index);
        } else {
            Console.WriteLine("Target not found");
        }

        Console.ReadKey();
    }
}