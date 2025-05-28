namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

public static class MergeSort
{
    public static int[] Sort(int[] array)
    {
        if (array.Length == 1) return array;

        int middle = array.Length / 2;

        var leftArray = new int[middle];
        var rightArray = new int[array.Length - middle];

        Array.Copy(array, 0, leftArray, 0, middle);
        Array.Copy(array, middle, rightArray, 0, rightArray.Length);

        leftArray = Sort(leftArray);
        rightArray = Sort(rightArray);

        return Merge(leftArray, rightArray);
    }

    public static int[] Merge(int[] arrayA, int[] arrayB)
    {
        var mergedArray = new int[arrayA.Length + arrayB.Length];
        int index = 0,
            indexA = 0,
            indexB = 0;

        while (indexA < arrayA.Length &&
               indexB < arrayB.Length)
        {
            if (arrayA[indexA] == arrayB[indexB])
            {
                mergedArray[index++] = arrayA[indexA++];
                mergedArray[index++] = arrayB[indexB++];
            }
            else if (arrayA[indexA] < arrayB[indexB])
            {
                mergedArray[index++] = arrayA[indexA++];
            }
            else
            {
                mergedArray[index++] = arrayB[indexB++];
            }
        }

        while (indexB < arrayB.Length)
        {
            mergedArray[index++] = arrayB[indexB++];
        }

        while (indexA < arrayA.Length)
        {
            mergedArray[index++] = arrayA[indexA++];
        }

        return mergedArray;
    }
}
