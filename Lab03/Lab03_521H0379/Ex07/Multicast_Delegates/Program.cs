using System;

class Multicast_Delegates
{
    delegate string StringOperation(string input);

    static string ToUpper(string input) { return input.ToUpper(); }

    static string ToLower(string input) { return input.ToLower(); }
    static void Main(string[] args)
    {
        StringOperation s = ToUpper;

        string a = "Ngo Anh Tuan";
        Console.WriteLine($"String: {a}");
        Console.WriteLine("=============================");

        a = s(a);
        Console.WriteLine("Upper: ");
        Console.WriteLine(a);
        Console.WriteLine("=============================");

        s += ToLower;
        a = s(a);
        Console.WriteLine("Lower: ");
        Console.WriteLine(a);
        Console.WriteLine("=============================");
    }
}
