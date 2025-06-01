namespace AlgorithmsAndDataStructures.Algorithms.Searching;

public static class LinearSearch
{
    public static bool Search(int[] array, int target)
    {
        int i = 0;
        while (i < array.Length)
        {
            if (array[i++] == target)
                return true;
        }

        return false;
    }
}
