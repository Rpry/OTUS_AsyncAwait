using System.Diagnostics;
using System.Net.Security;
using System.Text;

namespace Otus.AsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var yieldControlProgram = new YieldControlProgram();
            //yieldControlProgram.Example1_Method1(); 
            //yieldControlProgram.Example2_Method1();
            
            var simpleProgram = new SimpleProgram();
            //simpleProgram.Execute1Async();
            //simpleProgram.Execute3Async();
            //simpleProgram.Execute3Async();

            var commonProgram = new CommonProgram();
            //await commonProgram.Execute1Async();  //task await 1
            //await commonProgram.Execute2Async();  //task await 2
            //await commonProgram.Execute4Async();   //task statuses
            //await commonProgram.Execute3Async();   //task threads

            var syncCallOfAsyncProgram = new SyncCallOfAsyncProgram();
            //syncCallOfAsyncProgram.Execute1();
            //syncCallOfAsyncProgram.Execute2();
            
            var taskWithoutAsync = new TaskWithoutAsync();
            //await taskWithoutAsync.Execute1Async();
            //await taskWithoutAsync.Execute1Async();

            var creatingTasksProgram = new StartingTasksProgram();
            //await creatingTasksProgram.Execute0Async();
            //await creatingTasksProgram.Execute00Async();
            //await creatingTasksProgram.Execute2Async();
            //await creatingTasksProgram.Execute3Async();
            //await creatingTasksProgram.Execute_TaskStart();
            
            var parallelTasksProgram = new ParallelTasksProgram();
            //await parallelTasksProgram.Execute1Async();
            //await parallelTasksProgram.Execute2Async();
            //await parallelTasksProgram.Execute3Async();

            var exceptionProgram = new ExceptionProgram();
            //await exceptionProgram.Execute1Async();
            //await exceptionProgram.Execute2Async();
            //await exceptionProgram.Execute3Async();
            //await exceptionProgram.Execute4Async();

            var cancellationProgram = new CancellationProgram();
            //await cancellationProgram.Execute1Async(); // Cancelling one by scheduler
            //await cancellationProgram.Execute1Async2(); // Cancelling one by event
            //await cancellationProgram.Execute2Async(); // Cancelling many
            //await cancellationProgram.Execute3Async();   // WaitAsync

            return;
        }
    }
}