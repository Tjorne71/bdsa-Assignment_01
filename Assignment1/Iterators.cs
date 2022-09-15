namespace Assignment1;

public static class Iterators
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items) {
        foreach (IEnumerable<T> e in items) {
            foreach (T t in e) {
                yield return t;
            }
        }
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate) {
        foreach(T item in items) {
            if(predicate(item)) {
                yield return item;
            }
        }
    }
}