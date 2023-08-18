using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace spitfire_solutions
{
    public class JsonServers
    {
        private readonly HttpClient _client;

        public JsonServers()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.None
            };
            _client = new HttpClient(handler);
        }

        public async Task<string> GetAsync( string url )
        {
            using HttpResponseMessage respone = await _client.GetAsync( url );
            return await respone.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync( string uri, string data, string contentType )
        {
            using HttpContent content = new StringContent(data, Encoding.UTF8, contentType);
            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Content = content,
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri)
            };

            using HttpResponseMessage response = await _client.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
