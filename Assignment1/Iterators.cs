namespace Assignment1;

public static class Iterators
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> itemsOfItems) {
        foreach (var items in itemsOfItems) {
            foreach (var item in items) {
                yield return item;
            }
        }
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate) {
        foreach (var item in items) {
            if (predicate(item)) yield return item;
        }
    }

    public static int GreaterCount<T, U>(IEnumerable<T> items, T x) where T : IComparable<T> {
        var greaterThanCounter = 0;
        foreach (var item in items)
        {
            if (item.CompareTo(x) >= 1)
                greaterThanCounter++;
        }
        return greaterThanCounter;
    }

    // public static int GreaterCount<T, U>(IEnumerable<T> items, T x) where T : U where U : IComparable<U> {
    //     var greaterThanCounter = 0;
    //     foreach (var item in items)
    //     {
    //         if (item.CompareTo(x) >= 1)
    //             greaterThanCounter++;
    //     }
    //     return greaterThanCounter;
    // }
}