namespace AlgorithmsAndDataStructures.Algorithms.Searching;

public static class LinearSearch
{
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
