using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NET_Async_Programming.Models
{
    public class AsyncURLCaller
    {
        private IEnumerable<string> urlList;
        public AsyncURLCaller(IEnumerable<string> urlList)
        {
            this.urlList = urlList;
        }
        
        public async Task<long> CallMultipleURLAsync()
        {
            HttpClient client = new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            IEnumerable<int> urlLengths = await ProcessURLListAsync(client);
         
            return urlLengths.Sum(x => x);
        }

        private async Task<IEnumerable<int>> ProcessURLListAsync(HttpClient client)
        {
            var allUrlTasks = this.urlList.Select( url => ProcessURLAsync(url, client));
            return await Task.WhenAll(allUrlTasks);
        }

        private async Task<int> ProcessURLAsync(string url, HttpClient client)
        {
            var byteArray = await client.GetByteArrayAsync(url);
            return byteArray.Length;
        }
    }
}