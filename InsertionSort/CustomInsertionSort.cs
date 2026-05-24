namespace InsertionSort;

public class CustomInsertionSort<T>
    where T : IComparable<T>
{
    public void InsertionSort(T[] items)
    {
        for (int i = 1; i < items.Length; i++)
        {
            T key = items[i];
            int j = i - 1;

            while (j >= 0 && Compare(items[j], key) > 0)
            {
                items[j + 1] = items[j];
                j--;
            }
            items[j + 1] = key;
        }
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
}