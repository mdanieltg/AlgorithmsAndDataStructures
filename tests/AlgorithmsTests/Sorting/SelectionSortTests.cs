using AlgorithmsAndDataStructures.Algorithms.Sorting;
using Xunit;

namespace AlgorithmsTests.Sorting;

public class SelectionSortTests
{
    [Fact]
    public void UnsortedArray()
    {
        // Prepare
        int[] array = [12, 7, 1, 4, 2, -2, 9, 10, 9];

        // Act
        SelectionSort.Sort(array);

        // Assert
        Assert.Collection(array,
            i => Assert.Equal(-2, i),
            i => Assert.Equal(1, i),
            i => Assert.Equal(2, i),
            i => Assert.Equal(4, i),
            i => Assert.Equal(7, i),
            i => Assert.Equal(9, i),
            i => Assert.Equal(9, i),
            i => Assert.Equal(10, i),
            i => Assert.Equal(12, i));
    }

    [Fact]
    public void SortedArray()
    {
        // Prepare
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        // Act
        SelectionSort.Sort(array);

        // Assert
        Assert.Collection(array,
            i => Assert.Equal(1, i),
            i => Assert.Equal(2, i),
            i => Assert.Equal(3, i),
            i => Assert.Equal(4, i),
            i => Assert.Equal(5, i),
            i => Assert.Equal(6, i),
            i => Assert.Equal(7, i),
            i => Assert.Equal(8, i),
            i => Assert.Equal(9, i),
            i => Assert.Equal(10, i));
    }

    [Fact]
    public void OneElementArray()
    {
        // Prepare
        int[] array = [12];

        // Act
        SelectionSort.Sort(array);

        // Assert
        Assert.Collection(array, i => Assert.Equal(12, i));
    }

    [Fact]
    public void EmptyArray()
    {
        // Prepare
        int[] array = [];

        // Act
        SelectionSort.Sort(array);

        // Assert
        Assert.Empty(array);
    }
}
