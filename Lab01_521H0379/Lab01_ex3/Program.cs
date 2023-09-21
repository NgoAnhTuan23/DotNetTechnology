class Program
{
    static void Main()
    {
        Random random = new Random();
        int n = random.Next(1, 100);
        int c = 0;
        Console.WriteLine("Let's guess the number (1 - 100): ");
        do
        {
            if (int.TryParse(Console.ReadLine(), out int a))
            {
                if (a < n)
                {
                    Console.WriteLine("Too Low!!");
                    c++;
                }
                else if (a > n)
                {
                    Console.WriteLine("Too High!!");
                    c++;
                }
                else
                {
                    Console.WriteLine("Congratulation!!");
                    c++;
                    Console.WriteLine($"Number of times you guessed: {c}");
                    break;
                }
            }
            else Console.WriteLine("Error Number!!");
        }
        while (true);
    }
}