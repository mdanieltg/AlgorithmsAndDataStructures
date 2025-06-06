using System.Collections;

namespace AlgorithmsAndDataStructures.DataStructures;

/// <summary>
/// Represents a simple Last-In-First-Out (LIFO) collection of elements.
/// </summary>
/// <typeparam name="T">The type of elements in the stack.</typeparam>
public class Stack<T> : IEnumerable<T>
{
    /// <summary>
    /// Internal linked list used to store stack elements.
    /// </summary>
    private readonly LinkedList<T> _list = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="Stack{T}"/> class that is empty.
    /// </summary>
    public Stack()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Stack{T}"/> class with one element.
    /// </summary>
    /// <param name="firstElement">The element to add to the stack.</param>
    public Stack(T firstElement)
    {
        Push(firstElement);
    }

    /// <summary>
    /// Gets the number of elements contained in the stack.
    /// </summary>
    public int Size => _list.Count;

    /// <summary>
    /// Gets a value indicating whether the stack is empty.
    /// </summary>
    public bool IsEmpty => Size == 0;

    /// <summary>
    /// Returns an enumerator that iterates through the stack.
    /// </summary>
    /// <returns>An IEnumerator object that can be used to iterate through the stack.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the stack.
    /// </summary>
    /// <returns>An IEnumerator&lt;T&gt; object that can be used to iterate through the stack.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    /// <summary>
    /// Inserts an item at the top of the stack.
    /// </summary>
    /// <param name="item">The item to push onto the stack.</param>
    public void Push(T item)
    {
        _list.AddLast(item);
    }

    /// <summary>
    /// Removes and returns the item at the top of the stack.
    /// </summary>
    /// <returns>The item removed from the top of the stack.</returns>
    /// <exception cref="System.Exception">Thrown when the stack is empty.</exception>
    public T Pop()
    {
        if (_list.Last is null) throw new Exception("The list is empty.");

        T data = _list.Last.Value;
        _list.RemoveLast();

        return data;
    }

    /// <summary>
    /// Returns the item at the top of the stack without removing it.
    /// </summary>
    /// <returns>The item at the top of the stack.</returns>
    /// <exception cref="System.Exception">Thrown when the stack is empty.</exception>
    public T Peek()
    {
        if (_list.Last is null) throw new Exception("The list is empty.");
        return _list.Last.Value;
    }
}
