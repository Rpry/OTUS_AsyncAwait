namespace Otus.AsyncAwait
{
    public class TaskWithoutAsync
    {
        public async Task Execute1Async()
        {
            Task task;
            //task = GetWithKeywordsAsync("https://google.com");
            //await task;
            task = GetElidingKeywordsAsync("https://google.com");
            await task;
        }

        public async Task Execute2Async()
        {
            HttpResponseMessage httpResponseMessage;
            //httpResponseMessage = await GetWithKeywordsAsync("https://google.com");
            httpResponseMessage = await GetElidingKeywordsAsync("https://google.com");
            Console.WriteLine(httpResponseMessage.Version);
        }

        public async Task Execute3Async()
        {
            Console.WriteLine($"Main flow started.");
            var task = Task.Run(() =>
            {
                Console.WriteLine($"Inside task.");
            })
                .ContinueWith(async t =>
            {
                var res= GetElidingKeywordsAsync("https://google.com");
                await res;
            });
            
            await await task; //Task возвращает Task от ContinueWith, поэтому ждем дважды
            Console.WriteLine("Main flow finished");
        }

        private Task<bool> WaitAndWriteStart()
        {
            return WaitAndWriteStartInternal();
        }

        private Task<bool> WaitAndWriteStartInternal()
        {
            throw new Exception("Ex!!");
            Task.Delay(2000);
            Console.WriteLine("finish!");
            return Task.FromResult(true);
        }

        private async Task<HttpResponseMessage> GetWithKeywordsAsync(string url)
        {
            //throw new Exception("Ex!!");
            using (var client = new HttpClient())
            {
                return await client.GetAsync(url);
            }
        }

        private Task<HttpResponseMessage> GetElidingKeywordsAsync(string url)
        {
            //throw new Exception("Ex!!");
            using (var client = new HttpClient())
            {
                return client.GetAsync(url);
            }
        }
    }
}
