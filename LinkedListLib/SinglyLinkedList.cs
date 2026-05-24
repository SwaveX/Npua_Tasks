using System.Collections;

namespace LinkedListLib;

/// <summary>
/// Represents a generic singly linked list data structure that implements the IEnumerable interface.
/// </summary>
/// <typeparam name="T">The type of elements stored in the linked list.</typeparam>
public class SinglyLinkedList<T> : IEnumerable<T>
{
    /// <summary>
    /// Initializes a new instance of the CustomLinkedList class that is empty.
    /// </summary>
    public SinglyLinkedList()
    {

    }


    /// <summary>
    /// Initializes a new instance of the CustomLinkedList class that contains elements from the specified collection.
    /// </summary>
    /// <param name="collection">The collection whose elements are copied to the new list.</param>
    /// <exception cref="ArgumentNullException">Thrown when collection is null.</exception>
    public SinglyLinkedList(IEnumerable<T> collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        foreach (var item in collection)
        {
            AddLast(item);
        }
    }


    /// <summary>
    /// Gets the first node in the linked list, or null if the list is empty.
    /// </summary>
    public SinglyNode<T>? Head { get; private set; } = null;

    
    /// <summary>
    /// Gets the first node in the linked list as a convenience property.
    /// </summary>
    /// <remarks>This property provides an alias to the Head property for improved readability.</remarks>
    public SinglyNode<T> First => Head;


    /// <summary>
    /// Gets the last node in the linked list, or null if the list is empty.
    /// </summary>
    public SinglyNode<T>? Tail { get; private set; } = null;
    

    /// <summary>
    /// Gets the number of nodes in the linked list.
    /// </summary>
    public int Count { get; private set; } = 0;


    /// <summary>
    /// Determines whether the linked list contains a specific value.
    /// </summary>
    /// <param name="value">The value to search for in the linked list.</param>
    /// <returns>True if the value is found; otherwise, false.</returns>
    public bool Contains(T value)
    {
        var current = Head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }


    /// <summary>
    /// Finds and returns the first node containing the specified value.
    /// </summary>
    /// <param name="value">The value to search for in the linked list.</param>
    /// <returns>The node containing the specified value, or null if not found.</returns>
    public SinglyNode<T>? Find(T value)
    {
        var current = Head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }


    /// <summary>
    /// Adds a new node with the specified value at the beginning of the linked list.
    /// </summary>
    /// <param name="value">The value to add to the beginning of the list.</param>
    public void AddFirst(T value)
    {
        var newNode = new SinglyNode<T>(value);

        if (Count == 0)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head = newNode;
        }

        Count++;
    }


    /// <summary>
    /// Adds a new node with the specified value at the end of the linked list.
    /// </summary>
    /// <param name="value">The value to add to the end of the list.</param>
    public void AddLast(T value)
    {
        var newNode = new SinglyNode<T>(value);

        if (Count == 0)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            Tail = newNode;
        }

        Count++;
    }


    /// <summary>
    /// Adds a new node with the specified value after the specified existing node.
    /// </summary>
    /// <param name="node">The node after which to insert the new value.</param>
    /// <param name="value">The value to add after the specified node.</param>
    /// <exception cref="ArgumentNullException">Thrown when node is null.</exception>
    public void AddAfter(SinglyNode<T> node, T value)
    {
        ArgumentNullException.ThrowIfNull(node);

        SinglyNode<T> newNodeToAdd = new(value);

        if (node == Tail)
        {
            Tail.Next = newNodeToAdd;
            Tail = newNodeToAdd;
        }
        else
        {
            SinglyNode<T> oldNextNode = node.Next;
            node.Next = newNodeToAdd;
            newNodeToAdd.Next = oldNextNode;
        }

        Count++;
    }


    /// <summary>
    /// Inserts a new node with the specified <paramref name="value"/> immediately after the
    /// given <paramref name="previousNode"/> in the list.
    /// </summary>
    /// <param name="previousNode">The node after which the new node will be inserted. Must not be <c>null</c>
    /// and should belong to this list.</param>
    /// <param name="value">The value to store in the newly inserted node.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="previousNode"/> is <c>null</c>.</exception>
    /// <remarks>
    /// The insertion is performed in O(1) time. If <paramref name="previousNode"/> is the current tail,
    /// the newly inserted node becomes the new tail. The list's <see cref="Count"/> is incremented by one.
    /// </remarks>
    public void InsertAfter(SinglyNode<T> previousNode, T value)
    {
        ArgumentNullException.ThrowIfNull(previousNode);

        SinglyNode<T> newNode = new(value);

        newNode.Next = previousNode.Next;
        previousNode.Next = newNode;

        if (Tail == previousNode)
        {
            Tail = newNode;
        }

        Count++;
    }


    /// <summary>
    /// Removes the first node from the linked list.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
    public void RemoveFirst()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }
        else if (Count == 1)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            Head = Head.Next;
        }

        Count--;
    }


    /// <summary>
    /// Removes the last node from the linked list.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
    public void RemoveLast()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        if (Count == 1)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            SinglyNode<T> current = Head;
            while (current != null)
            {
                if (current.Next == Tail)
                {
                    current.Next = null;
                    Tail = current;

                    break;
                }

                current = current.Next;
            }
        }

        Count--;
    }


    /// <summary>
    /// Removes the first node containing the specified value from the linked list.
    /// </summary>
    /// <param name="value">The value to remove from the list.</param>
    /// <returns>True if a node with the specified value was removed; otherwise, false.</returns>
    public bool Remove(T value)
    {
        if (Count == 0)
        {
            return false;
        }

        SinglyNode<T> previous = null;
        SinglyNode<T> current = Head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                if (previous == null)       // removing Head
                {
                    Head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }

                if (current == Tail)        // removing Tail
                {
                    Tail = previous;
                }

                Count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }


    /// <summary>
    /// Removes the specified node from the linked list.
    /// </summary>
    /// <param name="node">The node to remove from the linked list.</param>
    public void Remove(SinglyNode<T> node)
    {
        if (Head == null)
            return;

        if (Head == node)
        {
            RemoveFirst();
            return;
        }

        var current = Head;

        while (current.Next != null)
        {
            if (current.Next == node)
            {
                current.Next = node.Next;

                if (node == Tail)
                {
                    Tail = current;
                }

                Count--;

                return;
            }

            current = current.Next;
        }
    }


    /// <summary>
    /// Removes all nodes from the linked list.
    /// </summary>
    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }


    /// <summary>
    /// Returns an enumerator that iterates through the linked list.
    /// </summary>
    /// <returns>An enumerator for the linked list.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        var current = Head;

        while (current != null)
        {
            yield return current.Value;

            current = current.Next;
        }
    }


    /// <summary>
    /// Returns an enumerator that iterates through the linked list.
    /// </summary>
    /// <returns>An enumerator for the linked list.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

