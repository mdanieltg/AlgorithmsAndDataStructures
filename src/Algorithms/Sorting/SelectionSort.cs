namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

public class SelectionSort
{
    public static void Sort(int[] arr, int n)
    {
        for (var i = 0; i < n - 1; i++) // One by one move boundary of unsorted subarray  
        {
            var small = i; //minimum element in unsorted array  

            for (var j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[small])
                    small = j;
            }

            // Swap the minimum element with the first element  
            var temp = arr[small];
            arr[small] = arr[i];
            arr[i] = temp;
        }
    }
}
