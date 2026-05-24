namespace MergeSort;

public class CustomMergeSort<T> where T : IComparable<T>
{
    public void MergeSort(T[] items)
    {
        if (items.Length <= 1)
        {
            return;
        }

        int leftSize = items.Length / 2;
        int rightSize = items.Length - leftSize;

        T[] left = new T[leftSize];
        T[] right = new T[rightSize];

        Array.Copy(items, 0, left, 0, leftSize);
        Array.Copy(items, leftSize, right, 0, rightSize);

        MergeSort(left);
        MergeSort(right);
        Merge(items, left, right);
    }

    private void Merge(T[] items, T[] left, T[] right)
    {
        int i = 0, j = 0, k = 0;

        int remaining = left.Length + right.Length;
        while (remaining > 0)
        {
            if (i >= left.Length)
            {
                Assign(items, k, right[j++]);
            }
            else if (j >= right.Length)
            {
                Assign(items, k, left[i++]);
            }
            else if (Compare(left[i], right[j]) <= 0)
            {
                Assign(items, k, left[i++]);
            }
            else
            {
                Assign(items, k, right[j++]);
            }
            k++;
            remaining--;
        }
    }

    private int Compare(T t1, T t2)
    {
        return t1.CompareTo(t2);
    }

    private void Assign(T[] items, int k, T t)
    {
        items[k] = t;
    }
}