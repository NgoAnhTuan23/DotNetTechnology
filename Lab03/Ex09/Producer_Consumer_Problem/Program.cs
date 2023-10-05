using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static Queue<int> buffer = new Queue<int>();
    static readonly int bufferSize = 5; // Kích thước của hàng đợi
    static readonly object bufferLock = new object();

    static void Main()
    {
        Thread producerThread = new Thread(Producer);
        Thread consumerThread = new Thread(Consumer);

        producerThread.Start();
        consumerThread.Start();

        producerThread.Join();
        consumerThread.Join();
    }

    static void Producer()
    {
        for (int i = 0; i < 10; i++)
        {
            // Tạo sản phẩm
            int item = i;

            lock (bufferLock)
            {
                // Kiểm tra nếu hàng đợi đã đầy
                while (buffer.Count >= bufferSize)
                {
                    Console.WriteLine("Producer is waiting...");
                    Monitor.Wait(bufferLock);
                    Thread.Sleep(2000);
                }

                // Đưa sản phẩm vào hàng đợi
                buffer.Enqueue(item);
                Console.WriteLine($"Produced: {item}");
                Monitor.Pulse(bufferLock);
            }
        }
        Thread.Sleep(2000);
    }

    static void Consumer()
    {
        for (int i = 0; i < 10; i++)
        {
            int item;

            lock (bufferLock)
            {
                // Kiểm tra nếu hàng đợi rỗng
                while (buffer.Count == 0)
                {
                    Console.WriteLine("Consumer is waiting...");
                    Monitor.Wait(bufferLock);
                    Thread.Sleep(2000);
                }

                // Lấy sản phẩm từ hàng đợi
                item = buffer.Dequeue();
                Console.WriteLine($"Consumed: {item}");
                Monitor.Pulse(bufferLock);
            }
        }
        Thread.Sleep(2000);
    }
}
