using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.AsyncAwait
{
    public class ParallelTasksProgram : IProgram
    {
        public async Task ExecuteAsync() {
            
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var task1 = SomeLongAwaitingAsync();
            var task2 = SomeLongAwaitingAsync();
            var task3 = SomeLongAwaitingAsync();

            //Console.WriteLine($"result: {await task1}");

            await Task.WhenAll(task1, task2, task3);    

            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);

        }

        private async Task<int> SomeLongAwaitingAsync()
        {
            Console.WriteLine("start delay");
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine("finish delay");

            return await Task.FromResult(42);
        }
    }
}
