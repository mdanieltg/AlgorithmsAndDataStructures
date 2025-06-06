using System.Collections;

namespace AlgorithmsAndDataStructures.DataStructures;

/// <summary>
/// Represents a dynamic array implementation that automatically resizes as elements are added.
/// </summary>
/// <typeparam name="T">The type of elements in the array.</typeparam>
public class DynamicArray<T> : IEnumerable<T>
{
    private const int BaseCapacity = 4;

    /// <summary>
    /// Size of the array.
    /// </summary>
    private int _capacity;

    private T[] _items;

    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicArray{T}"/> class with default capacity.
    /// </summary>
    public DynamicArray() : this(BaseCapacity)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicArray{T}"/> class with the specified capacity.
    /// </summary>
    /// <param name="capacity">The initial capacity of the array.</param>
    public DynamicArray(int capacity)
    {
        _items = new T[capacity];
        _capacity = capacity;
        Size = 0;
    }

    /// <summary>
    /// Gets the total number of elements in the array.
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the array is empty.
    /// </summary>
    public bool IsEmpty => Size == 0;

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get or set.</param>
    /// <returns>The element at the specified index.</returns>
    /// <exception cref="System.IndexOutOfRangeException">Thrown when the index is out of range.</exception>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Size) throw new IndexOutOfRangeException();
            return _items[index];
        }
        set
        {
            if (index < 0 || index >= Size) throw new IndexOutOfRangeException();
            _items[index] = value;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An IEnumerator that can be used to iterate through the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An IEnumerator&lt;T&gt; that can be used to iterate through the collection.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < Size; i++)
        {
            yield return _items[i];
        }
    }

    /// <summary>
    /// Adds an item to the end of the array, resizing the array if necessary.
    /// </summary>
    /// <param name="item">The item to add to the array.</param>
    public void Add(T item)
    {
        if (Size + 1 >= _capacity)
        {
            _capacity += BaseCapacity;
            var newArray = new T[_capacity];
            _items.CopyTo(newArray, 0);
            _items = newArray;
        }

        _items[Size++] = item;
    }

    /// <summary>
    /// Removes all items from the array.
    /// </summary>
    public void Clear()
    {
        for (var i = 0; i < _capacity; i++)
        {
            _items[i] = default!;
        }

        Size = 0;
    }

    /// <summary>
    /// Determines whether the array contains a specific item.
    /// </summary>
    /// <param name="item">The object to locate in the array.</param>
    /// <returns>true if <paramref name="item"/> is found in the array; otherwise, false.</returns>
    public bool Contains(T item)
    {
        return IndexOf(item) != -1;
    }

    /// <summary>
    /// Returns the index of the first occurrence of a specific item in the array.
    /// </summary>
    /// <param name="item">The object to locate in the array.</param>
    /// <returns>The index of the first occurrence of <paramref name="item"/> if found; otherwise, -1.</returns>
    public int IndexOf(T item)
    {
        for (var i = 0; i < Size; i++)
        {
            if (item!.Equals(_items[i])) return i;
        }

        return -1;
    }

    /// <summary>
    /// Removes the first occurrence of a specific item from the array.
    /// </summary>
    /// <param name="item">The object to remove from the array.</param>
    /// <returns>true if <paramref name="item"/> was successfully removed; otherwise, false.</returns>
    public bool Remove(T item)
    {
        for (var i = 0; i < Size; i++)
        {
            if (!_items[i]!.Equals(item)) continue;
            RemoveAt(i);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Removes the element at the specified index of the array.
    /// </summary>
    /// <param name="index">The zero-based index of the element to remove.</param>
    /// <returns>The element that was removed from the array.</returns>
    /// <exception cref="System.IndexOutOfRangeException">Thrown when the index is out of range.</exception>
    public T RemoveAt(int index)
    {
        if (index < 0 || index >= Size) throw new IndexOutOfRangeException();

        T item = _items[index];

        for (int i = index; i < Size; i++)
        {
            _items[i] = _items[i + 1];
        }

        --Size;

        return item;
    }
}
