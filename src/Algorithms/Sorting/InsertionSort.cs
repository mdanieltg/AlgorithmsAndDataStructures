namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

/// <summary>
/// Provides implementation of the insertion sort algorithm.
/// </summary>
/// <remarks>
/// Insertion sort builds the final sorted array one item at a time. It is much less efficient
/// on large lists than more advanced algorithms such as quicksort, heapsort, or merge sort,
/// but it has advantages for small data sets and is efficient for nearly sorted arrays.
/// Time Complexity: O(n²) in the worst case, O(n) in the best case (when the array is already sorted).
/// Space Complexity: O(1) as it sorts in-place.
/// </remarks>
public static class InsertionSort
{
    /// <summary>
    /// Sorts an array of integers using the insertion sort algorithm.
    /// </summary>
    /// <param name="array">The array to be sorted.</param>
    /// <remarks>
    /// This method sorts the array in ascending order and modifies the input array directly.
    /// </remarks>
    public static void Sort(int[] array)
    {
        for (int index = 1; index < array.Length; index++)
        {
            int elementToInsert = array[index];

            int j = index - 1;
            while (j >= 0 && elementToInsert <= array[j])
            {
                array[j + 1] = array[j--];
            }

            array[j + 1] = elementToInsert;
        }
    }
}
