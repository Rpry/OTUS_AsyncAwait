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
            SaySomething();
            Console.WriteLine(Message);

            //IProgram program = new GettingTaskWithoutAwaitProgram();
            //await program.ExecuteAsync();

            //program = new ParallelTasksProgram();
            //await program.ExecuteAsync();

            //program = new ExceptionDemoProgram();
            //await program.ExecuteAsync();

            //program = new CancellationTaskProgram();
            //await program.ExecuteAsync();

            return;
        }

        static async Task<string> SaySomething()
        {
            await Task.Delay(5);
            Message = "Hello!";
            return "bla-bla-bla";
        }
    }
}