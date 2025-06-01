namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

/// <summary>
/// Provides implementation of the merge sort algorithm.
/// </summary>
public static class MergeSort
{
    /// <summary>
    /// Sorts an array using the merge sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array. Must implement IComparable&lt;T&gt;.</typeparam>
    /// <param name="array">The array to be sorted.</param>
    /// <returns>A new sorted array containing the elements of the input array.</returns>
    /// <remarks>
    /// This implementation is stable and has O(n log n) time complexity, but requires O(n) additional space.
    /// </remarks>
    public static T[] Sort<T>(T[] array) where T : IComparable<T>
    {
        if (array.Length <= 1)
            return array;

        (T[] leftArray, T[] rightArray) = SplitArray(array);
        leftArray = Sort(leftArray);
        rightArray = Sort(rightArray);

        return Merge(leftArray, rightArray);
    }

    /// <summary>
    /// Splits an array into two approximately equal parts.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to split.</param>
    /// <returns>A tuple containing the left and right parts of the array.</returns>
    private static (T[] Left, T[] Right) SplitArray<T>(T[] array)
    {
        int middleIndex = array.Length / 2;
        var leftArray = new T[middleIndex];
        var rightArray = new T[array.Length - middleIndex];

        Array.Copy(array, 0, leftArray, 0, middleIndex);
        Array.Copy(array, middleIndex, rightArray, 0, rightArray.Length);

        return (leftArray, rightArray);
    }

    /// <summary>
    /// Merges two sorted arrays into a single sorted array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the arrays. Must implement IComparable&lt;T&gt;.</typeparam>
    /// <param name="left">The first sorted array to merge.</param>
    /// <param name="right">The second sorted array to merge.</param>
    /// <returns>A new sorted array containing all elements from both input arrays.</returns>
    /// <remarks>
    /// When duplicate elements are found in both arrays, they are both included in the result.
    /// </remarks>
    private static T[] Merge<T>(T[] left, T[] right) where T : IComparable<T>
    {
        var merged = new T[left.Length + right.Length];
        int mergedIndex = 0,
            leftIndex = 0,
            rightIndex = 0;

        while (leftIndex < left.Length &&
               rightIndex < right.Length)
        {
            switch (left[leftIndex].CompareTo(right[rightIndex]))
            {
                case < 0:
                    merged[mergedIndex++] = left[leftIndex++];
                    break;
                case > 0:
                    merged[mergedIndex++] = right[rightIndex++];
                    break;
                default:
                    merged[mergedIndex++] = left[leftIndex++];
                    merged[mergedIndex++] = right[rightIndex++];
                    break;
            }
        }

        while (rightIndex < right.Length)
            merged[mergedIndex++] = right[rightIndex++];

        while (leftIndex < left.Length)
            merged[mergedIndex++] = left[leftIndex++];

        return merged;
    }
}
