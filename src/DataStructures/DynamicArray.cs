using System.Collections;

namespace AlgorithmsAndDataStructures.DataStructures;

/// <summary>
/// Also known as List
/// </summary>
public class DynamicArray<T> : IEnumerable<T>
{
    private const int BaseCapacity = 4;
    private T[] _items;
    private int _capacity;

    public DynamicArray() : this(BaseCapacity)
    {
    }

    public DynamicArray(int capacity)
    {
        _items = new T[capacity];
        _capacity = capacity;
        Size = 0;
    }

    public int Size { get; set; }
    public bool IsEmpty => Size == 0;

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

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < Size; i++)
        {
            yield return _items[i];
        }
    }

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

    public void Clear()
    {
        for (var i = 0; i < _capacity; i++)
        {
            _items[i] = default;
        }

        Size = 0;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) != -1;
    }

    public int IndexOf(T item)
    {
        for (var i = 0; i < Size; i++)
        {
            if (item.Equals(_items[i])) return i;
        }

        return -1;
    }

    public bool Remove(T item)
    {
        for (var i = 0; i < Size; i++)
        {
            if (_items[i].Equals(item))
            {
                RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= Size) throw new IndexOutOfRangeException();

        var item = _items[index];

        for (var i = index; i < Size; i++)
        {
            _items[i] = _items[i + 1];
        }

        --Size;

        return item;
    }
}
