namespace AlgorithmsAndDataStructures.Algorithms.Searching;

/// <summary>
/// Provides linear search algorithm implementation for arrays.
/// </summary>
/// <remarks>
/// Linear search is a simple search algorithm that finds the position of a target value within an array.
/// It sequentially checks each element of the array until a match is found or the whole array has been searched.
/// Time complexity: O(n) where n is the number of elements in the array.
/// </remarks>
public static class LinearSearch
{
    /// <summary>
    /// Searches for a specific value in an array using linear search algorithm.
    /// </summary>
    /// <param name="array">The array to search in.</param>
    /// <param name="target">The value to find.</param>
    /// <returns>True if the target value is found in the array; otherwise, false.</returns>
    public static bool Search(int[] array, int target)
    {
        int index = 0;
        while (index < array.Length)
        {
            if (array[index++] == target)
                return true;
        }

        return false;
    }
}
