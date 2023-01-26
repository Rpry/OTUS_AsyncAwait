using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.AsyncAwait
{
    public class GettingTaskWithoutAwaitProgram : IProgram
    {
        public async Task ExecuteAsync()
        {
            Console.WriteLine(await GetContentByUrlAsync());
        }

        private async Task<int> GetContentByUrlAsync() 
        {
            using var client = new HttpClient();

            Task<string> contentTask = client.GetStringAsync("https://google.com");

            WriteSomthingElse();
            string content = await contentTask;
            return content.Length;       
        }

        private void WriteSomthingElse() 
        {
            Console.WriteLine("SomethingElse");
        }
    }
}
