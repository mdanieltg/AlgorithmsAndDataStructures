using System.Collections;

namespace AlgorithmsAndDataStructures.DataStructures;

public class Stack<T> : IEnumerable<T>
{
    private readonly LinkedList<T> _list = new();

    public Stack()
    {
    }

    public Stack(T firstElement)
    {
        Push(firstElement);
    }

    public int Size => _list.Count;
    public bool IsEmpty => Size == 0;

    public void Push(T item)
    {
        _list.AddLast(item);
    }

    public T Pop()
    {
        if (_list.Last is null) throw new Exception("The list is empty.");

        var data = _list.Last.Value;
        _list.RemoveLast();

        return data;
    }

    public T Peek()
    {
        if (_list.Last is null) throw new Exception("The list is empty.");
        return _list.Last.Value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }
}
