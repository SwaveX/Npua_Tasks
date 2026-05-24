namespace PostfixCalc;

internal class Program
{
    private static readonly Dictionary<string, Func<int, int, int>> Operators =
        new()
        {
            ["+"] = (a, b) => a + b,
            ["-"] = (a, b) => a - b,
            ["*"] = (a, b) => a * b,
            ["/"] = (a, b) => a / b
        };

    private static void Main()
    {
        string expression = "5 2 3 * +";

        int result = Evaluate(expression);

        Console.WriteLine(result);
    }

    private static int Evaluate(string expression)
    {
        Stack<int> stack = new();

        foreach (string token in expression.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            if (int.TryParse(token, out int number))
            {
                stack.Push(number);
                continue;
            }

            if (!Operators.TryGetValue(token, out var operation))
            {
                throw new InvalidOperationException($"Unknown operator: {token}");
            }

            if (stack.Count < 2)
            {
                throw new InvalidOperationException("Invalid postfix expression.");
            }

            int right = stack.Pop();
            int left = stack.Pop();

            stack.Push(operation(left, right));
        }

        if (stack.Count != 1)
        {
            throw new InvalidOperationException("Invalid postfix expression.");
        }

        return stack.Pop();
    }
}