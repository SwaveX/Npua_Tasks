using LinkedListLib;
using DataStructuresLib.Queue;
using StackLib;
using BinaryTreeLib;

namespace Testing_Battle_Ground;

public class Program
{
    private static void Main()
    {
        Console.WriteLine("=== LINKED LIST TEST ===");
        TestLinkedList();

        Console.WriteLine("\n=== QUEUE TEST ===");
        TestQueue();

        Console.WriteLine("\n=== STACK TEST ===");
        TestStack();

        Console.WriteLine("\n=== BINARY TREE TEST ===");
        TestBinaryTree();
    }

    // ---------------- LINKED LIST ----------------
    private static void TestLinkedList()
    {
        var list = new SinglyLinkedList<int>();

        list.AddFirst(3);
        list.AddFirst(1);
        list.AddLast(5);
        list.AddLast(7);

        Console.WriteLine("Initial list:");
        Print(list);

        Console.WriteLine($"Contains 5? {list.Contains(5)}");

        Console.WriteLine("Removing 3...");
        list.Remove(3);
        Print(list);

        Console.WriteLine("Remove First:");
        list.RemoveFirst();
        Print(list);

        Console.WriteLine("Remove Last:");
        list.RemoveLast();
        Print(list);
    }

    // ---------------- QUEUE ----------------
    private static void TestQueue()
    {
        var queue = new QueueLib<string>();

        queue.Enqueue("A");
        queue.Enqueue("B");
        queue.Enqueue("C");

        Console.WriteLine($"Peek: {queue.Peek()}");

        while (!queue.IsEmpty)
        {
            Console.WriteLine($"Dequeued: {queue.Dequeue()}");
        }
    }

    // ---------------- STACK ----------------
    private static void TestStack()
    {
        var stack = new LinkedListStack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine($"Peek: {stack.Peek()}");

        while (!stack.IsEmpty())
        {
            Console.WriteLine($"Popped: {stack.Pop()}");
        }
    }

    // ---------------- BINARY TREE ----------------
    private static void TestBinaryTree()
    {
        var tree = new MyBinaryTree<int>();

        int[] values = { 5, 3, 7, 2, 4, 6, 8 };

        foreach (var v in values)
        {
            tree.Add(v);
        }

        Console.WriteLine("In-Order Traversal (sorted):");
        foreach (var v in tree)
        {
            Console.Write(v + " ");
        }

        Console.WriteLine("\nPre-Order Traversal:");
        foreach (var v in tree.PreOrder())
        {
            Console.Write(v + " ");
        }

        Console.WriteLine("\nRemoving 7...");
        tree.Remove(7);

        Console.WriteLine("In-Order after removal:");
        foreach (var v in tree)
        {
            Console.Write(v + " ");
        }

        Console.WriteLine();
    }

    // ---------------- HELPER ----------------
    private static void Print<T>(SinglyLinkedList<T> list)
    {
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }
}
