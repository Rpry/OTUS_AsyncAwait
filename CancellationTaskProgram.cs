using System.Diagnostics;

namespace Otus.AsyncAwait
{
    public class CancellationTaskProgram : IProgram
    {
        public async Task ExecuteAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            CancellationTokenSource cts = new CancellationTokenSource();    
            var token =  cts.Token;

            List<Task> tasks = new List<Task>();
            Task allTasks = new Task(() => { });

            var server = new Server();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(server.Connect(i.ToString(), token));
            }

            try
            {
                allTasks = Task.WhenAll(tasks);
                
                await Task.Delay(120);
                cts.Cancel();
                
                await allTasks;

                for (int i = 0; i < 10; i++)
                {
                    if (tasks[i].IsCompleted)
                    {
                        Console.WriteLine($"{i} is completed");
                    }
                }

                stopwatch.Stop();

                Console.WriteLine($"finished at {stopwatch.Elapsed}");

                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception Message: {e.Message}");
                Console.WriteLine($"Exception Type: {e.GetType().Name}");

                //Console.WriteLine($"Is Faulted: {allTasks.IsFaulted}");

                if (allTasks.Exception != null)
                {
                    Console.WriteLine($"InnerException: {allTasks.Exception.InnerException}");

                    foreach (var taskException in allTasks.Exception.InnerExceptions)
                    {
                        Console.WriteLine($"Exception Message: {taskException.Message}");
                    }
                }

            }
        }
    }
    public class Server
    {
        public async Task<int> Connect(string clientId, CancellationToken cancellationToken)
        {
            int t = new Random().Next(50, 200);

            Console.WriteLine($"{clientId} start connection with {t} delay");

            if (t > 100)
            {
                throw new InvalidOperationException($"{clientId} timeout error");
            }

            await Task.Delay(t);
            //await Task.Delay(t, cancellationToken);

            //cancellationToken.ThrowIfCancellationRequested();
            if (cancellationToken.IsCancellationRequested)
            {
                return await Task.FromCanceled<int>(cancellationToken);
            }
            
            Console.WriteLine($"{clientId} finished connection");

            return t;
        }
    }
}