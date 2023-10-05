class Simple_Lambda_Expressions
{
    static void Main(string[] args)
    {
        Func<int, int, int> sum = (x, y) => x + y;
        Console.WriteLine($"23 + 1 = {sum(23, 1)}");
        Console.WriteLine("==========================");

        Func<string, int> len = s => s.Length;
        Console.WriteLine($"Length of 'NgoAnhTuan' = {len("NgoAnhTuan")}");
        Console.WriteLine("==========================");

        Func<int, Boolean> checkEven = a => a % 2 == 0;
        Console.WriteLine($"2003 is an even number? -> {checkEven(2003)}");
        Console.WriteLine("==========================");

        List<int> listInt = new List<int>() {1,2,3,4,5,6,7};
        List<int> listEvens = listInt.Where(checkEven).ToList();
        Console.Write("List even number: ");
        foreach (int a in listEvens)
        {
            Console.Write($"{a} ");
        }
        Console.WriteLine();
        Console.WriteLine("==========================");
    }
}