﻿namespace Interlocked
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Interlocked.Increment(ref n);
                }
            });

            thread.Start();

            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Decrement(ref n);
            }

            thread.Join();
            Console.WriteLine($"Result: {n}");
        }
    }
}
