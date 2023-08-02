using System.Diagnostics;
using System.Net.Security;
using System.Text;

namespace Otus.AsyncAwait
{
    internal class Program
    {
        private static string Message = "Message";

        static async Task Main(string[] args)
        {
            //SaySomething();
            //Console.WriteLine(Message);
            var commonProgram = new CommonProgram();
            //await commonProgram.Execute1Async();  //task await 1
            //await commonProgram.Execute2Async();  //task await 2
            //await commonProgram.Execute4Async();   //task statuses
            //await commonProgram.Execute3Async();   //task threads

            var creatingTasksProgram = new CreatingTasksProgram();
            //await creatingTasksProgram.Execute2Async();
            //await creatingTasksProgram.Execute3Async();
            //await creatingTasksProgram.Execute1Async();

            var taskWithoutAsync = new TaskWithoutAsync();
            //await taskWithoutAsync.Execute2Async();
            //await taskWithoutAsync.Execute1Async();

            var syncCallOfAsyncProgram = new SyncCallOfAsyncProgram();
            //await syncCallOfAsyncProgram.Execute1Async();
            //await syncCallOfAsyncProgram.Execute2Async();

            var parallelTasksProgram = new ParallelTasksProgram();
            //await parallelTasksProgram.Execute1Async();
            //await parallelTasksProgram.Execute2Async();
            //await parallelTasksProgram.Execute3Async();

            var exceptionProgram = new ExceptionProgram();
            //await exceptionProgram.Execute1Async();
            await exceptionProgram.Execute2Async();
            //await exceptionProgram.Execute3Async();
            //await exceptionProgram.Execute4Async();

            var cancellationProgram = new CancellationProgram();
            //await cancellationProgram.Execute1Async(); // Cancelling one
            //await cancellationProgram.Execute2Async(); // Cancelling many
            //await cancellationProgram.Execute3Async();   // WaitAsync

            return;
        }

        static async Task<string> SaySomething()
        {
            Task.Delay(5);
            Message = "Hello!";
            return "bla-bla-bla";
        }
    }
}