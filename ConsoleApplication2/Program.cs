using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            Console.WriteLine("Starting Async Trials");
            timer.Start();
            Task t = AsyncTrialMethod();
            t.Wait();
            timer.Stop();
            Console.WriteLine("Ended Async Trials in " + timer.ElapsedMilliseconds + " milliseconds");
            Console.ReadKey();
        }

        public static async Task AsyncTrialMethod()
        {
            Task t1 = FirstWaitTask();
            Task t2 = SecondWaitTask();
            Stopwatch timer = new Stopwatch();

            timer.Start();
            await t1;
            await t2;
            timer.Stop();

            Console.WriteLine("Both Tasks Done in "+ timer.ElapsedMilliseconds + " milliseconds");
        }

        public static async Task FirstWaitTask()
        {
            Console.WriteLine("First");
            await Task.Delay(5000);
        }

        public static async Task SecondWaitTask()
        {
            Console.WriteLine("Second");
            await Task.Delay(5000);
        }
    }
}
