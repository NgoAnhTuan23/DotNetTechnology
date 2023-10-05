using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Basic_Multithreading
{
    static void Main(string[] args)
    {
        const int N = 1000000;
        const int NumThreads = 10;
        
        Stopwatch stopwatch = new Stopwatch();

        //SingleThread
        stopwatch.Start();
        long sumSingleThread = CalculateSumSingleThread(N);
        stopwatch.Stop();
        Console.WriteLine($"Sum: {sumSingleThread}");
        Console.WriteLine($"Execution time (one thread): {stopwatch.ElapsedMilliseconds} ms");

        Console.WriteLine("=========================================================");

        //MultiThread
        stopwatch.Start();
        long sumMultiThread = CalculateSumMultiThread(N, NumThreads);
        stopwatch.Stop();
        Console.WriteLine($"Sum: {sumMultiThread}");
        Console.WriteLine($"Execution time (multiple thread): {stopwatch.ElapsedMilliseconds} ms");
    }

    static long CalculateSumSingleThread(int N)
    {
        long sum = 0;
        for (int i = 1; i <= N; i++)
        {
            sum += i;
        }
        return sum;
    }

    static long CalculateSumMultiThread(int N, int numThreads)
    {
        long sum = 0;

        // Tạo mảng để lưu trữ kết quả từ các thread con
        long[] results = new long[numThreads];

        // Tạo và khởi động các task
        Task[] tasks = new Task[numThreads];
        for (int i = 0; i < numThreads; i++)
        {
            int threadNumber = i;
            tasks[i] = Task.Run(() =>
            {
                long partialSum = 0;
                int start = threadNumber * (N / numThreads) + 1;
                int end = (threadNumber == numThreads - 1) ? N : start + (N / numThreads) - 1;
                for (int j = start; j <= end; j++)
                {
                    partialSum += j;
                }
                results[threadNumber] = partialSum;
            });
        }

        // Đợi cho tất cả các task hoàn thành
        Task.WaitAll(tasks);

        // Tổng hợp kết quả từ các thread con
        for (int i = 0; i < numThreads; i++)
        {
            sum += results[i];
        }

        return sum;
    }
}