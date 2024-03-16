using AlgorithmsAndDataStructures.Algorithms.Sorting;
using Xunit;

namespace AlgorithmsTests;

public class MergeSortTests
{
    [Fact]
    public void SortTest()
    {
        // Arrange
        int[] unsortedArray = { 85, 6, 11, 59, 36, 63, 30, 20, 47, 74, 58, 38 };

        // Act
        var sortedArray = MergeSort.Sort(unsortedArray);

        // Assert
        Assert.Collection(sortedArray,
            i => Assert.Equal(6, i),
            i => Assert.Equal(11, i),
            i => Assert.Equal(20, i),
            i => Assert.Equal(30, i),
            i => Assert.Equal(36, i),
            i => Assert.Equal(38, i),
            i => Assert.Equal(47, i),
            i => Assert.Equal(58, i),
            i => Assert.Equal(59, i),
            i => Assert.Equal(63, i),
            i => Assert.Equal(74, i),
            i => Assert.Equal(85, i));
    }
}
