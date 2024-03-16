using AlgorithmsAndDataStructures.Algorithms.Sorting;
using Xunit;

namespace AlgorithmsTests;

public class MergeTests
{
    [Fact]
    public void EqualSizeArraysMerge()
    {
        // Arrange
        int[] arrA = { 5, 12, 45, 61, 89 },
            arrB = { 9, 12, 19, 68, 72 };

        // Act
        var resultArray = MergeSort.Merge(arrA, arrB);

        // Assert
        Assert.Collection(resultArray,
            i => Assert.Equal(5, i),
            i => Assert.Equal(9, i),
            i => Assert.Equal(12, i),
            i => Assert.Equal(12, i),
            i => Assert.Equal(19, i),
            i => Assert.Equal(45, i),
            i => Assert.Equal(61, i),
            i => Assert.Equal(68, i),
            i => Assert.Equal(72, i),
            i => Assert.Equal(89, i));
    }

    [Fact]
    public void DifferentSizeArrays()
    {
        // Arrange
        int[] arrA = { 5, 9, 12, 19, 45, 61, 89 },
            arrB = { 12, 68, 72 };

        // Act
        var resultArray = MergeSort.Merge(arrA, arrB);

        // Assert
        Assert.Collection(resultArray,
            i => Assert.Equal(5, i),
            i => Assert.Equal(9, i),
            i => Assert.Equal(12, i),
            i => Assert.Equal(12, i),
            i => Assert.Equal(19, i),
            i => Assert.Equal(45, i),
            i => Assert.Equal(61, i),
            i => Assert.Equal(68, i),
            i => Assert.Equal(72, i),
            i => Assert.Equal(89, i));
    }
}
