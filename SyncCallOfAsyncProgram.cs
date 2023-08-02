namespace Otus.AsyncAwait
{
    public class SyncCallOfAsyncProgram
    {
        public Task Execute1Async()
        {
            var task = WaitAndWriteStartAsync();
            var result = task.Result;
            //task.Wait();
            Console.WriteLine(result);
            return Task.CompletedTask;
        }

        public async Task Execute2Async()
        {
            var task = WaitAndWriteStartAsync();
            var result = task.GetAwaiter().GetResult();
            Console.WriteLine(result);
        }

        private async Task<bool> WaitAndWriteStartAsync()
        {
            await Task.Delay(2000);
            return true;
        }

        private bool WaitAndWriteStart2()
        {
            return true;
        }
    }
}
