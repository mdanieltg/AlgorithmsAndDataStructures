namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

public static class InsertionSort
{
    public static void Sort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int current = array[i];

            int j = i - 1;
            while (j >= 0 && current <= array[j])
            {
                array[j + 1] = array[j--];
            }

            array[j + 1] = current;
        }
    }
}
