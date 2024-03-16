namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

public static class MergeSort
{
    public static int[] Sort(int[] array)
    {
        if (array.Length == 1) return array;

        var middleIndex = array.Length / 2;
        var leftArray = SliceArray(array, 0, middleIndex);
        var rightArray = SliceArray(array, middleIndex, array.Length);

        return Merge(Sort(leftArray), Sort(rightArray));
    }

    private static int[] SliceArray(int[] array, int start, int end)
    {
        var result = new int[end - start];
        var i = 0;
        while (start < end)
        {
            result[i++] = array[start++];
        }

        return result;
    }

    public static int[] Merge(int[] arrayA, int[] arrayB)
    {
        var newArray = new int[arrayA.Length + arrayB.Length];
        var i = 0;
        var indexA = 0;
        var indexB = 0;

        while (indexA < arrayA.Length &&
               indexB < arrayB.Length)
        {
            if (arrayA[indexA] == arrayB[indexB])
            {
                newArray[i++] = arrayA[indexA++];
                newArray[i++] = arrayB[indexB++];
            }
            else if (arrayA[indexA] < arrayB[indexB])
            {
                newArray[i++] = arrayA[indexA++];
            }
            else
            {
                newArray[i++] = arrayB[indexB++];
            }
        }

        if (indexA == arrayA.Length)
        {
            while (indexB < arrayB.Length)
            {
                newArray[i++] = arrayB[indexB++];
            }
        }
        else
        {
            while (indexA < arrayA.Length)
            {
                newArray[i++] = arrayA[indexA++];
            }
        }

        return newArray;
    }
}
