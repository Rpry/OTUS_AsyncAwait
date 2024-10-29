using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.AsyncAwait
{
    public class CommonProgram
    {
        public async Task Execute1Async()
        {
            WaitAndWriteStartAsync();
            Console.WriteLine("finish");
        }

        public async Task Execute2Async()
        {
            var task = StartAsync();
            Console.WriteLine("finish");
            await task;
        }

        public async Task Execute3Async()
        {
            Console.WriteLine($"pre-start. ThreadId {Environment.CurrentManagedThreadId}");
            await StartAsync();
            Console.WriteLine($"after-start. ThreadId {Environment.CurrentManagedThreadId}");
        }

        public async Task Execute4Async()
        {
            //Console.WriteLine($"pre-start. ThreadId {Environment.CurrentManagedThreadId}");
            var task = DelayAsync();
            while (!task.IsCompleted)
            {
                Console.WriteLine($"task state >> {task.Status}");
                //await Task.Delay(TimeSpan.FromSeconds(1));
            }
            Console.WriteLine($"task state after while: {task.Status}");
            await task;
            Console.WriteLine($"task state after await: {task.Status}");
        }

        private async Task WaitAndWriteStartAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("Start");
        }

        private async Task StartAsync()
        {
            await Task.Delay(2000);
            //await Task.Delay(0);
            Console.WriteLine("start");
        }

        private async Task DelayAsync()
        {
            await Task.Delay(2000);
        }


        private async Task Execute2Async_2()
        {
            var task = StartAsync();
            while (!task.IsCompleted)
            {
                await Task.Delay(1000);
            }

            Console.WriteLine("finish");
            await task;
        }
    }
}
