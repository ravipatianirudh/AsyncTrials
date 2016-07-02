using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            Console.WriteLine("Starting Async Trials");
            var ConsoleListener = ConsoleLog.CreateListener();
            ConsoleListener.EnableEvents(AsyncTrialEventSource.Log, System.Diagnostics.Tracing.EventLevel.Informational);
            timer.Start();
            
            Task t = AsyncTrialMethod();
            AsyncTrialEventSource.Log.TaskRunning(t);
            t.Wait();
            timer.Stop();
            Console.WriteLine("Ended Async Trials in " + timer.ElapsedMilliseconds + " milliseconds");
            Console.ReadKey();
        }

        public static async Task AsyncTrialMethod()
        {
            Task t1 = FirstWaitTask();
            AsyncTrialEventSource.Log.TaskRunning(t1);
            Task t2 = SecondWaitTask();
            AsyncTrialEventSource.Log.TaskRunning(t2);
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
