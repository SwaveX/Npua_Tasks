namespace QuickSort;

public class CustomQuickSort<T> where T : IComparable<T>
{
    public void QuickSort(T[] items)
    {
        if (items == null || items.Length <= 1) return;
        Sort(items, 0, items.Length - 1);
    }

    private void Sort(T[] items, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(items, low, high);
            Sort(items, low, pivotIndex - 1);
            Sort(items, pivotIndex + 1, high);
        }
    }

    private int Partition(T[] items, int low, int high)
    {
        T pivot = items[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (Compare(items[j], pivot) <= 0)
            {
                i++;
                Swap(items, i, j);
            }
        }

        Swap(items, i + 1, high);
        return i + 1;
    }

    private void Swap(T[] items, int a, int b)
    {
        T temp = items[a];
        items[a] = items[b];
        items[b] = temp;
    }

    private int Compare(T t1, T t2)
    {
        return t1.CompareTo(t2);
    }

    public void ExecuteSort(T[] items)
    {
        QuickSort(items);
    }
}