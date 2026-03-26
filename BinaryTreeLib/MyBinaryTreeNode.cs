namespace BinaryTreeLib;

public class MyBinaryTreeNode<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public MyBinaryTreeNode<T> Left { get; set; }
    public MyBinaryTreeNode<T> Right { get; set; }

    public MyBinaryTreeNode(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
    public int CompareTo(T other)
    {
        return Value.CompareTo(other);
    }
}
