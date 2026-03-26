using LinkedListLib;

namespace StackLib;

/// <summary>
/// Represents a generic stack data structure implemented using a linked list.
/// Follows LIFO (Last In, First Out) principle.
/// </summary>
/// <typeparam name="T">The type of elements stored in the stack.</typeparam>
public class LinkedListStack<T>
{
    private readonly SinglyLinkedList<T> _list;

    /// <summary>
    /// Initializes a new instance of the LinkedListStack class that is empty.
    /// </summary>
    public LinkedListStack()
    {
        _list = new SinglyLinkedList<T>();
    }

    /// <summary>
    /// Gets the number of elements in the stack.
    /// </summary>
    public int Count => _list.Count;

    /// <summary>
    /// Pushes an element onto the top of the stack.
    /// </summary>
    /// <param name="item">The item to push onto the stack.</param>
    public void Push(T item)
    {
        _list.AddFirst(item); // Add to front for O(1) push
    }

    /// <summary>
    /// Removes and returns the element at the top of the stack.
    /// </summary>
    /// <returns>The element removed from the top of the stack.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack underflow - cannot pop from empty stack");
        }

        T value = _list.Head.Value;
        _list.RemoveFirst();
        return value;
    }

    /// <summary>
    /// Returns the element at the top of the stack without removing it.
    /// </summary>
    /// <returns>The element at the top of the stack.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _list.Head.Value;
    }

    /// <summary>
    /// Determines whether the stack is empty.
    /// </summary>
    /// <returns>True if the stack is empty; otherwise, false.</returns>
    public bool IsEmpty()
    {
        return _list.Count == 0;
    }

    /// <summary>
    /// Removes all elements from the stack.
    /// </summary>
    public void Clear()
    {
        _list.Clear();
    }

    /// <summary>
    /// Determines whether the stack contains a specific value.
    /// </summary>
    /// <param name="value">The value to search for in the stack.</param>
    /// <returns>True if the value is found; otherwise, false.</returns>
    public bool Contains(T value)
    {
        return _list.Contains(value);
    }

    /// <summary>
    /// Copies the stack elements to a new array.
    /// </summary>
    /// <returns>An array containing copies of the stack elements in LIFO order.</returns>
    public T[] ToArray()
    {
        T[] result = new T[Count];
        int index = 0;

        foreach (var item in _list)
        {
            result[index++] = item;
        }

        return result;
    }
}
