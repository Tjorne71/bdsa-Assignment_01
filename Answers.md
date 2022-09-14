<!-- Exercise 1, generics -->
```csharp
int GreaterCount<T, U>(IEnumerable<T> items, T x)
    where T : IComparable<T>;

int GreaterCount<T, U>(IEnumerable<T> items, T x)
    where T : U
    where U : IComparable<U>;
```

Both methods returns the amount of elements in `items` which are *greater than* `x`.

Explain in your own words what the type constraints mean for both methods.
    - In the first method there is no constraints on U, bot only on T. Meaning that U could be any generic type. The only constraint is that T has to implment the interface IEnumerable
    - In the second method there is a contraint on T. The constraint means that T should be of the same generic type as U and that U has to implement the interface IEnumerable. The constraints means that its is posible to compare type T to type U, which is not posible in the first method

<!-- Exercise 2, generics -->

    