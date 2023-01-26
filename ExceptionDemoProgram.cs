namespace Otus.AsyncAwait
{
    public class ExceptionDemoProgram : IProgram
    {
        public async Task ExecuteAsync()
        {
            Task allTasks = Task.CompletedTask;
            try
            {
                var task1 = WaitForSmthAsync(1);
                var task2 = WaitForSmthAsync(2);
                //var task3 = WaitForSmthAsync(3);

                Console.WriteLine("getting all tasks");
                //allTasks = Task.WhenAll(task1, task2, task3);

                await task2;

                Console.WriteLine("after awaiting");
                //await allTasks;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception Message: {e.Message}");
                Console.WriteLine($"Exception Type: {e.Message}");
                Console.WriteLine($"Is Faulted: {allTasks.IsFaulted}");

                if (allTasks.Exception is not null)
                {
                    foreach (var taskException in allTasks.Exception?.InnerExceptions)
                    {
                        Console.WriteLine($"Exception Message: {taskException.Message}");
                    }
                }
            }
        }

        private async Task WaitForSmthAsync(int taskIndex)
        { 
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            if (taskIndex >= 2)
            { 
                throw new InvalidOperationException($"The task {taskIndex} finished with failure");
            }
        }
    }
}