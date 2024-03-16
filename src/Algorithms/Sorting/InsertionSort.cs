namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

public class InsertionSort
{
    public static void Sort(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var current = array[i];

            var j = i - 1;
            while (j >= 0 && current <= array[j])
            {
                array[j + 1] = array[j--];
            }

            array[j + 1] = current;
        }
    }
}
