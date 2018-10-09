using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NET_Async_Programming.Models;
using NET_Async_Programming.Repositories;

namespace NET_Async_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestAsyncUrlCaller().GetAwaiter().GetResult();
            TestUrlCaller();
        }

        static async Task TestAsyncUrlCaller()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            AsyncURLCaller asyncURLCaller = new AsyncURLCaller(URLRepository.GetRepository().GetURLs());
            long sum = await asyncURLCaller.CallMultipleURLAsync();

            stopWatch.Stop();

            long milliseconds = stopWatch.ElapsedMilliseconds;

            Console.WriteLine(string.Format("Asyncronous method:\n\tTotal length: {0}\n\tTotal time (ms): {1}", sum, milliseconds));
        }

        static void TestUrlCaller()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            SyncURLCaller urlCaller = new SyncURLCaller((URLRepository.GetRepository().GetURLs()));
            long sum = urlCaller.CallMultipleURL();

            stopWatch.Stop();

            long milliseconds = stopWatch.ElapsedMilliseconds;
            Console.WriteLine(string.Format("Asyncronous method:\n\tTotal length: {0}\n\tTotal time (ms): {1}", sum, milliseconds));
        }
    }
}