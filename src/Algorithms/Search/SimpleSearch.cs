namespace AlgorithmsAndDataStructures.Algorithms.Search;

public class SimpleSearch
{
    public static bool Search(int[] array, int target)
    {
        var i = 0;
        while (i < array.Length)
        {
            if (array[i++] == target) return true;
        }

        return false;
    }
}
