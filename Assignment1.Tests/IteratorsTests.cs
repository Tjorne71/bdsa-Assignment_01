using Xunit;
namespace Assignment1.Tests;


public class IteratorsTests
{
    [Fact]
    public void Flatten_A_List_Of_List_Without_Duplicates_To_One_List()
    {
        List<int> list1 = new List<int>(){ 1, 2, 3};
        List<int> list2 = new List<int>(){ 4, 5, 6};
        List<List<int>> listOfList = new List<List<int>>(2) {list1, list2};
        var flat = Iterators.Flatten(listOfList);
        Assert.Equal(new List<int>(){ 1, 2, 3, 4, 5, 6}, flat);
    }

    [Fact]
    public void Flatten_A_List_Of_List_With_Duplicates_To_One_List()
    {
        List<int> list1 = new List<int>(){ 1, 2, 3};
        List<int> list2 = new List<int>(){ 1, 2, 3};
        List<List<int>> listOfList = new List<List<int>>(2) {list1, list2};
        var flat = Iterators.Flatten(listOfList);
        Assert.Equal(new List<int>(){ 1, 2, 3, 1, 2, 3}, flat);
    }

    [Fact]
    public void Filter_A_List_of_5_6_7_With_Predicate_all_over_6_returns_7() { 
        Predicate<int> even = isOverSix;
        bool isOverSix(int i) => i > 6;
        List<int> list = new List<int>(){5, 6, 7};
        var filter = Iterators.Filter(list, isOverSix);
        Assert.Equal(new List<int>(){ 7 }, filter);
    }
    [Fact]
    public void Filter_For_Positive_Numbers() { 
        Predicate<int> even = isPositive;
        bool isPositive(int i) => i > 0;
        List<int> list = new List<int>(){-1, 0, 1, 2};
        var filter = Iterators.Filter(list, isPositive);
        Assert.Equal(new List<int>(){ 1, 2 }, filter);
    }

    [Fact]
    public void Filter_For_Even_Numbers() { 
        Predicate<int> even = isEven;
        bool isEven(int i) => i % 2 == 0;
        List<int> list = new List<int>(){0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
        var filter = Iterators.Filter(list, even);
        Assert.Equal(new List<int>(){ 0, 2, 4, 6, 8, 10, 12 }, filter);
    }
}