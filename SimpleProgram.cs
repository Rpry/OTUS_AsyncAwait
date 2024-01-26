using System.Globalization;

namespace Otus.AsyncAwait
{
    public class SimpleProgram
    {
        //Async
        public void Execute1()
        {
            Console.WriteLine("hello"); 
        }
        
        public async void Execute1Async()
        {
            Console.WriteLine("hello");
        }
        
        //Await
        public async void Execute3Async()
        {
            Console.WriteLine($"hello {DateTime.UtcNow}");
            await Task.Delay(5000);
            Console.WriteLine($"hello again {DateTime.UtcNow}");
        }
        
        public async Task<int> ExecuteAsync()
        {
            Console.WriteLine("hello");
            //return Task.FromResult(1);
            //return await Task.FromResult(1);
            var result = await ReturnTaskInt();
            return 1;
        }

        private async Task<int> ReturnTaskInt()
        {
            return await Task.FromResult(1);
        }


        private async Task Method()
        {
            Console.WriteLine("");
            //return Task.CompletedTask;
            //return await Task.Delay(100);
        }
        
        private async Task<int> Method2()
        {
            Console.WriteLine("");
            return await Task.FromResult(1);
        }
    }
}
