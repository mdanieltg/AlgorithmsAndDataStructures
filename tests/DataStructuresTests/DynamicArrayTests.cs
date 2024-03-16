using AlgorithmsAndDataStructures.DataStructures;
using System;
using Xunit;

namespace DataStructures.Tests;

public class DynamicArrayTests
{
    [Fact]
    public void AccessingListItem_ShouldThrowException_WhenListIsEmpty()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        var action = () =>
        {
            var item = dynamicArray[0];
        };

        // Assert
        Assert.Throws<IndexOutOfRangeException>(action);
    }

    [Fact]
    public void ListCount_ShouldBeZero_WhenListIsEmpty()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        var count = dynamicArray.Size;

        // Assert
        Assert.Equal(0, count);
    }

    [Fact]
    public void AddingItemToList_ShouldIncrementListItemCount()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        dynamicArray.Add(12);
        var count = dynamicArray.Size;

        // Assert
        Assert.Equal(1, count);
    }

    [Fact]
    public void AccessingListItem_ShouldReturnItem()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        dynamicArray.Add(12);
        var number = dynamicArray[0];

        // Assert
        Assert.Equal(12, number);
    }

    [Fact]
    public void AddingItemToList_ShouldMakeTheListGrow()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        dynamicArray.Add(1);
        dynamicArray.Add(2);
        dynamicArray.Add(3);
        dynamicArray.Add(4);
        dynamicArray.Add(5);
        dynamicArray.Add(6);
        dynamicArray.Add(7);
        dynamicArray.Add(8);
        dynamicArray.Add(9);
        dynamicArray.Add(10);
        dynamicArray.Add(11);
        dynamicArray.Add(12);
        var count = dynamicArray.Size;

        // Assert
        Assert.Equal(12, count);
    }
}
