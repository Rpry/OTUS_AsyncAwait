namespace Otus.AsyncAwait
{
    public class StartingTasksProgram
    {
        public async Task Execute0Async()
        {
            Console.WriteLine($"Start: {Environment.CurrentManagedThreadId}");
            var task = new Task(() =>
            {
                Console.WriteLine($"Before operation: {Environment.CurrentManagedThreadId}");
                Console.WriteLine("Inside task");
                Console.WriteLine($"After operation: {Environment.CurrentManagedThreadId}");
            });
            await task;
            Console.WriteLine($"Finish: ThreadId {Environment.CurrentManagedThreadId}");
        }
        
        public async Task Execute00Async()
        {
            Console.WriteLine($"Start: {Environment.CurrentManagedThreadId}");
            var task = Internal();
            await Task.Delay(TimeSpan.FromSeconds(3));
            await task;
            Console.WriteLine($"Finish: ThreadId {Environment.CurrentManagedThreadId}");
        }
        
        public async Task Execute2Async()
        {
            Console.WriteLine($"Main flow started.");
            await Task.Run(() =>
            {
                Console.WriteLine("Task started");
                Console.WriteLine("Task ended");
            });
            Console.WriteLine("Main flow finished");
        }

        public async Task Execute3Async()
        {
            Console.WriteLine("Main flow started");
            await Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task started");
                Console.WriteLine("Task ended");
            }, TaskCreationOptions.None);
            Console.WriteLine("Main flow finished");
        }
        
        public async Task Execute_TaskStart()
        {
            Console.WriteLine("Main flow started");
            var task = new Task(() =>
            {
                Console.WriteLine("Task started");
                Console.WriteLine("Task ended");
            });
            Console.WriteLine($"STATUS: {task.Status}");
            task.Start();
            Console.WriteLine($"STATUS: {task.Status}");
            await task;
            Console.WriteLine($"STATUS: {task.Status}");
            Console.WriteLine("Main flow finished");
        }

        private async Task Internal()
        {
            Console.WriteLine($"Before operation: {Environment.CurrentManagedThreadId}");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("Inside");
            Console.WriteLine($"After operation: {Environment.CurrentManagedThreadId}");    
        }
    }
}