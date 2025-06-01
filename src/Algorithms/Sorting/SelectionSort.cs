namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

/// <summary>
/// Provides implementation of the selection sort algorithm.
/// </summary>
/// <remarks>
/// Selection sort works by repeatedly finding the minimum element from the unsorted portion
/// of the array and placing it at the beginning of the unsorted portion.
/// Time Complexity: O(n²) where n is the number of elements in the array.
/// Space Complexity: O(1) as it sorts in-place.
/// </remarks>
public static class SelectionSort
{
    /// <summary>
    /// Sorts an array of integers using the selection sort algorithm.
    /// </summary>
    /// <param name="array">The array to be sorted.</param>
    /// <remarks>
    /// This method sorts the array in ascending order and modifies the input array directly.
    /// </remarks>
    public static void Sort(int[] array)
    {
        int length = array.Length;

        // Move one at a time the boundary of the unsorted subarray
        for (int currentIndex = 0; currentIndex < length - 1; ++currentIndex)
        {
            // Smallest element so far
            int minIndex = currentIndex;

            for (int searchIndex = currentIndex + 1; searchIndex < length; ++searchIndex)
            {
                if (array[searchIndex] < array[minIndex])
                    // Assign the index of the smallest element
                    minIndex = searchIndex;
            }

            // Swap the minimum element with the current element
            (array[minIndex], array[currentIndex]) = (array[currentIndex], array[minIndex]);
        }
    }
}
