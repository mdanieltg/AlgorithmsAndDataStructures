namespace AlgorithmsAndDataStructures.Algorithms.Searching;

public static class BinarySearch
{
    public static bool Search(int[] array, int target) => Search(array, target, 0, array.Length - 1);

    private static bool Search(int[] array, int target, int startIndex, int endIndex)
    {
        int length = endIndex - startIndex + 1;
        if (length == 1) return array[startIndex] == target;

        int middle = startIndex + length / 2;

        if (array[middle] == target) return true;

        return array[middle] > target
            ? Search(array, target, startIndex, middle - 1)
            : Search(array, target, middle + 1, endIndex);
    }
}
