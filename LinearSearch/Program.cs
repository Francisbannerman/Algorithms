using System;

class LinearSearch {
    static int linearSearch(int[] arr, int target) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == target) {
                return i;
            }
        }

        return -1; // target not found
    }

    static void Main() {
        int[] arr = { 2, 4, 6, 8, 10, 12, 14 };
        int target = 8;

        int index = linearSearch(arr, target);

        if (index != -1) {
            Console.WriteLine("Target found at index {0}", index);
        } else {
            Console.WriteLine("Target not found");
        }

        Console.ReadKey();
    }
}