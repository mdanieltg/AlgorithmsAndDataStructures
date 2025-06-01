namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

public static class InsertionSort
{
    public static void Sort(int[] array)
    {
        for (int index = 1; index < array.Length; index++)
        {
            int elementToInsert = array[index];

            int j = index - 1;
            while (j >= 0 && elementToInsert <= array[j])
            {
                array[j + 1] = array[j--];
            }

            array[j + 1] = elementToInsert;
        }
    }
}
