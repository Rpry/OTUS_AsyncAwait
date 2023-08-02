using System.Diagnostics;

namespace Otus.AsyncAwait
{
    public class CancellationProgram
    {
        public async Task Execute1Async()
        {
            //cancelling by event

            CancellationTokenSource cts = new CancellationTokenSource();
            var cancelTask = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                cts.Cancel();
                cts.Dispose();
            });


            //cancelling by scheduler
            //CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(4));

            var token =  cts.Token;
            var server = new Server();
            try
            {
                var requestTask = server.ConnectAsync("client 1", token);

                var tasks = new List<Task>()
                {
                    requestTask,
                    cancelTask,
                };

                await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"Exception Message: {e.Message}");
                Console.WriteLine($"Exception Type: {e.GetType().Name}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e.Message} was fired");
            }
        }

        public async Task Execute2Async()
        {
            //cancelling by scheduler
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(4));

            var token =  cts.Token;
            var server = new Server();
            try
            {
                var requestTask1 = server.ConnectAsync("client 1", token);
                var requestTask2 = server.ConnectAsync("client 2", token);

                var tasks = new List<Task>()
                {
                    requestTask1,
                    requestTask2,
                };

                await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"Exception Message: {e.Message}");
                Console.WriteLine($"Exception Type: {e.GetType().Name}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e.Message} was fired");
            }
        }
        public async Task Execute3Async()
        {
            var server = new Server();
            try
            {
                await server.ConnectAsync("client 1").WaitAsync(TimeSpan.FromSeconds(40));
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"Exception Message: {e.Message}");
                Console.WriteLine($"Exception Type: {e.GetType().Name}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e.Message} was fired");
            }
        }
    }
    public class Server
    {
        public async Task<int> ConnectAsync(string clientId, CancellationToken? cancellationToken = null)
        {
            int timeOnOperationMs = new Random().Next(5000, 10000);
            int partOfTimeMs = timeOnOperationMs/10;
            Console.WriteLine($"Server operation started! (client {clientId})");
            int processedTime = 0;

            while (true)
            {
                processedTime += partOfTimeMs;
                await Task.Delay(partOfTimeMs);
                Console.WriteLine($"Operation lasts {processedTime} milliseconds (client {clientId})..");
                if (processedTime >= timeOnOperationMs)
                {
                    break;
                }

                if (cancellationToken != null)
                {
                    cancellationToken.Value.ThrowIfCancellationRequested();

                    /*
                    if (cancellationToken.Value.IsCancellationRequested)
                    {
                        return await Task.FromCanceled<int>(cancellationToken);
                    }
                    */

                }
            }

            Console.WriteLine($"Server operation finished! (client {clientId})");
            return timeOnOperationMs;
        }
    }
}