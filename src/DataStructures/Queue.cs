using System.Collections;

namespace AlgorithmsAndDataStructures.DataStructures;

public class Queue<T> : IEnumerable<T>
{
    private readonly LinkedList<T> _items = new();

    public Queue()
    {
    }

    public Queue(T firstElement)
    {
        Offer(firstElement);
    }

    public int Size => _items.Count;
    public bool IsEmpty => Size == 0;

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    public T Peek()
    {
        if (_items.First is null) throw new Exception("Queue is empty.");
        return _items.First.Value;
    }

    public T Poll()
    {
        if (_items.First is null) throw new Exception("Queue is empty.");
        var item = _items.First.Value;
        _items.RemoveFirst();
        return item;
    }

    public void Offer(T item)
    {
        _items.AddLast(item);
    }
}
