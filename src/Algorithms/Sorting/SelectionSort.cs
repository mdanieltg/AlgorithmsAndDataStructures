namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

public static class SelectionSort
{
    public static void Sort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; ++i) // One by one move boundary of unsorted subarray  
        {
            int small = i; //minimum element in unsorted array  

            for (int j = i + 1; j < arr.Length; ++j)
            {
                if (arr[j] < arr[small])
                    small = j;
            }

            // Swap the minimum element with the first element  
            int temp = arr[small];
            arr[small] = arr[i];
            arr[i] = temp;
        }
    }
}
