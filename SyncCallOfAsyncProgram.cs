namespace Otus.AsyncAwait
{
    public class SyncCallOfAsyncProgram
    {
        public void Execute1()
        {
            var task = WaitAndWriteStartAsync(); 
            var result = task.Result;
            task.Wait();
            //Console.WriteLine(result);
        }

        public void Execute2()
        {
            var task = WaitAndWriteStartAsync();
            var result = task.GetAwaiter().GetResult();
            Console.WriteLine(result);
        }

        private async Task<bool> WaitAndWriteStartAsync()
        {
            await Task.Delay(10000);
            return true;
        }
    }
}
