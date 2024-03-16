using AlgorithmsAndDataStructures.DataStructures;
using Xunit;

namespace DataStructures.Tests;

public class LinkedListTests
{
    [Fact]
    public void Test()
    {
        var myLinkedList = new DoublyLinkedList<int>();
        myLinkedList.Add(12);
        myLinkedList.Add(1);
        myLinkedList.Add(8);
        myLinkedList.AddLast(0);
        myLinkedList.AddFirst(20);

        Assert.Equal(5, myLinkedList.Size);
        Assert.Collection(myLinkedList,
            i => Assert.Equal(20, i),
            i => Assert.Equal(12, i),
            i => Assert.Equal(1, i),
            i => Assert.Equal(8, i),
            i => Assert.Equal(0, i)
        );

        var index = myLinkedList.IndexOf(12);
        Assert.Equal(1, index);

        var wasRemoved = myLinkedList.Remove(12);
        Assert.True(wasRemoved);

        wasRemoved = myLinkedList.Remove(-1);
        Assert.False(wasRemoved);

        var removedItem = myLinkedList.RemoveLast();
        Assert.Equal(0, removedItem);

        removedItem = myLinkedList.RemoveFirst();
        Assert.Equal(20, removedItem);

        var contains = myLinkedList.Contains(3);
        Assert.False(contains);

        contains = myLinkedList.Contains(1);
        Assert.True(contains);

        var item = myLinkedList.RemoveAt(1);
        Assert.Equal(8, item);

        Assert.False(myLinkedList.IsEmpty);

        item = myLinkedList.PeekFirst();
        Assert.Equal(1, item);

        item = myLinkedList.PeekLast();
        Assert.Equal(1, item);

        myLinkedList.Clear();

        Assert.True(myLinkedList.IsEmpty);
    }
}
