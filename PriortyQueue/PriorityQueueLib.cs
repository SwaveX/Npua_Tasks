using System.Collections;
using LinkedListLib;

namespace PriorityQueue;

public class PriorityQueueLib<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private readonly SinglyLinkedList<T> _items = new();
    public int Count => _items.Count;

    public void Enqueue(T item)
    {
        if (_items.Count == 0)
        {
            _items.AddFirst(item);
            return;
        }

        SinglyNode<T>? previous = null;
        SinglyNode<T>? current = _items.Head;

        while (current != null && current.Value.CompareTo(item) > 0)
        {
            previous = current;
            current = current.Next;
        }

        if (previous == null)
        {
            _items.AddFirst(item);
        }
        else
        {
            _items.InsertAfter(previous, item);

            // Special case:
            // inserted before current automatically
            // because InsertAfter reconnects the chain
        }
    }

    public T Dequeue()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty");
        }

        T value = _items.Head!.Value;

        _items.RemoveFirst();

        return value;
    }

    public T Peek()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty");
        }

        return _items.Head!.Value;
    }

    

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}