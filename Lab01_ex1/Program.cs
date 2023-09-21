class Lab01_ex1
{
    static void Main()
    {
        Console.WriteLine("Enter the operation you want: ");
        String[] s = Console.ReadLine().Split(" ");
        
        if (s.Length != 3)
        {
            Console.WriteLine("Error!");
        }
        else
        {
            if (s[2] != "+" || s[2] != "-" || s[2] != "x" || s[2] != "/")
            {
                Console.WriteLine("Invalid Oparator!");
                return;
            }
            if (int.TryParse(s[1], out int val))
            {
                int a = int.Parse(s[0]);
                int b = int.Parse(s[1]);
                char opera = char.Parse(s[2]);
                int result = 0;
                switch (opera)
                {
                    case '+':
                        result = a + b;
                        break;
                    case '-':
                        result = a - b;
                        break;
                    case 'x':
                        result = a * b;
                        break;
                    case '/':
                        if (b == 0)
                        {
                            Console.WriteLine("Cannot divide by zero!");
                            return;
                        }
                        else result = a / b;
                        break;
                }
                Console.WriteLine("Result: " + result);
            }

            else Console.WriteLine("Invalid Expression!!");  
        }
    }
}