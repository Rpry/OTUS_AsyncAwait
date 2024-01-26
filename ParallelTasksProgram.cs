using System.Diagnostics;

namespace Otus.AsyncAwait
{
    public class ParallelTasksProgram
    {
        public async Task Execute1Async() {
            
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };
            foreach (var item in list)
            {
                await SomeLongAwaitingAsync(item);
            }

            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        public async Task Execute2Async() {

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var list = new List<int>() { 2, 1, 3, 4, 5, 6, 7, 8, 9, 10, };

            List<Task<int>> tasks = new List<Task<int>>();
            foreach (var item in list)
            {
                tasks.Add(SomeLongAwaitingAsync(item));
            }

            await Task.WhenAll(tasks);

            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        public async Task Execute3Async() {

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };

            await Parallel.ForEachAsync(list, async (item, cancellationToken) =>
            {
                await SomeLongAwaitingAsync(item);
            });

            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        private async Task<int> SomeLongAwaitingAsync(int item)
        {
            int timeOnOperationMs = new Random().Next(1000, 3000);
            Console.WriteLine($"start delay for {item} thread № {Environment.CurrentManagedThreadId}");
            await Task.Delay(TimeSpan.FromMilliseconds(timeOnOperationMs));
            Console.WriteLine($"finish delay for {item} thread {Environment.CurrentManagedThreadId}");
            //Console.WriteLine($"finish delay for {item} thread № {Environment.CurrentManagedThreadId}");
            return await Task.FromResult(item);
        }
    }
}
