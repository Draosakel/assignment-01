namespace Assignment1;

public static class Iterators
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
    {
        foreach (var item in items)
        {
            foreach (var inner in item)
            {
                yield return inner;
            }
        }
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
    {
        foreach (var item in items)
        {
            if (predicate.Invoke(item))
            {
                yield return item;
            }
        }
    }
}