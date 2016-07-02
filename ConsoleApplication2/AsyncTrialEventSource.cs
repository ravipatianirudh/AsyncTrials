using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    [EventSource(Name = "AsyncTrialEventSource")]
    class AsyncTrialEventSource : EventSource
    {
        private static readonly Lazy<AsyncTrialEventSource> Instance = new Lazy<AsyncTrialEventSource>(() => new AsyncTrialEventSource());

        private AsyncTrialEventSource() { }

        public static AsyncTrialEventSource Log
        {
            get { return Instance.Value; }
        }

        [NonEvent]
        public void TaskRunning(Task t)
        {
            TaskRunningCore(t.Id, t.Status);
        }

        [Event(1,Level = EventLevel.Informational,Message = "Task with ID = {0} and Status = {1})")]
        private void TaskRunningCore(int id, TaskStatus status)
        {
            WriteEvent(1,id,status.ToString());
        }
    }
}
