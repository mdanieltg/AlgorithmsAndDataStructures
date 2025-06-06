using System.Collections;

namespace AlgorithmsAndDataStructures.DataStructures;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public int Size { get; private set; }
    public bool IsEmpty => Size == 0;

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? traverse = _head;
        while (traverse is not null)
        {
            yield return traverse.Data;
            traverse = traverse.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        AddLast(item);
    }

    public void AddFirst(T item)
    {
        if (_head is null)
        {
            _tail = new Node<T>(item, null, null);
            _head = _tail;
        }
        else
        {
            _head.Previous = new Node<T>(item, null, _head);
            _head = _head.Previous;
        }

        ++Size;
    }

    public void AddLast(T item)
    {
        if (_tail is null)
        {
            AddFirst(item);
            return;
        }

        _tail.Next = new Node<T>(item, _tail, null);
        _tail = _tail.Next;

        ++Size;
    }

    public void Clear()
    {
        Node<T>? traverse = _head;
        while (traverse is not null)
        {
            Node<T>? next = traverse.Next;
            traverse.Previous = null;
            traverse.Next = null;
            traverse.Data = default!;
            traverse = next;
        }

        _head = null;
        _tail = null;
        Size = 0;
    }

    public T PeekFirst()
    {
        if (IsEmpty) throw new Exception("The list is empty.");
        return _head!.Data;
    }

    public T PeekLast()
    {
        if (IsEmpty) throw new Exception("The list is empty.");
        return _tail!.Data;
    }

    public T RemoveFirst()
    {
        if (_head is null) throw new Exception("The list is empty.");

        // Extract the data at the head and move
        // the head pointer forward one node
        T data = _head.Data;
        _head = _head.Next;
        --Size;

        // If the list is empty, set the tail to null as well
        if (IsEmpty)
            _tail = null;

        // Do a memory clean of the previous node
        else
            _head!.Previous = null;

        return data;
    }

    public T RemoveLast()
    {
        if (_tail is null) throw new Exception("The list is empty.");

        // Extract the data at the tail and move
        // the tail pointer backwards one node
        T data = _tail.Data;
        _tail = _tail.Previous;
        --Size;

        // If the list is empty, set the tail to null as well
        if (IsEmpty)
        {
            _head = null;
        }

        // Do a memory clean of the previous node
        else
        {
            _tail!.Next = null;
        }

        return data;
    }

    private T Remove(Node<T> node)
    {
        // if the node to remove is somewhere either at the
        // head or the tail, handle those independently
        if (node.Previous is null) return RemoveFirst();
        if (node.Next is null) return RemoveLast();

        // Make the pointers of adjacent nodes skip over 'node'
        node.Next.Previous = node.Previous;
        node.Previous.Next = node.Next;

        // Temporarily store the data we want to return
        T data = node.Data;

        // Memory cleanup
        node.Data = default!;
        node.Previous = null;
        node.Next = null;

        --Size;

        return data;
    }

    public T RemoveAt(int index)
    {
        // Make sure the index provided is valid -_-
        if (index < 0 || index >= Size) throw new IndexOutOfRangeException();

        int i;
        Node<T> traverse;

        // Search from the front of the list
        if (index < Size / 2)
        {
            for (i = 0, traverse = _head!; i != index; i++)
            {
                traverse = traverse!.Next!;
            }
        }
        // Search from the back of the list
        else
        {
            for (i = Size - 1, traverse = _tail!; i != index; i++)
            {
                traverse = traverse!.Previous!;
            }
        }

        return Remove(traverse);
    }

    public bool Remove(T item)
    {
        // Support searching for null
        if (default(T) is null || item is null)
        {
            for (Node<T>? traverse = _head; traverse != null; traverse = traverse.Next)
            {
                if (traverse.Data is not null) continue;
                Remove(traverse);
                return true;
            }
        }
        // Search for a non-null object
        else
        {
            for (Node<T>? traverse = _head; traverse != null; traverse = traverse.Next)
            {
                if (!item.Equals(traverse.Data)) continue;
                Remove(traverse);
                return true;
            }
        }

        return false;
    }

    public int IndexOf(T item)
    {
        var index = 0;

        // Support searching for null
        if (default(T) is null || item is null)
        {
            for (Node<T>? traverse = _head; traverse != null; traverse = traverse.Next, index++)
            {
                if (traverse.Data is null)
                {
                    return index;
                }
            }
        }
        // Search for a non-null object
        else
        {
            for (Node<T>? traverse = _head; traverse != null; traverse = traverse.Next, index++)
            {
                if (item.Equals(traverse.Data))
                {
                    return index;
                }
            }
        }

        return -1;
    }

    public bool Contains(T item) => IndexOf(item) > -1;

    private class Node<TNode>
    {
        public Node(TNode data, Node<TNode>? previous, Node<TNode>? next)
        {
            Data = data;
            Previous = previous;
            Next = next;
        }

        public TNode Data { get; set; }
        public Node<TNode>? Previous { get; set; }
        public Node<TNode>? Next { get; set; }
    }
}
