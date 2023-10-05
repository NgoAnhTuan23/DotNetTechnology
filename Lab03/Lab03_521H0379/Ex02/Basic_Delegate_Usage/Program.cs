class Basic_Delegate_Usage
{
    delegate int MathOperation(int a, int b);
    
    static void Main(string[] args)
    {
        int Add(int a, int b)
        {
            return a + b;
        }

        int Subtract(int a, int b)
        {
            return a - b;
        }

        int Multiply(int a, int b)
        {
            return a * b;
        }

        int Divide(int a, int b)
        {
            if(b == 0)
            {
                return 0;
            }
            return a / b;
        }

        MathOperation addTwoInt = Add;
        MathOperation subtractTwoInt = Subtract;
        MathOperation multiplyTwoInt = Multiply;
        MathOperation divideTwoInt = Divide;

        Console.WriteLine($"23 + 1 = {addTwoInt(23, 1)}");
        Console.WriteLine("============================");

        Console.WriteLine($"521 - 379 = {subtractTwoInt(521, 379)}");
        Console.WriteLine("============================");

        Console.WriteLine($"23 * 1 = {multiplyTwoInt(23, 1)}");
        Console.WriteLine("============================");

        Console.WriteLine($"2003 / 23 = {divideTwoInt(2003, 23)}");
        Console.WriteLine("============================");
    }
}