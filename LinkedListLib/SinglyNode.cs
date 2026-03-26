using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListLib;

public class SinglyNode<T>
{
    public T Value { get; set; }
    public SinglyNode<T>? Next { get; internal set; }

    public SinglyNode(T value)
    {
        Value = value;
        Next = null;
    }
}
