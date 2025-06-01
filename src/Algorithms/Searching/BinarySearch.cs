namespace AlgorithmsAndDataStructures.Algorithms.Searching;

public static class BinarySearch
{
    public static bool Search(int[] array, int target) => Search(array, target, 0, array.Length - 1);

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
