namespace Otus.AsyncAwait
{
    public class TasksProgram
    {
        int _bufferedCount = 0;
        private int _position = 0;
        List<int> _buffer = new();
        
        public Task Execute1Async()
        {
            if (_bufferedCount == _buffer.Count)
            {
                return FlushAsync();
            }

            return Task.CompletedTask;
        }
        
        public async Task<int> Execute2Async()
        {
            return await Task.FromResult(1);
        }
        
        public async Task<int> Execute3Async(int[] data)
        {
            if (data.Length == 0)
            {
                return -1;
            }
            
            return await FillBuffer(data);
        }
        
        public async ValueTask<int> Execute4Async(int[] data)
        {
            if (data.Length == 0)
            {
                return -1;
            }
            
            return await FillBuffer(data);
        }
        
        async Task FlushAsync()
        {
            await Task.Delay(1000);
        }

        async Task<int> FillBuffer(int[] data)
        {
            await Task.Delay(1000);
            return await Task.FromResult(data.Length);
        }
    }
}