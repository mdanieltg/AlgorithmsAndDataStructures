using System.Collections;

namespace AlgorithmsAndDataStructures.DataStructures;

/// <summary>
/// Represents a doubly linked list data structure that implements the IEnumerable interface.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class DoublyLinkedList<T> : IEnumerable<T>
{
    /// <summary>
    /// Reference to the first node in the list.
    /// </summary>
    private Node<T>? _head;

    /// <summary>
    /// Reference to the last node in the list.
    /// </summary>
    private Node<T>? _tail;

    /// <summary>
    /// Gets the number of elements in the list.
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the list is empty.
    /// </summary>
    public bool IsEmpty => Size == 0;

    /// <summary>
    /// Returns an enumerator that iterates through the list.
    /// </summary>
    /// <returns>An enumerator for the list.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? traverse = _head;
        while (traverse is not null)
        {
            yield return traverse.Data;
            traverse = traverse.Next;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the list.
    /// </summary>
    /// <returns>An IEnumerator for the list.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Adds an item to the end of the list.
    /// </summary>
    /// <param name="item">The item to add to the list.</param>
    public void Add(T item)
    {
        AddLast(item);
    }

    /// <summary>
    /// Adds an item to the beginning of the list.
    /// </summary>
    /// <param name="item">The item to add to the list.</param>
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

    /// <summary>
    /// Adds an item to the end of the list.
    /// </summary>
    /// <param name="item">The item to add to the list.</param>
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

    /// <summary>
    /// Removes all items from the list.
    /// </summary>
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

    /// <summary>
    /// Returns the first element in the list without removing it.
    /// </summary>
    /// <returns>The first element in the list.</returns>
    /// <exception cref="System.Exception">Thrown when the list is empty.</exception>
    public T PeekFirst()
    {
        if (IsEmpty) throw new Exception("The list is empty.");
        return _head!.Data;
    }

    /// <summary>
    /// Returns the last element in the list without removing it.
    /// </summary>
    /// <returns>The last element in the list.</returns>
    /// <exception cref="System.Exception">Thrown when the list is empty.</exception>
    public T PeekLast()
    {
        if (IsEmpty) throw new Exception("The list is empty.");
        return _tail!.Data;
    }

    /// <summary>
    /// Removes and returns the first element in the list.
    /// </summary>
    /// <returns>The first element in the list.</returns>
    /// <exception cref="System.Exception">Thrown when the list is empty.</exception>
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

    /// <summary>
    /// Removes and returns the last element in the list.
    /// </summary>
    /// <returns>The last element in the list.</returns>
    /// <exception cref="System.Exception">Thrown when the list is empty.</exception>
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

    /// <summary>
    /// Removes the specified node from the list.
    /// </summary>
    /// <param name="node">The node to remove.</param>
    /// <returns>The data contained in the removed node.</returns>
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

    /// <summary>
    /// Removes and returns the element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to remove.</param>
    /// <returns>The element at the specified index.</returns>
    /// <exception cref="System.IndexOutOfRangeException">Thrown when the index is out of range.</exception>
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

    /// <summary>
    /// Removes the first occurrence of a specific object from the list.
    /// </summary>
    /// <param name="item">The object to remove from the list.</param>
    /// <returns>true if <paramref name="item"/> was successfully removed; otherwise, false.</returns>
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

    /// <summary>
    /// Returns the zero-based index of the first occurrence of a value in the list.
    /// </summary>
    /// <param name="item">The object to locate in the list.</param>
    /// <returns>The zero-based index of the first occurrence of <paramref name="item"/>, if found; otherwise, -1.</returns>
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

    /// <summary>
    /// Determines whether an element is in the list.
    /// </summary>
    /// <param name="item">The object to locate in the list.</param>
    /// <returns>true if <paramref name="item"/> is found in the list; otherwise, false.</returns>
    public bool Contains(T item) => IndexOf(item) > -1;

    /// <summary>
    /// Represents a node in the doubly linked list.
    /// </summary>
    /// <typeparam name="TNode">The type of data stored in the node.</typeparam>
    private class Node<TNode>
    {
        /// <summary>
        /// Initializes a new instance of the Node class.
        /// </summary>
        /// <param name="data">The data to store in the node.</param>
        /// <param name="previous">Reference to the previous node.</param>
        /// <param name="next">Reference to the next node.</param>
        public Node(TNode data, Node<TNode>? previous, Node<TNode>? next)
        {
            Data = data;
            Previous = previous;
            Next = next;
        }

        /// <summary>
        /// Gets or sets the data stored in this node.
        /// </summary>
        public TNode Data { get; set; }

        /// <summary>
        /// Gets or sets the reference to the previous node in the list.
        /// </summary>
        public Node<TNode>? Previous { get; set; }

        /// <summary>
        /// Gets or sets the reference to the next node in the list.
        /// </summary>
        public Node<TNode>? Next { get; set; }
    }
}
