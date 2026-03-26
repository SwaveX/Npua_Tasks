using LinkedListLib;

namespace DataStructuresLib.Queue;

public class QueueLib<T>
{
    private readonly SinglyLinkedList<T> _list = new();

    public int Count => _list.Count;

    public bool IsEmpty => _list.Count == 0;

    public void Enqueue(T item)
    {
        _list.AddLast(item);
    }

    public T Dequeue()
    {
        T ret = _list.Head.Value;
        _list.RemoveFirst();

        return ret;
    }

    public T Peek()
    {
        if (_list.Head == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return _list.Head.Value;
    }
}
