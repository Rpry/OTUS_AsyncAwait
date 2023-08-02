namespace Otus.AsyncAwait
{
    public class CreatingTasksProgram
    {
        public async Task Execute1Async()
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
    }
}