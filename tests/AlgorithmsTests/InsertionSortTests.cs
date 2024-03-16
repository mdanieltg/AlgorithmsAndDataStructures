using AlgorithmsAndDataStructures.Algorithms.Sorting;
using Xunit;

namespace AlgorithmsTests;

public class InsertionSortTests
{
    [Fact]
    public void SortTest()
    {
        // Assert
        int[] array = { 12, 7, 1, 4, 2, -2, 9, 10, 9 };

        // Act
        InsertionSort.Sort(array);

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
}
