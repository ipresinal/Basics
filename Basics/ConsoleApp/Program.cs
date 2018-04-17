using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Task01();
        }

        static void Thread1()
        {
            Console.ReadLine();
            Console.WriteLine("Hello World!");

            var tcs = new TaskCompletionSource<bool>();

            new Thread(() =>
            {
                Thread.Sleep(2000);
                tcs.TrySetResult(true);
            }).Start();


            var a = tcs.Task.Result;
          
            
        }

        static void Thread2()
        {
            Console.ReadLine();
            Console.WriteLine("Hello World!");
           
            Enumerable.Range(0,10).ToList().ForEach(f =>
            {
                new Thread(() =>
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(1000);

                }).Start();
            });
         
        }

        static void DThread3()
        {
            Console.ReadLine();
            Console.WriteLine("Hello World!");

            Enumerable.Range(0, 100).ToList().ForEach(f =>
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} ended");
                });
            });
        }

        static void Thread4()
        {
            Console.ReadLine();
            Console.WriteLine("Hello World!");

            var t = new Thread(() =>
            {
                Console.WriteLine("Starting download...");
                var webclient = new HttpClient();
                var html = webclient.GetStringAsync("http://angelsix.com");
                Console.WriteLine("Downloading Done!");
            });
            t.Start();

            t.Join();

            Console.WriteLine("All Done!");
            Console.ReadLine();
        }

        static void Task01()
        {
            Console.ReadLine();
            Console.WriteLine("Hello World!");

            Task.Run(async () =>
            {
                await Task.Delay(1000);
                Console.WriteLine("Starting download...");
                var webclient = new HttpClient();
                var html = webclient.GetStringAsync("http://angelsix.com");
                Console.WriteLine("Downloading Done!");
            });

            Console.WriteLine("All Done!");
            Console.ReadLine();
           
        }
    }
}
