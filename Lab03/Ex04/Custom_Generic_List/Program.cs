using Custom_Generic_List;
class Program
{
    static void Main(string[] args)
    {
        CustomList<int> myList = new CustomList<int>();

        myList.Add(23);
        myList.Add(01);
        myList.Add(2003);
        myList.Add(14);
        myList.Add(06);
        myList.Add(13);
        myList.Add(05);

        Console.WriteLine("Elements in the list:");
        myList.Print();
        Console.WriteLine("========================================");

        Console.WriteLine($"Element at index 1: {myList[5]}");
        Console.WriteLine("========================================");

        myList.Remove(2003);
        Console.WriteLine("After removing 2003:");
        myList.Print();
        Console.WriteLine("========================================");

    }
}