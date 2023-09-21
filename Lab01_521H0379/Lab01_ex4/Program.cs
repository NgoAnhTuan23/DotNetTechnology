using System;

class Program
{
    static void Main()
    {
        String filePath = "input.txt";
        StreamReader reader = new StreamReader(filePath);

        Console.WriteLine("=========== Choose your option ===========");
        Console.WriteLine($"=====  1. Print list animals in file =====");
        Console.WriteLine($"=====  2. Search the animal in file  =====");
        Console.WriteLine("==========================================");
        String s = Console.ReadLine();

        if(int.TryParse(s, out int n))
        {
            if(n == 1)
            {
                String line;
                while((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            if(n == 2)
            {
                Console.WriteLine("Enter the name of animal that you want to search: ");
                String name = Console.ReadLine();
                String line;
                int c = 0;

                while((line = reader.ReadLine().Trim()) != null)
                {
                    if(line.Equals(name))
                    {
                        Console.WriteLine($"{name} exists in the file!");
                        c++;
                        break;
                    }
                }

                if (c == 0) Console.WriteLine($"{name} dose not exists in the file!");
            }
        }
    }
}