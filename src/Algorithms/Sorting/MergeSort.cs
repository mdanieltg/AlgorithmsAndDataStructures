namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

public static class MergeSort
{
    public static T[] Sort<T>(T[] array) where T : IComparable<T>
    {
        if (array.Length <= 1)
            return array;

        (T[] leftArray, T[] rightArray) = SplitArray(array);
        leftArray = Sort(leftArray);
        rightArray = Sort(rightArray);

        return Merge(leftArray, rightArray);
    }

    private static (T[] Left, T[] Right) SplitArray<T>(T[] array)
    {
        int middleIndex = array.Length / 2;
        var leftArray = new T[middleIndex];
        var rightArray = new T[array.Length - middleIndex];

        Array.Copy(array, 0, leftArray, 0, middleIndex);
        Array.Copy(array, middleIndex, rightArray, 0, rightArray.Length);

        return (leftArray, rightArray);
    }

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
