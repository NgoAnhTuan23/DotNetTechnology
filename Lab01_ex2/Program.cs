using Lib01_ex2;

class MyClass
{
    public static void Main()
    {
        int n = 0;
        do
        {
            Console.WriteLine("Enter Integer number: ");
            String s = Console.ReadLine();
            
            if(int.TryParse(s, out int a))
            {
                n = a;
                long result = Lib01_ex2.Factorial.calculateFatorial(n);
                Console.WriteLine($"n! = {result}");
            }
        }
        while (n != -1);
    }
}