namespace AlgorithmsAndDataStructures.Algorithms.Search;

public class BinarySearch
{
    public static bool Search(int[] array, int target)
    {
        return Search(array, 0, array.Length - 1, target);
    }

    private static bool Search(int[] array, int start, int end, int target)
    {
        if (start > end) return false;

        var mid = (start + end) / 2;

        if (array[mid] == target) return true;

        if (array[mid] > target)
        {
            return Search(array, start, mid - 1, target);
        }

        return Search(array, mid + 1, end, target);
    }
}
