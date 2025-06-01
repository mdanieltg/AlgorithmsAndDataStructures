namespace AlgorithmsAndDataStructures.Algorithms.Searching;

/// <summary>
/// Provides binary search algorithm implementation for sorted arrays.
/// </summary>
/// <remarks>
/// Binary search is an efficient algorithm for finding an item from a sorted array.
/// It works by repeatedly dividing the search interval in half.
/// Time complexity: O(log n) where n is the number of elements in the array.
/// </remarks>
public static class BinarySearch
{
    /// <summary>
    /// Searches for a specific value in a sorted array using binary search algorithm.
    /// </summary>
    /// <param name="array">The sorted array to search in.</param>
    /// <param name="target">The value to find.</param>
    /// <returns>True if the target value is found in the array; otherwise, false.</returns>
    /// <remarks>
    /// The array must be sorted in ascending order for this algorithm to work correctly.
    /// </remarks>
    public static bool Search(int[] array, int target) => Search(array, target, 0, array.Length - 1);

    /// <summary>
    /// Recursively searches for a specific value in a sorted array using binary search algorithm.
    /// </summary>
    /// <param name="array">The sorted array to search in.</param>
    /// <param name="target">The value to find.</param>
    /// <param name="startIndex">The starting index of the search range.</param>
    /// <param name="endIndex">The ending index of the search range.</param>
    /// <returns>True if the target value is found in the array; otherwise, false.</returns>
    private static bool Search(int[] array, int target, int startIndex, int endIndex)
    {
        if (startIndex > endIndex)
            return false;

        int midIndex = startIndex + (endIndex - startIndex) / 2;

        if (array[midIndex] == target)
            return true;

        return array[midIndex] > target
            ? Search(array, target, startIndex, midIndex - 1)
            : Search(array, target, midIndex + 1, endIndex);
    }
}
