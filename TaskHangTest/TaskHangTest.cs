using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskHangTest
{
    public class TaskTest
    {
        TaskCompletionSource<object> source = new TaskCompletionSource<object>();

        private async Task RunTaskInternal()
        {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Task.Run(() =>
            {
                //Thread.Sleep(10000);
                ThreadPool.QueueUserWorkItem((userData) =>
                {
                    source.SetResult(null);
                });
            });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            await source.Task;
        }

        public static Task RunTask()
        {
            TaskTest taskTest = new TaskTest();

            return taskTest.RunTaskInternal();
        }
    }
}
