namespace Otus.AsyncAwait
{
    public class ExceptionProgram
    {
        public async Task Execute1Async()
        {
            Task task = null;
            try
            {
                task = ThrowInAsync(1);
                await task;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception Message: {e.Message}");
                Console.WriteLine($"Exception Type: {task.Status}");
                Console.WriteLine($"Exception Type: {task.IsFaulted}");
            }
        }

        public async Task Execute2Async()
        {
            Task allTasks = Task.CompletedTask;
            try
            {
                var task1 = ThrowInAsync(1);
                var task2 = ThrowInAsync(2);
                var task3 = ThrowInAsync(3);

                Console.WriteLine("getting all tasks");
                allTasks = Task.WhenAll(task1, task2, task3);

                Console.WriteLine("after awaiting");
                await allTasks;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception Message: {e.Message}");
                Console.WriteLine($"Exception Type: {e.GetType()}");
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

        public async Task Execute3Async()
        {
            Task<bool> task = null;
            try
            {
                task = Task.Run<bool>(async () =>
                {
                    await ThrowInAsync(1);
                    return true;
                });

                //var result = task.Result;
                //task.Wait();
                var result = task.GetAwaiter().GetResult();

            }
            catch (AggregateException e)
            {

            }

            catch (Exception e)
            {
                Console.WriteLine($"Exception Message: {e.Message}");
                Console.WriteLine($"Exception Type: {task.Status}");
                Console.WriteLine($"Exception Type: {task.IsFaulted}");
            }
        }

        public async Task Execute4Async()
        {
            try
            {
                MethodAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        private async Task ThrowInAsync(int i)
        { 
            //await Task.Delay(TimeSpan.FromMilliseconds(1));
            throw new InvalidOperationException($"The task {i} finished with failure");
        }

        //private void MethodAsync()
        //private async Task MethodAsync()
        //private Task MethodAsync()
        private async void MethodAsync()
        {
            //await Task.Delay(1000);
            throw new Exception("Ex!");
        }
    }
}