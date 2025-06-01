namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

public static class SelectionSort
{
    public static void Sort(int[] array)
    {
        int length = array.Length;

        // Move one at a time the boundary of the unsorted subarray
        for (int currentIndex = 0; currentIndex < length - 1; ++currentIndex)
        {
            // Smallest element so far
            int minIndex = currentIndex;

            for (int searchIndex = currentIndex + 1; searchIndex < length; ++searchIndex)
            {
                if (array[searchIndex] < array[minIndex])
                    // Assign the index of the smallest element
                    minIndex = searchIndex;
            }

            // Swap the minimum element with the current element
            (array[minIndex], array[currentIndex]) = (array[currentIndex], array[minIndex]);
        }
    }
}
